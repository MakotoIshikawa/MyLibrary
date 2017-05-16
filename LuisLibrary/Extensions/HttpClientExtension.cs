using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LuisLibrary.Extensions {
	/// <summary> 
	/// HttpClientがシームレスにJSONと連携するための拡張メソッドを提供します。 
	/// </summary> 
	public static partial class HttpClientExtension {
		/// <summary> 
		/// HttpResponseMessageのContentからJSONをオブジェクトにデシリアライズするメソッド 
		/// </summary> 
		/// <typeparam name="T">JSONをデシリアライズする型</typeparam> 
		/// <param name="this">HttpContent</param> 
		/// <returns>HttpContentから読み込んだJSONをデシリアライズした結果のオブジェクト</returns> 
		private static async Task<T> ReadAsJsonAsync<T>(this HttpContent @this) {
#if false
			var binary = await content.ReadAsByteArrayAsync();
			var jsonText = Encoding.UTF8.GetString(binary, 0, binary.Length);
#else
			var jsonText = await @this.ReadAsStringAsync();
#endif
			return JsonConvert.DeserializeObject<T>(jsonText);
		}

		/// <summary>
		/// 指定された URI に GET 要求を送信して
		/// 応答メッセージの JSON デシリアライズします。
		/// </summary>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="this">Uri</param>
		/// <returns>読み込んだ JSON をデシリアライズしたものを返します。</returns>
		public static async Task<TResult> ReadAsJsonAsync<TResult>(this Uri @this) {
			using (var client = new HttpClient()) {
				var response = await client.GetAsync(@this);
				response.EnsureSuccessStatusCode();

				return await response.Content.ReadAsJsonAsync<TResult>();
			}
		}
	}
}
