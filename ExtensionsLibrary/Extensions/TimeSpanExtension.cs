using System;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// TimeSpan を拡張するメソッドを提供します。
	/// </summary>
	public static partial class TimeSpanExtension {
		#region メソッド

		#region [時]値取得

		/// <summary>
		/// 日数も考慮し、
		/// 時分 (HH:mm) の[時]部分の値を取得します。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <returns>[時]部分の値を返します。</returns>
		public static int GetHours(this TimeSpan @this)
			=> @this.Days * 24 + @this.Hours;

		#endregion

		#region 文字列変換

		/// <summary>
		/// 時分 (HH:mm) 文字列に変換します。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <returns>時分 (HH:mm) 文字列を返します。</returns>
		public static string ToHourAndMinString(this TimeSpan @this)
			=> $"{@this.GetHours():00}:{@this.Minutes:00}";

		/// <summary>
		/// 秒まで表示する時刻文字列に変換します。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <returns>秒まで表示する時刻文字列を返します。</returns>
		public static string ToSecondString(this TimeSpan @this)
			=> @this.ToHourAndMinString() + $":{@this.Seconds:00}";

		/// <summary>
		/// ミリ秒まで表示する時刻文字列に変換します。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <returns>ミリ秒まで表示する時刻文字列を返します。</returns>
		public static string ToMilliSecondString(this TimeSpan @this)
			=> @this.ToSecondString() + $".{@this.Milliseconds:000}";

		#endregion

		#region 切り上げ

		/// <summary>
		/// 指定した間隔(分)で、
		/// TimeSpan 値を切り上げます。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <param name="interval">間隔(分)</param>
		/// <returns>切り上げた値を返します。</returns>
		public static TimeSpan RoundUpAtMinute(this TimeSpan @this, double interval)
			=> @this.RoundUp(TimeSpan.FromMinutes(interval));

		/// <summary>
		/// 指定した間隔で、
		/// TimeSpan 値を切り上げます。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <param name="interval">間隔</param>
		/// <returns>切り上げた値を返します。</returns>
		public static TimeSpan RoundUp(this TimeSpan @this, TimeSpan interval)
			=> new TimeSpan(((@this.Ticks + interval.Ticks - 1) / interval.Ticks) * interval.Ticks);

		#endregion

		#region 切り捨て

		/// <summary>
		/// 指定した間隔(分)で、
		/// TimeSpan 値を切り捨てます。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <param name="interval">間隔(分)</param>
		/// <returns>切り捨てた値を返します。</returns>
		public static TimeSpan RoundDownAtMinute(this TimeSpan @this, double interval)
			=> @this.RoundDown(TimeSpan.FromMinutes(interval));

		/// <summary>
		/// 指定した間隔で、
		/// TimeSpan 値を切り捨てます。
		/// </summary>
		/// <param name="this">TimeSpan</param>
		/// <param name="interval">間隔</param>
		/// <returns>切り捨てた値を返します。</returns>
		public static TimeSpan RoundDown(this TimeSpan @this, TimeSpan interval)
			=> new TimeSpan((((@this.Ticks + interval.Ticks) / interval.Ticks) - 1) * interval.Ticks);

		#endregion

		#endregion
	}
}
