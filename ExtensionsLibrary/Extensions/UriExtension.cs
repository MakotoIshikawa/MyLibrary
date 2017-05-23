using System;
using System.IO;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Uri クラスを拡張するメソッドを提供します。
	/// </summary>
	public static partial class UriExtension {
		#region メソッド

		/// <summary>
		/// URI パス文字列のファイル名と拡張子を返します。
		/// </summary>
		/// <param name="this">Uri</param>
		/// <returns>URI の最後のディレクトリ文字の後ろの文字を返します。</returns>
		public static string GetFileName(this Uri @this) {
			return Path.GetFileName(@this.OriginalString);
		}

		/// <summary>
		/// URI パス文字列のファイル名を拡張子を付けずに返します。
		/// </summary>
		/// <param name="this">Uri</param>
		/// <returns>URI の最後のディレクトリ文字の後ろの拡張子を除く文字を返します。</returns>
		public static string GetFileNameWithoutExtension(this Uri @this) {
			return Path.GetFileNameWithoutExtension(@this.OriginalString);
		}

		#region 拡張子判定

		/// <summary>
		/// イメージファイルかどうかを判定します。
		/// </summary>
		/// <param name="this">FileInfo</param>
		/// <returns>イメージファイルであれば true を返します。</returns>
		public static bool IsImage(this Uri @this) {
			return @this.ContainsAtExtension(
				"gif",
				"jpg", "jpeg", "jpe", "jfif",
				"png",
				"bmp", "dib", "rle",
				"tif", "tiff", "nsk",
				"cgm",
				"pct", "pic", "pict",
				"pcx",
				"ico"
			);
		}

		/// <summary>
		/// SharePoint の icon に対応しているファイルかどうかを判定します。
		/// </summary>
		/// <param name="this">FileInfo</param>
		/// <returns>SharePoint の icon に対応しているファイルであれば true を返します。</returns>
		public static bool IsSharePointIcon(this Uri @this) {
			return @this.ContainsAtExtension(
				"ASP", "ASPX",
				"CSS",
				"DOC", "DOCM", "DOCX",
				"GEN",
				"GIF",
				"HTM",
				"INI",
				"JPEG", "JPG",
				"JS",
				"LOG",
				"PDF",
				"PPT", "PPTM", "PPTX",
				"PUB",
				"RTF",
				"STP",
				"TIF", "TIFF",
				"TXT", "WMA",
				"XLS", "XLSM", "XLSX",
				"XML",
				"XPS",
				"XSD", "XSL",
				"ZIP"
			);
		}

		/// <summary>
		/// 拡張子を判定ます。
		/// </summary>
		/// <param name="this">FileInfo</param>
		/// <param name="exts">拡張子の配列</param>
		/// <returns>該当する拡張子があれば true を返します。それ以外は false</returns>
		public static bool ContainsAtExtension(this Uri @this, params string[] exts) {
			return @this?.GetFileName().ContainsAtExtension(exts) ?? false;
		}

		#endregion

		#endregion
	}
}
