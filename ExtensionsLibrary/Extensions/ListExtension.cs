using System.Linq;
using System.Collections.Generic;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// ジェネリックの List を拡張するメソッドを提供します。
	/// </summary>
	public static class ListExtension {
		#region メソッド

		#region 先頭要素追加

		/// <summary>
		/// 先頭に要素を追加します。
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="this">リスト</param>
		/// <param name="item">要素</param>
		public static void Prepend<T>(this List<T> @this, T item)
			=> @this.Insert(0, item);

		#endregion

		#region 文字列コレクションの変換

		/// <summary>
		/// 文字列のコレクションの要素を Trim してリストに変換します。
		/// </summary>
		/// <param name="this"></param>
		/// <returns>変換したリストを返します。</returns>
		public static List<string> ToListWithTrim(this IEnumerable<string> @this)
			=> @this?.Select(o => o.Trim())?.ToList() ?? Enumerable.Empty<string>().ToList();

		/// <summary>
		/// 空の文字列を削除するかどうかを指定して、配列に変換します。
		/// </summary>
		/// <param name="this">string のコレクション</param>
		/// <param name="removeEmptyEntries">空の文字列を削除するかどうか</param>
		/// <returns>変換した配列を返します。</returns>
		public static string[] ToArray(this IEnumerable<string> @this, bool removeEmptyEntries)
			=> removeEmptyEntries
				? @this.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray()
				: @this.ToArray();

		#endregion


		#endregion
	}
}
