﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// 文字列を補助する拡張メソッドを提供します。
	/// </summary>
	public static partial class StringExtension {
		#region メソッド

		#region 時刻ログ取得

		/// <summary>
		/// 時刻ログを取得します。
		/// </summary>
		/// <param name="this">メッセージ</param>
		/// <remarks>
		/// 時刻を付加した文字列を取得します。</remarks>
		public static string GetTimeLog(this string @this) {
			var milliSecond = DateTime.Now.ToMilliSecondString();
			return $"{milliSecond} {@this}";
		}

		#endregion

		#region 文字列判定

		/// <summary>
		/// 指定された文字列が存在するかどうかを示します。
		/// </summary>
		/// <param name="this">テストする文字列。</param>
		/// <param name="word">検索する文字列</param>
		/// <returns>その文字列が見つかった場合は、true。
		/// 見つからなかった場合は false。</returns>
		public static bool HasString(this string @this, string word) {
			if (@this.IsEmpty() || word.IsEmpty()) {
				return false;
			}

			return !(@this.IndexOf(word) < 0);
		}

		/// <summary>
		/// 指定したワードの配列を全て含んでいるかどうか判定します。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="words">ワードの配列</param>
		/// <returns>全てのワードを含んでいる場合は、true を返します。</returns>
		public static bool MatchWords(this string @this, params string[] words)
			=> words.All(s => @this.HasString(s));

		#endregion

		#region コメントアウト

		/// <summary>
		/// 文字列から指定された記号以降の文字列をコメントアウトします。
		/// </summary>
		/// <param name="this">対象文字列</param>
		/// <param name="sign">記号</param>
		/// <returns>コメントアウトされた文字列を返します。</returns>
		public static string CommentOut(this string @this, string sign) {
			if (sign.IsEmpty()) {
				return @this;
			}

			var index = @this.IndexOf(sign);
			if (index != -1) {
				@this = @this.Remove(index);
			}

			return @this.TrimEnd();
		}

		#endregion

		#region 繰り返し文字列生成

		/// <summary>
		/// 繰り返し文字列生成
		/// </summary>
		/// <param name="this">文字列</param>
		/// <param name="repeat">個数</param>
		/// <returns>生成文字列</returns>
		public static string Repeat(this string @this, int repeat) {
			if (@this.IsEmpty()) {
				return @this;
			}

			return Enumerable.Repeat(@this, repeat).Join();
		}

		/// <summary>
		/// 繰り返し文字列生成
		/// </summary>
		/// <param name="this">文字列</param>
		/// <param name="repeat">個数</param>
		/// <returns>生成文字列</returns>
		public static string Repeat(this char @this, int repeat) {
			if (@this == char.MinValue) {
				return string.Empty;
			}

			return Enumerable.Repeat(@this, repeat).Join();
		}

		#endregion

		#region Stream生成

		/// <summary>
		/// MemoryStream を生成します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <param name="encoding">エンコーディング</param>
		/// <returns>MemoryStream の新しいインスタンスを返します。</returns>
		public static MemoryStream CreateStream(this string @this, Encoding encoding)
			=> new MemoryStream(encoding.GetBytes(@this));

		#endregion

		#region 空文字判定

		/// <summary>
		/// 指定された文字列が null または System.String.Empty 文字列であるかどうかを示します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>null または空の文字列 ("") の場合は true。
		/// それ以外の場合は false。</returns>
		public static bool IsEmpty(this string @this)
			=> string.IsNullOrEmpty(@this);

		/// <summary>
		/// 指定された文字列が null または空であるか、空白文字だけで構成されているかどうかを示します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>null または または空の文字列 ("") であるか、空白文字だけで構成されている場合は true。
		/// それ以外の場合は false。</returns>
		public static bool IsWhiteSpace(this string @this)
			=> string.IsNullOrWhiteSpace(@this);

		#endregion

		#region 文字列連結

		/// <summary>
		/// String コレクションのメンバーを連結します。各メンバーの間には、指定した区切り記号が挿入されます。
		/// </summary>
		/// <param name="this">連結する文字列を格納しているコレクション</param>
		/// <param name="separator">区切り記号として使用する文字列</param>
		/// <returns>separator 文字列で区切られた文字列を返します。</returns>
		public static string Join(this IEnumerable<string> @this, string separator = null) {
			if (!(@this?.Any() ?? false)) {
				return null;
			}

			return string.Join(separator, @this);
		}

		#endregion

		#region Base64 変換

		/// <summary>
		/// Base64 の数字でエンコードされた等価の文字列形式に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>Base64 の数字でエンコードされた文字列を返します。</returns>
		public static string ToBase64(this string @this)
			=> @this.ToBase64(Encoding.UTF8);

		/// <summary>
		/// エンコードを指定して、
		/// Base64 の数字でエンコードされた等価の文字列形式に変換します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <param name="enc">エンコード</param>
		/// <returns>Base64 の数字でエンコードされた文字列を返します。</returns>
		public static string ToBase64(this string @this, Encoding enc) {
			if (@this.IsEmpty()) {
				return string.Empty;
			}

			return Convert.ToBase64String(enc.GetBytes(@this));
		}

		/// <summary>
		/// Base64 の数字でエンコードされた文字列から文字列に変換します。
		/// </summary>
		/// <param name="this">Base64 数字エンコード文字列</param>
		/// <returns>変換された文字列を返します。</returns>
		public static string FromBase64(this string @this)
			=> @this.FromBase64(Encoding.UTF8);

		/// <summary>
		/// エンコードを指定して、
		/// Base64 の数字でエンコードされた文字列から文字列に変換します。
		/// </summary>
		/// <param name="this">Base64 数字エンコード文字列</param>
		/// <param name="enc">エンコード</param>
		/// <returns>変換された文字列を返します。</returns>
		public static string FromBase64(this string @this, Encoding enc) {
			if (@this.IsEmpty()) {
				return string.Empty;
			}

			return enc.GetString(Convert.FromBase64String(@this));
		}

		#endregion

		#region 値取得

		/// <summary>
		/// null かどうかを判定して文字列を取得します。
		/// </summary>
		/// <param name="this">文字列</param>
		/// <returns>null 場合 string.Empty を返します。</returns>
		public static string GetValueOrEmpty(this string @this)
			=> @this ?? string.Empty;

		#endregion

		#region 切り出し

		/// <summary>
		/// 文字列の左端から指定された文字数分の文字列を取得します。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="length">取り出す文字数</param>
		/// <returns>取り出した文字列を返します。</returns>
		public static string Left(this string @this, int length)
			=> (new string(@this.Take(length).ToArray())).TrimEnd();

		/// <summary>
		/// 指定された位置から文字列を取得します。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="start">開始位置</param>
		/// <returns>取り出した文字列を返します。</returns>
		public static string Mid(this string @this, int start)
			=> (new string(@this.Skip(start - 1).ToArray())).TrimEnd();

		/// <summary>
		/// 指定された位置から、指定された文字数分の文字列を取得します。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="start">開始位置</param>
		/// <param name="length">取り出す文字数</param>
		/// <returns>取り出した文字列を返します。</returns>
		public static string Mid(this string @this, int start, int length)
			=> (new string(@this.Skip(start - 1).Take(length).ToArray())).TrimEnd();

		/// <summary>
		/// 文字列の右端から指定された文字数分の文字列を取得します。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="length">取り出す文字数</param>
		/// <returns>取り出した文字列を返します。</returns>
		public static string Right(this string @this, int length) {
			var cnt = @this.Length - length;
			return (new string(@this.Skip(cnt).ToArray())).Trim();
		}

		#endregion

		#region 時刻変換

		/// <summary>
		/// 文字列を DateTime に変換します。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="format">書式</param>
		/// <returns>DateTime を返します。</returns>
		public static DateTime? ToDateTime(this string @this, string format = null) {
			if (format.IsEmpty()) {
				if (!DateTime.TryParse(@this, out var result)) {
					return null;
				}
				return result;
			} else {
				if (!DateTime.TryParseExact(@this, format, null, DateTimeStyles.None, out var result)) {
					return null;
				}
				return result;
			}
		}

		/// <summary>
		/// 文字列を TimeSpan に変換します。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="format">書式</param>
		/// <returns>TimeSpan を返します。</returns>
		public static TimeSpan? ToTimeSpan(this string @this, string format = null) {
			if (format.IsEmpty()) {
				if (!TimeSpan.TryParse(@this, out var result)) {
					return null;
				}
				return result;
			} else {
				if (!TimeSpan.TryParseExact(@this, format, null, TimeSpanStyles.None, out var result)) {
					return null;
				}
				return result;
			}
		}

		#endregion

		#region ファイルパス判定

		/// <summary>
		/// 指定したファイルパス文字列の
		/// 拡張子を判定ます。
		/// </summary>
		/// <param name="this">ファイル名</param>
		/// <param name="exts">拡張子の配列</param>
		/// <returns>該当する拡張子があれば true を返します。それ以外は false</returns>
		public static bool ContainsAtExtension(this string @this, params string[] exts) {
			if (@this.IsEmpty()) {
				return false;
			}

			if (!(exts?.Any() ?? false)) {
				return false;
			}

			var gp = exts.Join("|");
			var rx = new Regex($@"\.({gp})$", RegexOptions.IgnoreCase);
			return rx.IsMatch(@this);
		}

		#endregion

		#region Split

		/// <summary>
		/// 配列内の文字列に基づいて文字列を部分文字列に分割します。
		/// 部分文字列が空の配列の要素を含めるかどうかを指定することができます。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="removeEmpty"><para>空の配列要素を省略する場合は true</para>
		/// <para>空の配列要素も含める場合は false</para></param>
		/// <param name="separator">この文字列から部分文字列を取り出すために区切り文字として使用する文字列配列。
		/// <para>区切り文字が含まれていない空の配列。または null。</para></param>
		/// <returns>この文字列を、separator 配列のいずれかまたは複数の要素 (文字列) で区切ることによって取り出された部分文字列を格納する配列。</returns>
		public static string[] Split(this string @this, bool removeEmpty, params string[] separator)
			=> @this.Split(separator, removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);

		#endregion

		#region 省略

		/// <summary>
		/// 指定した桁数を超える場合に、文字列を省略します。
		/// </summary>
		/// <param name="this">string</param>
		/// <param name="digits">桁数</param>
		/// <param name="suffixes">接尾辞</param>
		/// <returns>省略した文字列を返します。</returns>
		public static string OmitGreaterThan(this string @this, int digits = 100, string suffixes = "...") {
			if (@this.IsWhiteSpace()) {
				return string.Empty;
			}

			var ret = @this.Left(digits);

			return @this.Length > digits ? ret + suffixes : ret;
		}

		#endregion

		#endregion
	}
}