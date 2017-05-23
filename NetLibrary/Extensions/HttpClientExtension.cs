using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetLibrary.Extensions {
	/// <summary> 
	/// HttpClient の拡張メソッドを提供します。 
	/// </summary> 
	public static partial class HttpClientExtension {
		#region メソッド

		#region Post

		/// <summary>
		/// 指定された URI に POST 要求を非同期操作として送信します。
		/// </summary>
		/// <param name="this">HttpClient</param>
		/// <param name="uri">URI</param>
		/// <param name="nameValueCollection">名前と値のコレクション</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PostAsync(HttpClient @this, Uri uri, IEnumerable<KeyValuePair<string, string>> nameValueCollection) {
			var content = new FormUrlEncodedContent(nameValueCollection);
			var response = await @this.PostAsync(uri, content);
			return response;
		}

		#endregion

		#endregion
	}
}
