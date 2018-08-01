using System;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// TimeSpan を拡張するメソッドを提供します。
	/// </summary>
	public static partial class TimeSpanExtension {
		#region メソッド

		#region 文字列変換

		/// <summary>
		/// 時分 (HH:mm) 文字列に変換します。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <returns>時分 (HH:mm) 文字列を返します。</returns>
		public static string ToHourAndMinString(this TimeSpan @this)
			=> $"{@this.Days * 24 + @this.Hours:00}:{@this.Minutes:00}";

		/// <summary>
		/// ミリ秒まで表示する時刻文字列に変換します。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <returns>ミリ秒まで表示する時刻文字列を返します。</returns>
		public static string ToMilliSecondString(this TimeSpan @this)
			=> @this.ToHourAndMinString() + $":{@this.Seconds:00}.{@this.Milliseconds}";

		#endregion

		#endregion
	}
}
