using System;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// DateTime を拡張するメソッドを提供します。
	/// </summary>
	public static partial class DateTimeExtension {
		#region メソッド

		#region 日付判定

		/// <summary>
		/// 日付情報かどうかを表します。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <returns>日付情報かどうかを返します。</returns>
		public static bool IsDay(this DateTime @this)
			=> (@this.TimeOfDay.TotalMilliseconds == 0);

		#endregion

		#region 文字列変換

		/// <summary>
		/// ミリ秒まで表示する時刻文字列に変換します。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <returns>ミリ秒まで表示する時刻文字列を返します。</returns>
		public static string ToMilliSecondString(this DateTime @this)
			=> @this.ToString("yyyy/MM/dd HH':'mm':'ss.fff");

		#endregion

		#region 月日数取得

		/// <summary>
		/// 該当年月の日数を取得します。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <returns>該当年月の日数を返します。</returns>
		public static int DaysInMonth(this DateTime @this)
			=> DateTime.DaysInMonth(@this.Year, @this.Month);

		#endregion

		#region 月初日取得

		/// <summary>
		/// 月初日を返す
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <returns>月初の日付を返します。</returns>
		public static DateTime GetBeginOfMonth(this DateTime @this)
			=> @this.AddDays((@this.Day - 1) * -1);

		#endregion

		#region 月末日取得

		/// <summary>
		/// 月末の日付を取得します。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <returns>月末の日付を返します。</returns>
		public static DateTime GetEndOfMonth(this DateTime @this)
			=> new DateTime(@this.Year, @this.Month, @this.DaysInMonth());

		#endregion

		#region 日付取得

		/// <summary>
		/// 時刻を落として日付のみにする
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <returns>日付のみの DateTime を返します。</returns>
		public static DateTime StripTime(this DateTime @this)
			=> new DateTime(@this.Year, @this.Month, @this.Day);

		#endregion

		#region 時刻取得

		/// <summary>
		/// 日付を落として時刻のみにする
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <param name="base_date">基準日</param>
		/// <returns>時刻のみの DateTime を返します。</returns>
		public static DateTime StripDate(this DateTime @this, DateTime? base_date = null) {
			base_date = base_date ?? DateTime.MinValue;
			return new DateTime(base_date.Value.Year, base_date.Value.Month, base_date.Value.Day, @this.Hour, @this.Minute, @this.Second);
		}

		#endregion

		#region 年度取得

		/// <summary>
		/// 該当日付の年度を取得する。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <param name="startingMonth">年度の開始月</param>
		/// <returns>該当日付の年度を返します。</returns>
		public static int GetFiscalYear(this DateTime @this, int startingMonth = 4)
			=> (@this.Month >= startingMonth)
				? @this.Year
				: @this.Year - 1;

		#endregion

		#region 切り上げ

		/// <summary>
		/// 指定した間隔(分)で、
		/// DateTime 値を切り上げます。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <param name="interval">間隔(分)</param>
		/// <returns>切り上げた値を返します。</returns>
		public static DateTime RoundUpAtMinute(this DateTime @this, double interval)
			=> @this.RoundUp(TimeSpan.FromMinutes(interval));

		/// <summary>
		/// 指定した間隔で、
		/// DateTime 値を切り上げます。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <param name="interval">間隔</param>
		/// <returns>切り上げた値を返します。</returns>
		public static DateTime RoundUp(this DateTime @this, TimeSpan interval)
			=> new DateTime(((@this.Ticks + interval.Ticks - 1) / interval.Ticks) * interval.Ticks, @this.Kind);

		#endregion

		#region 切り捨て

		/// <summary>
		/// 指定した間隔(分)で、
		/// DateTime 値を切り捨てます。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <param name="interval">間隔(分)</param>
		/// <returns>切り捨てた値を返します。</returns>
		public static DateTime RoundDownAtMinute(this DateTime @this, double interval)
			=> @this.RoundDown(TimeSpan.FromMinutes(interval));

		/// <summary>
		/// 指定した間隔で、
		/// DateTime 値を切り捨てます。
		/// </summary>
		/// <param name="this">DateTime</param>
		/// <param name="interval">間隔</param>
		/// <returns>切り捨てた値を返します。</returns>
		public static DateTime RoundDown(this DateTime @this, TimeSpan interval)
			=> new DateTime((((@this.Ticks + interval.Ticks) / interval.Ticks) - 1) * interval.Ticks, @this.Kind);

		#endregion

		#endregion
	}
}
