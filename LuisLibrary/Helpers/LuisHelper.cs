using System.Threading.Tasks;
using LuisLibrary.Data;
using LuisLibrary.Utility;

namespace LuisLibrary.Helpers {
	/// <summary>
	/// Luis へのアクセスを補助するクラスです。
	/// </summary>
	public class LuisHelper {
		#region フィールド

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="appId">アプリケーションID</param>
		/// <param name="key">エンドポイントキー</param>
		public LuisHelper(string appId, string key) {
			this.AppId = appId;
			this.EndpointKey = key;
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// アプリケーションID
		/// </summary>
		public string AppId { get; protected set; }

		/// <summary>
		/// エンドポイントキー
		/// </summary>
		public string EndpointKey { get; protected set; }

		#endregion

		#region メソッド

		/// <summary>
		/// 会話の内容を解析します。
		/// </summary>
		/// <param name="talk">会話</param>
		/// <returns>解析結果を返します。</returns>
		public async Task<LuisResponseRoot> AnalyzeAsync(string talk) {
			return await LuisUtility.AnalyzeAsync(this.AppId, this.EndpointKey, talk);
		}

		#endregion
	}
}
