using System;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Nullable 型を拡張するメソッドを提供します。
	/// </summary>
	public static partial class NullableExtension {
		#region メソッド

		#region Nullable 値変換

		/// <summary>
		/// オブジェクトのインスタンスを Nullable 型に変換します。
		/// </summary>
		/// <typeparam name="T">元となるオブジェクトの型</typeparam>
		/// <typeparam name="TResult">変換する Nullable 値の型</typeparam>
		/// <param name="this">object</param>
		/// <param name="convert">変換関数</param>
		/// <returns>Nullable 値を返します。</returns>
		public static TResult? ToNullable<T, TResult>(this T @this, Func<T, TResult> convert) where TResult : struct {
			if (@this == null) {
				return null;
			}

			try {
				return convert?.Invoke(@this);
			} catch {
				return null;
			}
		}

		#region short? に変換

		/// <summary>
		/// short? 型に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Nullable 値に変換した値を返します。</returns>
		public static short? ToNullableShort(this string @this) {
			short result;
			if (short.TryParse(@this, out result)) {
				return result;
			}
			return null;
		}

		#endregion

		#region int? に変換

		/// <summary>
		/// int? 型に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Nullable 値に変換した値を返します。</returns>
		public static int? ToNullableInt(this string @this) {
			int result;
			if (int.TryParse(@this, out result)) {
				return result;
			}
			return null;
		}

		#endregion

		#region long? に変換

		/// <summary>
		/// long? 型に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Nullable 値に変換した値を返します。</returns>
		public static long? ToNullableLong(this string @this) {
			long result;
			if (long.TryParse(@this, out result)) {
				return result;
			}
			return null;
		}

		#endregion

		#region uint? に変換

		/// <summary>
		/// uint? 型に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Nullable 値に変換した値を返します。</returns>
		public static uint? ToNullableUint(this string @this) {
			uint result;
			if (uint.TryParse(@this, out result)) {
				return result;
			}
			return null;
		}

		#endregion

		#region float? に変換

		/// <summary>
		/// float? 型に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Nullable 値に変換した値を返します。</returns>
		public static float? ToNullableFloat(this string @this) {
			float result;
			if (float.TryParse(@this, out result)) {
				return result;
			}
			return null;
		}

		#endregion

		#region double? に変換

		/// <summary>
		/// double? 型に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Nullable 値に変換した値を返します。</returns>
		public static double? ToNullableDouble(this string @this) {
			double result;
			if (double.TryParse(@this, out result)) {
				return result;
			}
			return null;
		}

		#endregion

		#region decimal? に変換

		/// <summary>
		/// decimal? 型に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Nullable 値に変換した値を返します。</returns>
		public static decimal? ToNullableDecimal(this string @this) {
			decimal result;
			if (decimal.TryParse(@this, out result)) {
				return result;
			}
			return null;
		}

		#endregion

		#region bool? に変換

		/// <summary>
		/// bool? 型に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Nullable 値に変換した値を返します。</returns>
		public static bool? ToNullableBool(this string @this) {
			bool result;
			if (bool.TryParse(@this, out result)) {
				return result;
			}
			return null;
		}

		#endregion

		#endregion

		#endregion
	}
}
