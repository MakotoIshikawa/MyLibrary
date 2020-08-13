using System.Runtime.CompilerServices;

namespace ExtensionsLibraryTests.Models {
	/// <summary>
	/// インデクサーの名前を変更したテストクラス。
	/// </summary>
	public class TestOfIndexer {
		/// <summary>
		/// インデクサー
		/// </summary>
		/// <param name="index">インデックス</param>
		/// <returns>インデックスを返す。</returns>
		[IndexerName("Indexer")]
		public int this[int index]
			=> index;

		/// <summary>
		/// インデクサー
		/// </summary>
		/// <param name="row">行</param>
		/// <param name="col">列</param>
		/// <returns>行列の個数を返す。</returns>
		[IndexerName("Indexer")]
		public int this[int row, int col]
			=> row * col;

		/// <summary>
		/// 名前
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// ID
		/// </summary>
		public static string ID => "12345";
	}
}