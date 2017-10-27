using System;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// 数値関数の拡張メソッドを提供します。
	/// </summary>
	public static partial class MathExtension {
		#region メソッド

		#region WithinRange

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static short WithinRange(this short value, short min, short max)
			=> Math.Min(max, Math.Max(min, value));

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static ushort WithinRange(this ushort value, ushort min, ushort max)
			=> Math.Min(max, Math.Max(min, value));

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static int WithinRange(this int value, int min, int max)
			=> Math.Min(max, Math.Max(min, value));

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static uint WithinRange(this uint value, uint min, uint max)
			=> Math.Min(max, Math.Max(min, value));

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static long WithinRange(this long value, long min, long max)
			=> Math.Min(max, Math.Max(min, value));

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static ulong WithinRange(this ulong value, ulong min, ulong max)
			=> Math.Min(max, Math.Max(min, value));

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static float WithinRange(this float value, float min, float max)
			=> Math.Min(max, Math.Max(min, value));

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static double WithinRange(this double value, double min, double max)
			=> Math.Min(max, Math.Max(min, value));

		/// <summary>
		/// 上限と下限を設定して、範囲内の値を取得します。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="min">下限値</param>
		/// <param name="max">上限値</param>
		/// <returns>範囲内の値を返します。</returns>
		public static decimal WithinRange(this decimal value, decimal min, decimal max)
			=> Math.Min(max, Math.Max(min, value));

		#endregion

		#endregion
	}
}
