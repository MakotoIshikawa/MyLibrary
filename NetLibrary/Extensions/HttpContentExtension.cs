using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetLibrary.Extensions {
	/// <summary> 
	/// HttpContent の拡張メソッドを提供します。 
	/// </summary> 
	public static partial class HttpContentExtension {
		#region メソッド

		#region Read

		/// <summary> 
		/// HttpResponseMessage の Content から JSON をオブジェクトにデシリアライズするメソッド 
		/// </summary> 
		/// <typeparam name="T">JSON をデシリアライズする型</typeparam>
		/// <param name="this">HttpContent</param>
		/// <param name="enc">文字エンコーディング</param>
		/// <returns>HttpContent から読み込んだ JSON をデシリアライズした結果のオブジェクト</returns> 
		public static async Task<T> ReadAsJsonAsync<T>(this HttpContent @this, Encoding enc = null) {
			var jsonText = (enc != null)
				? await @this.ReadAsStringAsync(enc)
				: await @this.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(jsonText);
		}

		/// <summary>
		/// 非同期で文字列に HTTP コンテンツをシリアル化し、
		/// 指定した文字エンコーディングの文字列として読み込みます。
		/// </summary>
		/// <param name="this"></param>
		/// <param name="enc">文字エンコーディング</param>
		/// <returns>読み込んだ文字列を返します。</returns>
		public static async Task<string> ReadAsStringAsync(this HttpContent @this, Encoding enc) {
			var binary = await @this.ReadAsByteArrayAsync();
			return enc.GetString(binary, 0, binary.Length);
		}

		/// <summary>
		/// Stream を読み取ります。[非同期]
		/// </summary>
		/// <param name="this">HttpContent</param>
		/// <param name="readStream">Stream を加工するメソッド</param>
		public static async Task ReadStreamAsync(this HttpContent @this, Action<Stream> readStream) {
			using (var stream = await @this.ReadAsStreamAsync()) {
				readStream?.Invoke(stream);
			}
		}

		#endregion

		#endregion
	}
}
