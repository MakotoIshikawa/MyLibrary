using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace CommonFeaturesLibrary.Extensions {
	/// <summary>
	/// CSV ファイルにアクセスする拡張メソッドを提供するクラスです。
	/// </summary>
	public static partial class CsvReaderExtension {
		#region メソッド

		/// <summary>
		/// CSV ファイルのデータを取り込んだデータテーブルを取得します。
		/// </summary>
		/// <param name="this">FileInfo</param>
		/// <returns>CSV ファイルのデータを取り込んだ DataTable を返します。</returns>
		public static DataTable GetCsvTable(this FileInfo @this) {
			using (var csv = new CsvReader(@this)) {
				return csv.ToDataTable(@this.Name);
			}
		}

		/// <summary>
		/// CSV ファイルのデータを取り込んだデータテーブルを取得します。
		/// </summary>
		/// <param name="this">Stream</param>
		/// <param name="tableName">テーブル名</param>
		/// <returns>CSV ファイルのデータを取り込んだ DataTable を返します。</returns>
		public static DataTable GetCsvTable(this Stream @this, string tableName) {
			using (var csv = new CsvReader(@this)) {
				return csv.ToDataTable(tableName);
			}
		}

		/// <summary>
		/// CSV ファイルのデータを取り込んだデータテーブルを取得します。
		/// </summary>
		/// <param name="this">FileInfo</param>
		/// <returns>CSV ファイルのデータを取り込んだ DataTable を返します。</returns>
		public static async Task<DataTable> GetCsvTableAsync(this FileInfo @this) {
			using (var csv = new CsvReader(@this)) {
				return await csv.ToDataTableAsync(@this.Name);
			}
		}

		/// <summary>
		/// CSV ファイルのデータを取り込んだデータテーブルを取得します。
		/// </summary>
		/// <param name="this">Stream</param>
		/// <param name="tableName">テーブル名</param>
		/// <returns>CSV ファイルのデータを取り込んだ DataTable を返します。</returns>
		public static async Task<DataTable> GetCsvTableAsync(this Stream @this, string tableName) {
			using (var csv = new CsvReader(@this)) {
				return await csv.ToDataTableAsync(tableName);
			}
		}

		#endregion
	}
}
