using System;
using RetryLibrary.Interface;
using static System.Math;
using static System.Threading.Thread;

namespace RetryLibrary {
	/// <summary>
	/// リトライ処理が必要な箇所で指定された条件によってリトライを行うためのクラスです。
	/// </summary>
	public class RetryExecutor : IRetryPolicy {
		#region コンストラクタ

		/// <summary>
		/// リトライルールを受け取ってインスタンスを生成します。
		/// </summary>
		/// <param name="policy">IRetryPolicy</param>
		public RetryExecutor(IRetryPolicy policy) :
			this(policy.MaxRetryNum, policy.RetrySleep, policy.MaxSleep, policy.MinSleep) {
		}

		/// <summary>
		/// インスタンスを生成します。
		/// </summary>
		/// <param name="maxRetryNum">最大リトライ回数</param>
		/// <param name="retrySleep">リトライ時のベースとなる処理停止時間</param>
		/// <param name="maxSleep">リトライ時の最大処理停止時間</param>
		/// <param name="minSleep">リトライ時の最小処理停止時間</param>
		public RetryExecutor(int maxRetryNum, int retrySleep, int maxSleep, int minSleep) {
			this.MaxRetryNum = maxRetryNum;
			this.MaxSleep = maxSleep;
			this.MinSleep = minSleep;
			this.RetrySleep = retrySleep;
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// 最大リトライ回数
		/// </summary>
		public int MaxRetryNum { get; set; }

		/// <summary>
		/// リトライ時のベースとなる処理停止時間
		/// </summary>
		public int RetrySleep { get; set; }

		/// <summary>
		/// リトライ時の最大処理停止時間
		/// </summary>
		public int MaxSleep { get; set; }

		/// <summary>
		/// リトライ時の最小処理停止時間
		/// </summary>
		public int MinSleep { get; set; }

		#endregion

		/// <summary>
		/// リトライをかけながら指定された処理を実行します。
		/// </summary>
		/// <param name="executeAction">実行する処理</param>
		/// <param name="errorAction">処理実行時に発生したエラー処理</param>
		/// <param name="finallyAction">全てのリトライが完了した後に行う処理</param>
		public virtual void Execute(Action executeAction, Action<Exception> errorAction = null, Action finallyAction = null) {
			if (executeAction == null) {
				return;
			}

			for (var retryNum = 0; retryNum < this.MaxRetryNum; retryNum++) {
				try {
					executeAction?.Invoke();
				} catch (Exception ex) {
					errorAction?.Invoke(ex);

					if (retryNum >= this.MaxRetryNum) {
						throw;
					}

					var sleep = (int)Pow(retryNum + 1, 2.0) + this.RetrySleep;
					sleep = (this.MaxSleep < sleep)
						? this.MaxSleep
						: (sleep < this.MinSleep) ? this.MinSleep : sleep;

					Sleep(sleep);
				}
			}

			finallyAction?.Invoke();
		}

		/// <summary>
		/// リトライをかけながら指定された処理を実行します。
		/// </summary>
		/// <param name="executeAction">実行する処理</param>
		/// <param name="errorAction">処理実行時に発生したエラー処理</param>
		/// <param name="finallyAction">全てのリトライが完了した後に行う処理</param>
		/// <returns>処理実行結果</returns>
		public virtual T Execute<T>(Func<T> executeAction, Action<Exception> errorAction = null, Action<T> finallyAction = null) {
			var ret = default(T);
			if (executeAction == null) {
				return ret;
			}

			for (var retryNum = 0; retryNum < this.MaxRetryNum; retryNum++) {
				try {
					ret = executeAction();
					break;
				} catch (Exception ex) {
					errorAction?.Invoke(ex);

					if (retryNum >= this.MaxRetryNum) {
						throw;
					}

					var sleep = (int)Pow(retryNum + 1, 2.0) + this.RetrySleep;
					sleep = (this.MaxSleep < sleep)
						? this.MaxSleep
						: (sleep < this.MinSleep) ? this.MinSleep : sleep;

					Sleep(sleep);
				}
			}

			finallyAction?.Invoke(ret);

			return ret;
		}
	}
}
