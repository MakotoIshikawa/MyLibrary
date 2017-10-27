using System.Text;
using ExtensionsLibrary.Extensions;

namespace LuisLibrary.Data {
	/// <summary>
	/// Luis からの応答データです。
	/// </summary>
	public class LuisResponseRoot {
		#region プロパティ

		/// <summary>
		/// 問い合わせ
		/// </summary>
		public string query { get; set; }

		/// <summary>
		/// トップスコアのインテント
		/// </summary>
		public Intent topScoringIntent { get; set; }

		/// <summary>
		/// エンティティの配列
		/// </summary>
		public Entity[] entities { get; set; }

		#endregion

		#region メソッド

		/// <summary>
		/// ログ用の文字列を作成します。
		/// </summary>
		/// <returns>ログの文字列を返します。</returns>
		public string MakeLog() {
			var intent = this.topScoringIntent;
			var sb = new StringBuilder();
			if (intent.intent == "AngerMessage") {
				sb.Append($"[警告:{intent.score:0.00}]");
			}
			sb.Append(this.query);

			return sb.ToString();
		}

		/// <summary>
		/// オブジェクトを文字列に変換します。
		/// </summary>
		/// <returns>オブジェクトを表す文字列を返します。</returns>
		public override string ToString()
			=> this.GetPropertiesString();

		#endregion
	}
}
