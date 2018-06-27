using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JsonLibrary.Extensions {
	/// <summary>
	/// HttpContent を拡張するメソッドを提供します。
	/// </summary>
	public static partial class HttpContentExtension {
		#region メソッド

		/// <summary>
		/// HTTP コンテンツを JToken に変換します。
		/// </summary>
		/// <param name="this">HttpContent</param>
		/// <returns>変換した JToken を返します。</returns>
		public static async Task<JToken> ToJTokenAsync(this HttpContent @this) {
			var contents = await @this.ReadAsStringAsync();
			var token = contents.Deserialize<JToken>();
			return token;
		}

		#endregion
	}
}
