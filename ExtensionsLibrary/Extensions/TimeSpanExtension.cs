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
			=> $"{@this.Days * 24 + @this.Hours}:{@this.Minutes}";

		#endregion
		
		#endregion
	}
}
