using ExtensionsLibrary.Extensions;

namespace LuisLibrary.Data {

	/// <summary>
	/// インテント
	/// </summary>
	public class Intent {
		#region プロパティ

		/// <summary>
		/// インテント
		/// </summary>
		public string intent { get; set; }

		/// <summary>
		/// スコア
		/// </summary>
		public float score { get; set; }

		#endregion

		#region メソッド

		/// <summary>
		/// オブジェクトを文字列に変換します。
		/// </summary>
		/// <returns>オブジェクトを表す文字列を返します。</returns>
		public override string ToString()
			=> this.GetPropertiesString();

		#endregion
	}
}
