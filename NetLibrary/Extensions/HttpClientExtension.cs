using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExtensionsLibrary.Extensions;

namespace NetLibrary.Extensions {
	/// <summary> 
	/// HttpClient の拡張メソッドを提供します。 
	/// </summary> 
	public static partial class HttpClientExtension {
		#region メソッド

		#region POST

		/// <summary>
		/// 指定された URI に POST 要求を非同期操作として送信します。
		/// </summary>
		/// <param name="this">HttpClient</param>
		/// <param name="requestUri">要求の送信先 URI</param>
		/// <param name="nameValueCollection">名前と値のコレクション</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PostAsync(this HttpClient @this, string requestUri, IEnumerable<KeyValuePair<string, string>> nameValueCollection) {
			var content = new FormUrlEncodedContent(nameValueCollection);
			return await @this.PostAsync(requestUri, content);
		}

		/// <summary>
		/// 指定された URI に POST 要求を非同期操作として送信します。
		/// </summary>
		/// <param name="this">HttpClient</param>
		/// <param name="requestUri">要求の送信先 URI</param>
		/// <param name="nameValueCollection">名前と値のコレクション</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PostAsync(this HttpClient @this, Uri requestUri, IEnumerable<KeyValuePair<string, string>> nameValueCollection) {
			var content = new FormUrlEncodedContent(nameValueCollection);
			return await @this.PostAsync(requestUri, content);
		}

		/// <summary>
		/// 指定された URI に POST 要求を非同期操作として送信します。
		/// </summary>
		/// <typeparam name="T">要求の内容を格納した値の型</typeparam>
		/// <param name="this">HttpClient</param>
		/// <param name="requestUri">要求の送信先 URI</param>
		/// <param name="value">要求の内容を格納した値</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PostAsync<T>(this HttpClient @this, string requestUri, T value) {
			var content = value.ToHttpContent();
			return await @this.PostAsync(requestUri, content);
		}

		/// <summary>
		/// 指定された URI に POST 要求を非同期操作として送信します。
		/// </summary>
		/// <typeparam name="T">要求の内容を格納した値の型</typeparam>
		/// <param name="this">HttpClient</param>
		/// <param name="requestUri">要求の送信先 URI</param>
		/// <param name="value">要求の内容を格納した値</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PostAsync<T>(this HttpClient @this, Uri requestUri, T value) {
			var content = value.ToHttpContent();
			return await @this.PostAsync(requestUri, content);
		}

		#endregion

		#region PUT

		/// <summary>
		/// 指定された URI に PUT 要求を非同期操作として送信します。
		/// </summary>
		/// <param name="this">HttpClient</param>
		/// <param name="requestUri">要求の送信先 URI</param>
		/// <param name="nameValueCollection">名前と値のコレクション</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PutAsync(this HttpClient @this, string requestUri, IEnumerable<KeyValuePair<string, string>> nameValueCollection) {
			var content = new FormUrlEncodedContent(nameValueCollection);
			return await @this.PutAsync(requestUri, content);
		}

		/// <summary>
		/// 指定された URI に PUT 要求を非同期操作として送信します。
		/// </summary>
		/// <param name="this">HttpClient</param>
		/// <param name="requestUri">要求の送信先 URI</param>
		/// <param name="nameValueCollection">名前と値のコレクション</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PutAsync(this HttpClient @this, Uri requestUri, IEnumerable<KeyValuePair<string, string>> nameValueCollection) {
			var content = new FormUrlEncodedContent(nameValueCollection);
			return await @this.PutAsync(requestUri, content);
		}


		/// <summary>
		/// 指定された URI に PUT 要求を非同期操作として送信します。
		/// </summary>
		/// <typeparam name="T">要求の内容を格納した値の型</typeparam>
		/// <param name="this">HttpClient</param>
		/// <param name="requestUri">要求の送信先 URI</param>
		/// <param name="value">要求の内容を格納した値</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PutAsync<T>(this HttpClient @this, string requestUri, T value) {
			var content = value.ToHttpContent();
			return await @this.PutAsync(requestUri, content);
		}

		/// <summary>
		/// 指定された URI に PUT 要求を非同期操作として送信します。
		/// </summary>
		/// <typeparam name="T">要求の内容を格納した値の型</typeparam>
		/// <param name="this">HttpClient</param>
		/// <param name="requestUri">要求の送信先 URI</param>
		/// <param name="value">要求の内容を格納した値</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PutAsync<T>(this HttpClient @this, Uri requestUri, T value) {
			var content = value.ToHttpContent();
			return await @this.PutAsync(requestUri, content);
		}

		#endregion

		/// <summary>
		/// HttpContent に変換します。
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="this">要素</param>
		/// <returns>HttpContent に変換した値を返します。</returns>
		public static HttpContent ToHttpContent<T>(this T @this) {
			var dic = @this.ToPropertyDictionary().ToDictionary(kv => kv.Key, kv => kv.Value?.ToString());
			return new FormUrlEncodedContent(dic);
		}

		#endregion
	}
}
