using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using ExtensionsLibrary.Extensions;

namespace ObjectAnalysisProject.Extensions {
	/// <summary>
	/// DataTable を拡張するメソッドを提供します。
	/// </summary>
	public static partial class DataTableExtension {
		#region メソッド

		#region Select

		/// <summary>
		/// データテーブルのデータ行を新しいフォームに射影します。
		/// </summary>
		/// <typeparam name="TResult">selector によって返される値の型。</typeparam>
		/// <param name="this">データテーブル</param>
		/// <param name="selector">各要素に適用する変換関数。</param>
		/// <returns>source の各要素に対して変換関数を呼び出した結果として得られる要素を含む IEnumerable(T)</returns>
		public static IEnumerable<TResult> Select<TResult>(this DataTable @this, Func<DataRow, int, TResult> selector)
			=> @this.Select().Select(selector);

		/// <summary>
		/// データテーブルのデータ行を新しいフォームに射影します。
		/// </summary>
		/// <typeparam name="TResult">selector によって返される値の型。</typeparam>
		/// <param name="this">データテーブル</param>
		/// <param name="selector">各要素に適用する変換関数。</param>
		/// <returns>source の各要素に対して変換関数を呼び出した結果として得られる要素を含む IEnumerable(T)</returns>
		public static IEnumerable<TResult> Select<TResult>(this DataTable @this, Func<DataRow, TResult> selector)
			=> @this.Select().Select(selector);

		#endregion

		#region Where

		/// <summary>
		/// 述語に基づいて値のデータテーブルのデータ行をフィルター処理します。
		/// </summary>
		/// <param name="this">データテーブル</param>
		/// <param name="predicate">各要素が条件を満たしているかどうかをテストする関数。</param>
		/// <returns>条件を満たす、入力シーケンスの要素を含む IEnumerable(DataRow)</returns>
		public static IEnumerable<DataRow> Where(this DataTable @this, Func<DataRow, bool> predicate)
			=> @this.Select().Where(predicate);

		/// <summary>
		/// 述語に基づいて値のデータテーブルのデータ行をフィルター処理します。
		/// </summary>
		/// <param name="this">データテーブル</param>
		/// <param name="predicate">各要素が条件を満たしているかどうかをテストする関数。</param>
		/// <returns>条件を満たす、入力シーケンスの要素を含む IEnumerable(DataRow)</returns>
		public static IEnumerable<DataRow> Where(this DataTable @this, Func<DataRow, int, bool> predicate)
			=> @this.Select().Where(predicate);

		#endregion

		#region 列データ列挙取得	GetColumns(+2 オーバーロード)

		/// <summary>
		/// 列インデックスを指定して、
		/// データテーブルから列データの列挙を取得します。</summary>
		/// <param name="this">データテーブル</param>
		/// <param name="columnIndex">列インデックス</param>
		/// <returns>列データの列挙を返します。</returns>
		public static IEnumerable<Object> GetColumns(this DataTable @this, int columnIndex)
			=> @this.Select(row => row[columnIndex]);

		/// <summary>
		/// 列の名前を指定して、
		/// データテーブルから列データの列挙を取得します。</summary>
		/// <param name="this">データテーブル</param>
		/// <param name="columnName">列名</param>
		/// <returns>列データの列挙を返します。</returns>
		public static IEnumerable<Object> GetColumns(this DataTable @this, string columnName)
			=> @this.Select(row => row[columnName]);

		/// <summary>
		/// 列スキーマを指定して、
		/// データテーブルから列データの列挙を取得します。</summary>
		/// <param name="this">データテーブル</param>
		/// <param name="column">列スキーマ</param>
		/// <returns>列データの列挙を返します。</returns>
		public static IEnumerable<Object> GetColumns(this DataTable @this, DataColumn column)
			=> @this.Select(row => row[column]);

		#endregion

		#region 細断処理

		/// <summary>
		/// オブジェクトを細断処理します。
		/// オブジェクトの配列からデータテーブルにデータをロードします。</summary>
		/// <param name="this">データテーブル</param>
		/// <param name="source">オブジェクトの順序は、データテーブルにロードします。</param>
		/// <param name="options">指定ソース配列からの値がテーブル内の既存の行に適用されますか。</param>
		/// <returns>ソースシーケンスから作成されたデータテーブル。</returns>
		public static void Shred<T>(this DataTable @this, IEnumerable<T> source, LoadOption? options) {
			if (@this == null) {
				throw new ArgumentNullException(nameof(@this), "データテーブルが null です。");
			}

			// インスタンスのメンバ情報でテーブルのスキーマを拡張する。
			@this.ExtendSchema(source);

			// ソースシーケンスを列挙し、オブジェクトの値をロードします。
			@this.LoadData(source.Select(v => v.ConvertInsertedArray(@this.Columns)), options);
		}

