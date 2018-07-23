using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Enum を拡張するメソッドを提供します。
	/// </summary>
	public static partial class EnumExtension {
		#region メソッド

		#region 列挙型変換

		#region ToEnum

		/// <summary>
		/// 文字列を列挙型に変換します。
		/// </summary>
		/// <typeparam name="TResult">列挙型</typeparam>
		/// <param name="this">文字列</param>
		/// <param name="defaultValue">デフォルト値</param>
		/// <returns>列挙型を返します。</returns>
		public static TResult ToEnum<TResult>(this string @this, TResult? defaultValue = null) where TResult : struct {
			try {
				if (@this.IsEmpty()) {
					throw new ArgumentException("指定された文字列が null または Empty です。", nameof(@this));
				}

				return (TResult)Enum.Parse(typeof(TResult), @this);
			} catch (Exception ex) {
				if (!defaultValue.HasValue) {
					throw ex;
				}

				return defaultValue.Value;
			}
		}

		/// <summary>
		/// 文字列を列挙型に変換します。
		/// </summary>
		/// <typeparam name="TResult">列挙型</typeparam>
		/// <param name="this">文字列</param>
		/// <param name="ignoreCase">大文字と小文字を区別しない場合は true。大文字と小文字を区別する場合は false。</param>
		/// <param name="defaultValue">デフォルト値</param>
		/// <returns>列挙型を返します。</returns>
		public static TResult ToEnum<TResult>(this string @this, bool ignoreCase, TResult? defaultValue = null) where TResult : struct {
			try {
				if (@this.IsEmpty()) {
					throw new ArgumentException("指定された文字列が null または Empty です。", nameof(@this));
				}

				return (TResult)Enum.Parse(typeof(TResult), @this, ignoreCase);
			} catch (Exception ex) {
				if (!defaultValue.HasValue) {
					throw ex;
				}

				return defaultValue.Value;
			}
		}

		/// <summary>
		/// 数値(byte)を列挙型に変換します。
		/// </summary>
		/// <typeparam name="TResult">列挙型</typeparam>
		/// <param name="this">数値(byte)</param>
		/// <returns>列挙型を返します。</returns>
		public static TResult ToEnum<TResult>(this byte @this) where TResult : struct
			=> (TResult)Enum.ToObject(typeof(TResult), @this);

		/// <summary>
		/// 数値(short)を列挙型に変換します。
		/// </summary>
		/// <typeparam name="TResult">列挙型</typeparam>
		/// <param name="this">数値(short)</param>
		/// <returns>列挙型を返します。</returns>
		public static TResult ToEnum<TResult>(this short @this) where TResult : struct
			=> (TResult)Enum.ToObject(typeof(TResult), @this);

		/// <summary>
		/// 数値(int)を列挙型に変換します。
		/// </summary>
		/// <typeparam name="TResult">列挙型</typeparam>
		/// <param name="this">数値(int)</param>
		/// <returns>列挙型を返します。</returns>
		public static TResult ToEnum<TResult>(this int @this) where TResult : struct
			=> (TResult)Enum.ToObject(typeof(TResult), @this);

		/// <summary>
		/// 数値(long)を列挙型に変換します。
		/// </summary>
		/// <typeparam name="TResult">列挙型</typeparam>
		/// <param name="this">数値(long)</param>
		/// <returns>列挙型を返します。</returns>
		public static TResult ToEnum<TResult>(this long @this) where TResult : struct
			=> (TResult)Enum.ToObject(typeof(TResult), @this);

		#endregion

		#region 数値変換

		/// <summary>
		/// 16 ビット符号付き整数に変換します。
		/// </summary>
		/// <typeparam name="TEnum">列挙体の型</typeparam>
		/// <param name="this">列挙体</param>
		/// <returns>16 ビット符号付き整数を返します。値が null の場合は 0 を返します。</returns>
		public static short ToInt16<TEnum>(this TEnum @this) where TEnum : struct
			=> Convert.ToInt16(@this);

		/// <summary>
		/// 32 ビット符号付き整数に変換します。
		/// </summary>
		/// <typeparam name="TEnum">列挙体の型</typeparam>
		/// <param name="this">列挙体</param>
		/// <returns>32 ビット符号付き整数を返します。値が null の場合は 0 を返します。</returns>
		public static int ToInt32<TEnum>(this TEnum @this) where TEnum : struct
			=> Convert.ToInt32(@this);

		/// <summary>
		/// 64 ビット符号付き整数に変換します。
		/// </summary>
		/// <typeparam name="TEnum">列挙体の型</typeparam>
		/// <param name="this">列挙体</param>
		/// <returns>64 ビット符号付き整数を返します。値が null の場合は 0 を返します。</returns>
		public static long ToInt64<TEnum>(this TEnum @this) where TEnum : struct
			=> Convert.ToInt64(@this);

		#endregion

		/// <summary>
		/// Dictionary に変換します。
		/// </summary>
		/// <typeparam name="TEnum">列挙体の型</typeparam>
		/// <returns>Dictionary を返します。</returns>
		public static Dictionary<TEnum, int> ToDictionary<TEnum>() where TEnum : struct {
			var ls = GetEnumValues<TEnum>();
			return ls.ToDictionary(f => f, f => f.ToInt32());
		}

		/// <summary>
		/// 列挙体に含まれている定数の値の配列を取得します。
		/// </summary>
		/// <typeparam name="TEnum">列挙体の型</typeparam>
		/// <returns>定数の値を格納する配列を取得します。</returns>
		public static IEnumerable<TEnum> GetEnumValues<TEnum>() where TEnum : struct
			=> Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

		#endregion

		#endregion
	}
}
