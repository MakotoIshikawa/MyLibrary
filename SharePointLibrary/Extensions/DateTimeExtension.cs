using System;
using Microsoft.SharePoint.Utilities;

namespace SharePointLibrary.Extensions {
	/// <summary>
	/// DateTime を拡張するメソッドを提供します。
	/// </summary>
	public static partial class DateTimeExtension {
		#region メソッド

		/// <summary>
		/// DateTime 値を ISO8601 の DateTime 書式（yyyy-mm-ddThh:mm:ssZ）の文字列に変換します。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <returns>ISO8601 DateTime 形式の日付と時刻を含む文字列を返します。</returns>
		/// <remarks>CAML の検索条件に使用する文字列に変換します。</remarks>
		public static string ToCamlString(this DateTime @this)
			=> SPUtility.CreateISO8601DateTimeFromSystemDateTime(@this);

		/// <summary>
		/// DateTime 値を ISO8601 の DateTime 書式（yyyy-mm-ddThh:mm:ssZ）の文字列に変換します。
		/// </summary>
		/// <param name="this">DateTime?</param>
		/// <returns>ISO8601 DateTime 形式の日付と時刻を含む文字列を返します。</returns>
		/// <remarks>CAML の検索条件に使用する文字列に変換します。</remarks>
		public static string ToCamlString(this DateTime? @this)
			=> @this.HasValue
				? @this.Value.ToCamlString()
				: string.Empty;

		#endregion
	}
}
