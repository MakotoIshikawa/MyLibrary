using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Enumerable を拡張するメソッドを提供します。
	/// </summary>
	public static partial class EnumerableExtension {
		#region ForEach (オーバーロード +3)

		/// <summary>
		/// ForEach
		/// </summary>
		/// <param name="this">Enumerable</param>
		/// <param name="action">メソッド</param>
		public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action) {
			foreach (T item in @this) {
				action(item);
			}
		}

		/// <summary>
		/// ForEach(中断可)
		/// </summary>
		/// <param name="this">Enumerable</param>
		/// <param name="func">戻り値を返すメソッド</param>
		public static void ForEach<T>(this IEnumerable<T> @this, Func<T, bool> func) {
			foreach (T item in @this) {
				if (!(func?.Invoke(item) ?? false)) {
					break;
				}
			}
		}

		/// <summary>
		/// ForEach(インデックス有)
		/// </summary>
		/// <param name="this">Enumerable</param>
		/// <param name="action">メソッド</param>
		public static void ForEach<T>(this IEnumerable<T> @this, Action<T, int> action) {
			var counter = 0;
			foreach (T item in @this) {
				action(item, counter++);
			}
		}

		/// <summary>
		/// ForEach(インデックス有、中断可)
		/// </summary>
		/// <param name="this">Enumerable</param>
		/// <param name="func">戻り値を返すメソッド</param>
		public static void ForEach<T>(this IEnumerable<T> @this, Func<T, int, bool> func) {
			var counter = 0;
			foreach (T item in @this) {
				if (!(func?.Invoke(item, counter++) ?? false)) {
					break;
				}
			}
		}

		#endregion

		#region コレクション追加

		/// <summary>
		/// シーケンスに追加します。
		/// </summary>
		/// <typeparam name="T">コレクションの型</typeparam>
		/// <param name="this">コレクション</param>
		/// <param name="items">追加する配列</param>
		/// <returns>追加したコレクションを返します。</returns>
		public static IEnumerable<T> Append<T>(this IEnumerable<T> @this, params T[] items)
			=> @this.Concat(items);

		/// <summary>
		/// シーケンスの先頭に挿入します。
		/// </summary>
		/// <typeparam name="T">コレクションの型</typeparam>
		/// <param name="this">コレクション</param>
		/// <param name="items">追加する配列</param>
		/// <returns>挿入したコレクションを返します。</returns>
		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> @this, params T[] items)
			=> items.Concat(@this);

		/// <summary>
		/// コレクションに要素のコレクションを追加します。
		/// </summary>
		/// <typeparam name="T">コレクションの型</typeparam>
		/// <param name="this">コレクション</param>
		/// <param name="elements">追加する要素のコレクション</param>
		/// <returns>追加したコレクションを返します。</returns>
		public static IEnumerable<T> AddRange<T>(this Collection<T> @this, IEnumerable<T> elements) {
			elements.ForEach(i => @this.Add(i));
			return @this;
		}

		#endregion

		#region Join (オーバーロード +1)

		/// <summary>
		/// コレクションのメンバーを連結します。各メンバーの間には、指定した区切り記号が挿入されます。
		/// </summary>
		/// <typeparam name="T">メンバーの型</typeparam>
		/// <param name="this">連結するオブジェクトを格納しているコレクション</param>
		/// <param name="separator">区切り記号として使用する文字列</param>
		/// <returns>values のメンバーから成る、separator 文字列で区切られた文字列。
		/// values にメンバーがない場合、メソッドは String.Emptyを返します。</returns>
		public static string Join<T>(this IEnumerable<T> @this, string separator = "") {
			return string.Join(separator, @this);
		}

		/// <summary>
		/// シーケンスを連結します。各メンバーの間には、指定した区切り記号が挿入されます。
		/// </summary>
		/// <typeparam name="TSource">source の要素の型</typeparam>
		/// <typeparam name="TResult">selector によって返される値の型</typeparam>
		/// <param name="this">変換関数を呼び出す対象となる値のシーケンス</param>
		/// <param name="selector">各要素に適用する変換関数</param>
		/// <param name="separator">区切り記号として使用する文字列</param>
		/// <returns>連結したシーケンスを返します。</returns>
		public static string Join<TSource, TResult>(this IEnumerable<TSource> @this, Func<TSource, TResult> selector, string separator = "") {
			return @this.Select(selector).Join(separator);
		}

		#endregion

		#region 行コレクション取得

		/// <summary>
		/// 指定した列数の行コレクションを取得します。
		/// </summary>
		/// <typeparam name="T">コレクションの型</typeparam>
		/// <param name="this">コレクション</param>
		/// <param name="count">列数</param>
		/// <returns>行コレクションを返します。</returns>
		public static IEnumerable<List<T>> GetRowItems<T>(this IEnumerable<T> @this, int count) {
			var cols = @this.Select((v, i) => new { Index = i, value = v, });

			var ls = new List<T>();

			foreach (var col in cols) {
				ls.Add(col.value);

				if (ls.Count == count) {
					yield return ls;

					ls = new List<T>();
				}
			}

			if (ls.Any()) {
				yield return ls;
			}
		}

		#endregion

		#region Distinct

		/// <summary>
		/// シーケンスから一意の要素を返します。
		/// </summary>
		/// <typeparam name="TSource">コレクション要素の型</typeparam>
		/// <typeparam name="TComparable">比較する値の型</typeparam>
		/// <param name="this">重複する要素を削除する対象となるシーケンス</param>
		/// <param name="compareSelector">比較する値を返すメソッド</param>
		/// <returns>ソース シーケンスの一意の要素を格納するコレクション</returns>
		public static IEnumerable<TSource> Distinct<TSource, TComparable>(this IEnumerable<TSource> @this, Func<TSource, TComparable> compareSelector) where TComparable : IComparable {
			return @this.Distinct(new CompareSelector<TSource, TComparable>(compareSelector));
		}

		#endregion

		#region ToDictionary (オーバーロード +6)

		/// <summary>
		/// 指定されたキー セレクター関数、比較関数、および要素セレクター関数に従って、
		/// IEnumerable(T) から Dictionary(TKey,TValue) を作成します。
		/// </summary>
		/// <typeparam name="TSource">source の要素の型。</typeparam>
		/// <typeparam name="TKey">keySelector によって返されるキーの型。</typeparam>
		/// <typeparam name="TElement">elementSelector によって返される値の型。</typeparam>
		/// <typeparam name="TComparable">キーを比較する型。</typeparam>
		/// <param name="this">Dictionary(TKey,TValue) の作成元の IEnumerable(T)。</param>
		/// <param name="keySelector">各要素からキーを抽出する関数。</param>
		/// <param name="elementSelector">各要素から結果の要素値を生成する変換関数。</param>
		/// <param name="compareSelector">比較する値を返す関数。</param>
		/// <returns>入力シーケンスから選択された TElement 型の値を格納する Dictionary(TKey,TValue)。</returns>
		/// <exception cref="ArgumentNullException">
		/// source、keySelector、または elementSelector が null です。
		/// または keySelector が null のキーを生成しています。</exception>
		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TComparable>(this IEnumerable<TSource> @this, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, TComparable> compareSelector) where TComparable : IComparable {
			var cmp = new CompareSelector<TKey, TComparable>(compareSelector);
			return @this.ToDictionary(keySelector, elementSelector, cmp);
		}

		/// <summary>
		/// 指定されたキー セレクター関数に従って、
		/// Dictionary を作成します。
		/// </summary>
		/// <typeparam name="TSource">source の要素の型</typeparam>
		/// <typeparam name="TKey">keySelector によって返されるキーの型</typeparam>
		/// <param name="this">作成元のコレクション</param>
		/// <param name="keySelector">各要素からキーを抽出する関数</param>
		/// <returns>キーと値を格納している Dictionary を返します。</returns>
		public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> @this, Func<TSource, int, TKey> keySelector) {
			return @this.Select((v, i) => new { Index = i, Value = v, }).ToDictionary(v => keySelector(v.Value, v.Index), v => v.Value);
		}

		/// <summary>
		/// 指定されたキー セレクター関数および要素セレクター関数に従って、
		/// Dictionary を作成します。
		/// </summary>
		/// <typeparam name="TSource">source の要素の型</typeparam>
		/// <typeparam name="TKey">keySelector によって返されるキーの型</typeparam>
		/// <typeparam name="TElement">elementSelector によって返される値の型</typeparam>
		/// <param name="this">作成元のコレクション</param>
		/// <param name="keySelector">各要素からキーを抽出する関数</param>
		/// <param name="elementSelector">各要素から結果の要素値を生成する変換関数</param>
		/// <returns>入力シーケンスから選択された TElement 型の値を格納する Dictionary を返します。</returns>
		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> @this, Func<TSource, int, TKey> keySelector, Func<TSource, int, TElement> elementSelector) {
			return @this.Select((v, i) => new { Index = i, Value = v, }).ToDictionary(v => keySelector(v.Value, v.Index), v => elementSelector(v.Value, v.Index));
		}

		/// <summary>
		/// 連想配列に変換します。
		/// </summary>
		/// <typeparam name="TKey">キーの型</typeparam>
		/// <typeparam name="TValue">値の型</typeparam>
		/// <param name="this">キー、値ペアのコレクション</param>
		/// <returns>変換した連想配列を返します。</returns>
		public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> @this) {
			return @this.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
		}

		#endregion

		#region 変換

		/// <summary>
		/// IEnumerable の要素を新しい ObjectArray 配列にコピーします。
		/// </summary>
		/// <typeparam name="T">ジェネリックの型</typeparam>
		/// <param name="this">列挙</param>
		/// <returns>
		/// IEnumerable の要素のコピーを格納する ObjectArray 配列。</returns>
		public static List<T> ToList<T>(this Array @this) {
			return @this.Cast<T>().ToList();
		}

		/// <summary>
		/// IEnumerable の要素を新しい System.Object 配列にコピーします。
		/// </summary>
		/// <typeparam name="T">ジェネリックの型</typeparam>
		/// <param name="this">列挙</param>
		/// <returns>
		/// IEnumerable の要素のコピーを格納する System.Object 配列。</returns>
		public static T[] ToArray<T>(this Array @this) {
			return @this.Cast<T>().ToArray();
		}

		#endregion

		#region インデックス取得

		/// <summary>
		/// IEnumerable 全体で、指定したオブジェクトを検索し、
		/// 最初に見つかった位置の 0 から始まるインデックスを返します。
		/// </summary>
		/// <typeparam name="T">ジェネリックの型</typeparam>
		/// <param name="this">列挙</param>
		/// <param name="item">IEnumerable 内で検索するオブジェクト。
		/// 参照型の場合、null の値を使用できます。</param>
		/// <returns>
		/// IEnumerable 全体内で item が見つかった場合は、最初に見つかった位置の 0 から始まるインデックス。
		/// それ以外の場合は -1。</returns>
		public static int IndexOf<T>(this IEnumerable<T> @this, T item) {
			return @this.ToList().IndexOf(item);
		}

		#endregion

		#region 要素削除

		#region Remove (オーバーロード +1)

		/// <summary>
		/// 述語に基づいて、条件を満たしている要素をコレクションから削除します。
		/// </summary>
		/// <typeparam name="TSource">collection の要素の型。</typeparam>
		/// <param name="this">フィルター処理するリスト</param>
		/// <param name="predicate">各要素が条件を満たしているかどうかをテストする関数。</param>
		public static void Remove<TSource>(this IList<TSource> @this, Func<TSource, bool> predicate) {
			foreach (var source in @this.Where(v => predicate(v)).ToArray()) {
				@this.Remove(source);
			}
		}

		/// <summary>
		/// 述語に基づいて、条件を満たしている要素をコレクションから削除します。
		/// </summary>
		/// <typeparam name="TSource">collection の要素の型。</typeparam>
		/// <param name="this">フィルター処理するリスト</param>
		/// <param name="predicate">各要素が条件を満たしているかどうかをテストする関数。
		/// この関数の 2 つ目のパラメーターは、ソース要素のインデックスを表します。</param>
		public static void Remove<TSource>(this IList<TSource> @this, Func<TSource, int, bool> predicate) {
			foreach (var source in @this.Where((v, i) => predicate(v, i)).ToArray()) {
				@this.Remove(source);
			}
		}

		#endregion

		#region RemoveAfter

		/// <summary>
		/// 指定したインデックス以降にある全ての要素を削除します。
		/// </summary>
		/// <param name="this">コレクション</param>
		/// <param name="index">要素の、0 から始まるインデックス番号。</param>
		public static void RemoveAfter<TSource>(this IList<TSource> @this, int index) {
			@this.Remove((item, i) => (i >= index));
		}

		#endregion

		#endregion

		#region 内部結合

		/// <summary>
		/// 一致するインデックスに基づいて 2 つのシーケンスの要素を相互に関連付けます。
		/// </summary>
		/// <typeparam name="TOuter">元となるコレクション要素の型</typeparam>
		/// <typeparam name="TInner">結合するコレクション要素の型く</typeparam>
		/// <param name="this">結合する最初のシーケンス。</param>
		/// <param name="inner">最初のシーケンスに結合するシーケンス。</param>
		/// <returns>2 つのシーケンスに対して内部結合を実行したシーケンスを返します。</returns>
		public static IEnumerable<Tuple<TOuter, TInner>> JoinOnIndex<TOuter, TInner>(this IEnumerable<TOuter> @this, IEnumerable<TInner> inner) {
			var query = (
				from a in @this.Select((x, i) => new { x, i })
				join b in inner.Select((x, i) => new { x, i })
				  on a.i equals b.i
				select Tuple.Create(a.x, b.x)
			);

			return query;
		}

		/// <summary>
		/// 一致するインデックスに基づいて 2 つのシーケンスの要素を相互に関連付けます。
		/// </summary>
		/// <typeparam name="TOuter">元となるコレクション要素の型</typeparam>
		/// <typeparam name="TInner">結合するコレクション要素の型く</typeparam>
		/// <typeparam name="TResult">結果の要素の型</typeparam>
		/// <param name="this">結合する最初のシーケンス。</param>
		/// <param name="inner">最初のシーケンスに結合するシーケンス。</param>
		/// <param name="resultSelector">一致する 2 つの要素から結果の要素を作成する関数。</param>
		/// <returns>2 つのシーケンスに対して内部結合を実行したシーケンスを返します。</returns>
		public static IEnumerable<TResult> JoinOnIndex<TOuter, TInner, TResult>(this IEnumerable<TOuter> @this, IEnumerable<TInner> inner, Func<TOuter, TInner, TResult> resultSelector) {
			return @this.JoinOnIndex(inner).Select(i => resultSelector(i.Item1, i.Item2));
		}

		#endregion

		#region データテーブル変換

		/// <summary>
		/// 文字列コレクションの列挙をデータテーブルに変換します。
		/// </summary>
		/// <param name="this">文字列コレクションの列挙</param>
		/// <param name="tableName">テーブル名</param>
		/// <returns>データテーブルを返します。</returns>
		public static DataTable ToDataTable(this IEnumerable<IEnumerable<string>> @this, string tableName = null) {
			var tbl = tableName.IsEmpty() ? new DataTable() : new DataTable(tableName);

			var fixRow = @this.First();
			tbl.Columns.AddRange(fixRow.Select(r => new DataColumn(r)).ToArray());

			var colCount = tbl.Columns.Count;

			var dataRows = @this.Skip(1);
			try {
				tbl.BeginLoadData();

				dataRows.Select(r => r.Take(colCount).ToArray())
					.ForEach(r => tbl.LoadDataRow(r, true));
			} finally {
				tbl.EndLoadData();
			}

			return tbl;
		}

		#endregion

		#region 最大値、最小値

		/// <summary>
		/// 最大値を持つ要素を取得します。
		/// </summary>
		/// <typeparam name="TSource">collection の要素の型。</typeparam>
		/// <typeparam name="TResult">selector によって返される値の型</typeparam>
		/// <param name="this">変換関数を呼び出す対象となる値のシーケンス</param>
		/// <param name="selector">各要素に適用する変換関数</param>
		/// <returns>最大値を持つ要素を全て返します。</returns>
		public static IEnumerable<TSource> MaxElementsBy<TSource, TResult>(this IEnumerable<TSource> @this, Func<TSource, TResult> selector) {
			var value = @this.Max(selector);
			return @this.Where(c => selector(c).Equals(value));
		}

		/// <summary>
		/// 最小値を持つ要素を取得します。
		/// </summary>
		/// <typeparam name="TSource">collection の要素の型。</typeparam>
		/// <typeparam name="TResult">selector によって返される値の型</typeparam>
		/// <param name="this">変換関数を呼び出す対象となる値のシーケンス</param>
		/// <param name="selector">各要素に適用する変換関数</param>
		/// <returns>最小値を持つ要素を全て返します。</returns>
		public static IEnumerable<TSource> MinElementsBy<TSource, TResult>(this IEnumerable<TSource> @this, Func<TSource, TResult> selector) {
			var value = @this.Min(selector);
			return @this.Where(c => selector(c).Equals(value));
		}

		#endregion
	}
}