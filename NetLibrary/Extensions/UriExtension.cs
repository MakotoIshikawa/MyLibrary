using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetLibrary.Extensions {
	/// <summary>
	/// Uri クラスを拡張するメソッドを提供します。
	/// </summary>
	public static partial class UriExtension {
		#region メソッド

		/// <summary>
		/// 指定 URI に GET 要求を送信し、非同期操作で応答本体を JObject として返します。
		/// </summary>
		/// <param name="this">Uri</param>
		/// <param name="setting">HttpClient の設定を行うメソッド</param>
		/// <returns>応答データの JObject を返します。</returns>
		public static async Task<JObject> GetObjectAsync(this Uri @this, Action<HttpClient> setting = null) {
			var json = await @this.GetStringAsync(setting);
			var obj = JObject.Parse(json);
			return obj;
		}

		#region String

		/// <summary>
		/// 指定 URI に GET 要求を送信し、非同期操作で応答本体を文字列として返します。
		/// </summary>
		/// <param name="this">Uri</param>
		/// <param name="setting">HttpClient の設定を行うメソッド</param>
		/// <returns>応答データの文字列を返します。</returns>
		public static async Task<string> GetStringAsync(this Uri @this, Action<HttpClient> setting = null) {
			using (var client = new HttpClient()) {
				setting?.Invoke(client);

				var jsonText = await client.GetStringAsync(@this);
				return jsonText;
			}
		}

		#endregion

		#region Json

		/// <summary>
		/// 非同期操作で、指定 URI に GET 要求を送信し、
		/// 応答メッセージを JSON オブジェクトにデシリアライズします。
		/// <para>HTTP 応答が成功しなかった場合、例外がスローされます。</para>
		/// </summary>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="this">Uri</param>
		/// <param name="enc">文字エンコーディング</param>
		/// <param name="setting">HttpClient の設定を行うメソッド</param>
		/// <returns>デシリアライズ JSON オブジェクトを返します。</returns>
		public static async Task<TResult> GetJsonAsync<TResult>(this Uri @this, Encoding enc, Action<HttpClient> setting = null) {
			using (var client = new HttpClient()) {
				setting?.Invoke(client);

				var response = await client.GetAsync(@this);
				response.EnsureSuccessStatusCode();

				return await response.Content.ReadAsJsonAsync<TResult>(enc);
			}
		}

		/// <summary>
		/// 非同期操作で、指定 URI に GET 要求を送信し、
		/// 応答メッセージを JSON オブジェクトにデシリアライズします。
		/// </summary>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="this">Uri</param>
		/// <param name="setting">HttpClient の設定を行うメソッド</param>
		/// <returns>デシリアライズ JSON オブジェクトを返します。</returns>
		public static async Task<TResult> GetJsonAsync<TResult>(this Uri @this, Action<HttpClient> setting = null) {
			using (var client = new HttpClient()) {
				setting?.Invoke(client);

				var jsonText = await client.GetStringAsync(@this);
				return JsonConvert.DeserializeObject<TResult>(jsonText);
			}
		}

		#endregion

		#region Stream

		/// <summary>
		/// 指定 URI に GET 要求を送信し、非同期操作で応答をストリームとして操作します。
		/// <para>HTTP 応答が成功しなかった場合、例外がスローされます。</para>
		/// </summary>
		/// <param name="this">Uri</param>
		/// <param name="readStream">Stream を加工するメソッド</param>
		/// <param name="setting">HttpClient の設定を行うメソッド</param>
		public static async Task ReadStreamAsync(this Uri @this, Action<Stream> readStream, Action<HttpClient> setting = null) {
			using (var client = new HttpClient()) {
				setting?.Invoke(client);

				var response = await client.GetAsync(@this);
				response.EnsureSuccessStatusCode();

				await response.Content.ReadStreamAsync(readStream);
			}
		}

		/// <summary>
		/// 指定 URI に GET 要求を送信し、非同期操作で応答本体をストリームとして取得します。
		/// </summary>
		/// <param name="this">Uri</param>
		/// <param name="setting">HttpClient の設定を行うメソッド</param>
		/// <returns>応答データのストリームを返します。</returns>
		public static async Task<MemoryStream> GetStreamAsync(this Uri @this, Action<HttpClient> setting = null) {
			var ms = new MemoryStream();
			using (var client = new HttpClient()) {
				setting?.Invoke(client);

				using (var stream = await client.GetStreamAsync(@this)) {
					await stream.CopyToAsync(ms);
				}
			}

			ms.Seek(0, SeekOrigin.Begin);

			return ms;
		}

		#endregion

		#region POST

		/// <summary>
		/// POST 要求を非同期操作として送信します。
		/// </summary>
		/// <typeparam name="T">要求の内容を格納した値の型</typeparam>
		/// <param name="this">Uri</param>
		/// <param name="value">要求の内容を格納した値</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PostAsync<T>(this Uri @this, T value) {
			using (var client = new HttpClient()) {
				return await client.PostAsync(@this, value);
			}
		}

		#endregion

		#region PUT

		/// <summary>
		/// PUT 要求を非同期操作として送信します。
		/// </summary>
		/// <typeparam name="T">要求の内容を格納した値の型</typeparam>
		/// <param name="this">Uri</param>
		/// <param name="value">要求の内容を格納した値</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> PutAsync<T>(this Uri @this, T value) {
			using (var client = new HttpClient()) {
				return await client.PutAsync(@this, value);
			}
		}

		#endregion

		#region DELETE

		/// <summary>
		/// DELETE 要求を非同期操作として送信します。
		/// </summary>
		/// <param name="this">Uri</param>
		/// <returns>HTTP 応答メッセージを返します。</returns>
		public static async Task<HttpResponseMessage> DeleteAsync(this Uri @this) {
			using (var client = new HttpClient()) {
				return await client.DeleteAsync(@this);
			}
		}

		#endregion

		#endregion
	}
}