		#region スキーマ拡張	ExtendSchema

		/// <summary>
		/// テーブルのスキーマを拡張します。</summary>
		/// <typeparam name="T">データ型</typeparam>
		/// <param name="this">データテーブル</param>
		/// <param name="source">列挙子</param>
		private static void ExtendSchema<T>(this DataTable @this, IEnumerable<T> source) {
			var members = source.SelectMany(i =>
				i.GetMembers().Select(m => new {
					Name = m.Item1,
					Type = m.Item2,
				})
			).Distinct();

			members.ForEach(m => {
				@this.AddColumn(m.Name, m.Type);
			});
		}

		#region AddColumn

		/// <summary>
		/// 名前と型を指定して、列を追加します。
		/// </summary>
		/// <param name="this">this</param>
		/// <param name="name">列の名前(System.Data.DataColumn.ColumnName)</param>
		/// <param name="type">列の型(System.Data.DataColumn.DataType)</param>
		/// <returns>
		/// 新たに作成した列を返します。
		/// 列コレクション内に同名の列が既に存在する場合は、その列を返します。
		/// </returns>
		public static DataColumn AddColumn(this DataTable @this, string name, Type type = null) {
			if (!@this.Columns.Contains(name)) {
				if (type == null) {
					return @this.Columns.Add(name);
				}

				if (type.IsNullable()) {
					return @this.Columns.Add(name, type.GenericTypeArguments.First());
				}

				return @this.Columns.Add(name, type);
			} else {
				Debug.WriteLine($"テーブルに既に列が存在します。name = {name}:{type}");
			}

			return @this.Columns[name];
		}

		#endregion

		#endregion

		#region データ読込

		/// <summary>
		/// テーブルにデータを読み込みます。</summary>
		/// <param name="this">データテーブル</param>
		/// <param name="dataRows">行データ</param>
		/// <param name="options">
		/// 配列値を既存の行にある対応する値に適用する方法を決定するために使用します。
		/// null を指定できます。</param>
		public static void LoadData(this DataTable @this, IEnumerable<object[]> dataRows, LoadOption? options = null) {
			if (@this == null) {
				throw new ArgumentNullException("table", "テーブルが null です。");
			}

			try {
				@this.BeginLoadData();

				foreach (var values in dataRows) {
					@this.LoadDataRow(values, options);
				}
			} finally {
				@this.EndLoadData();
			}
		}

		/// <summary>
		/// 特定の行を検索し、更新します。
		/// 一致する行が見つからない場合は、指定した値を使用して新しい行が作成されます。</summary>
		/// <param name="this"></param>
		/// <param name="values">新しい行の作成に使用する値の配列。</param>
		/// <param name="options">配列値を既存の行にある対応する値に適用する方法を決定するために使用します。</param>
		/// <returns>新しい System.Data.DataRow。</returns>
		private static DataRow LoadDataRow(this DataTable @this, object[] values, LoadOption? options = null) {
			if (@this == null) {
				throw new ArgumentNullException("table", "テーブルが null です。");
			}

			if (options.HasValue) {
				return @this.LoadDataRow(values, options.Value);
			} else {
				return @this.LoadDataRow(values, true);
			}
		}

		#endregion

		#region ConvertInsertedArray

		/// <summary>
		/// 列コレクションを指定して、
		/// 列インデックスをキーとするインスタンス値の配列を取得します。
		/// </summary>
		/// <typeparam name="T">データ型</typeparam>
		/// <param name="this">インスタンス</param>
		/// <param name="columns">列コレクション</param>
		/// <returns>列をキーとするインスタンス値の配列を返します。</returns>
		private static object[] ConvertInsertedArray<T>(this T @this, DataColumnCollection columns) {
			var length = columns.Count;
			var values = new object[length];

			var members = @this.GetMembers()
			.Select(m => new {
				Index = columns[m.Item1].Ordinal,
				Value = m.Item3
			}).ToList();

			members.ForEach(m => {
				values[m.Index] = m.Value;
			});

			return values;
		}

		#endregion

		#endregion

		#endregion
	}
}
