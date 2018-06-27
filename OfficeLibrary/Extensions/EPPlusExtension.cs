using OfficeOpenXml;

namespace OfficeLibrary.Extensions {
	/// <summary>
	/// EPPlus を拡張するメソッドを提供します。
	/// </summary>
	public static partial class EPPlusExtension {
		#region メソッド

		/// <summary>
		/// ワークシートのコレクションに
		/// 新規シートを追加します。
		/// </summary>
		/// <param name="this">ワークシートのコレクション</param>
		/// <returns>追加したシートを返します。</returns>
		public static ExcelWorksheet Add(this ExcelWorksheets @this)
			=> @this.Add($"Sheet{@this.Count + 1}");

		/// <summary>
		/// ワークブックに
		/// 新規シートを追加します。
		/// </summary>
		/// <param name="this">ワークブック</param>
		/// <returns>追加したシートを返します。</returns>
		public static ExcelWorksheet Add(this ExcelWorkbook @this)
			=> @this?.Worksheets?.Add();

		/// <summary>
		/// シート名を指定して、ワークブックに
		/// 新規シートを追加します。
		/// </summary>
		/// <param name="this">ワークブック</param>
		/// <param name="name">シート名</param>
		/// <returns>追加したシートを返します。</returns>
		public static ExcelWorksheet Add(this ExcelWorkbook @this, string name)
			=> @this?.Worksheets?.Add(name);

		#endregion
	}
}
