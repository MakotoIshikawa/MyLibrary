using ExtensionsLibrary.Extensions;

namespace LuisLibrary.Data {
	/// <summary>
	/// エンティティ
	/// </summary>
	public class Entity {
		#region プロパティ

		/// <summary>
		/// エンティティ
		/// </summary>
		public string entity { get; set; }

		/// <summary>
		/// タイプ
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// 開始インデックス
		/// </summary>
		public int startIndex { get; set; }

		/// <summary>
		/// 終了インデックス
		/// </summary>
		public int endIndex { get; set; }

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
