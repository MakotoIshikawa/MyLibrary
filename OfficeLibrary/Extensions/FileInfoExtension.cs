using System.Data;
using System.IO;
using OfficeLibrary.Providers.Csv;

namespace OfficeLibrary.Extensions {
	/// <summary>
	/// FileInfo を拡張するメソッドを提供します。
	/// </summary>
	public static partial class FileInfoExtension {
		#region メソッド

		#region LoadDataTable

		/// <summary>
		/// CSV ファイルからデータを読み込みます。
		/// </summary>
		/// <param name="file"></param>
		/// <returns>読み込んだデータテーブルを返します。</returns>
		public static DataTable LoadDataTable(this FileInfo file) {
			var csv = new CsvConnection(file);

			var table = new DataTable();
			csv.Connect(a => a.Fill(table));
			return table;
		}

		#endregion

		#endregion
	}
}
