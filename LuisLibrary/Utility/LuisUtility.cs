using System;
using System.Threading.Tasks;
using LuisLibrary.Data;
using LuisLibrary.Extensions;

namespace LuisLibrary.Utility {
	/// <summary>
	/// Luis の共通処理を提供するクラスです。
	/// </summary>
	public static partial class LuisUtility {
		#region メソッド

		#region 解析

		/// <summary>
		/// Luis API を呼び出して会話の内容を解析します。(非同期)
		/// </summary>
		/// <param name="appId">アプリケーションID</param>
		/// <param name="key">キー</param>
		/// <param name="talk">会話</param>
		/// <returns>解析結果を返します。</returns>
		public static async Task<LuisResponseRoot> AnalyzeAsync(string appId, string key, string talk) {
			var requestUri = GetUriOfLuisApi(appId, key, talk);
			return await requestUri.ReadAsJsonAsync<LuisResponseRoot>();
		}

		/// <summary>
		/// Luis API の URI を取得します。
		/// </summary>
		/// <param name="appId">アプリケーションID</param>
		/// <param name="key">キー</param>
		/// <param name="talk">会話</param>
		/// <returns>Luis API の URI を返します。</returns>
		private static Uri GetUriOfLuisApi(string appId, string key, string talk) {
			var uriString = @"https://api.projectoxford.ai/luis/v2.0/apps/";
			uriString += $"{appId}?subscription-key={key}&q={talk}&verbose=true";

			return new Uri(uriString);
		}

		#endregion

		#endregion
	}
}
