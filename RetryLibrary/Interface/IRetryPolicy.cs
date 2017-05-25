using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryLibrary.Interface {
	/// <summary>
	/// リトライ処理が必要な場合の、リトライのルールを定義する抽象クラスです。
	/// このクラスを継承してリトライが必要な各処理でルールを定義します。
	/// </summary>
	public interface IRetryPolicy {
		/// <summary>
		/// 最大リトライ回数
		/// </summary>
		int MaxRetryNum { get; }

		/// <summary>
		/// リトライ時のベースとなる処理停止時間
		/// </summary>
		int RetrySleep { get; }

		/// <summary>
		/// リトライ時の最大処理停止時間
		/// </summary>
		int MaxSleep { get; }

		/// <summary>
		/// リトライ時の最小処理停止時間
		/// </summary>
		int MinSleep { get; }
	}
}
