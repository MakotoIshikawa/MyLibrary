using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsLibrary.Extensions {
	/// <summary>
	/// DataGridView を拡張するメソッドを提供します。
	/// </summary>
	public static partial class DataGridViewExtension {
		#region メソッド

		/// <summary>
		/// 選択中の行コレクションを取得します。
		/// </summary>
		/// <param name="this">DataGridView</param>
		/// <returns>DataGridViewRow のコレクションを返します。</returns>
		public static IEnumerable<DataGridViewRow> GetSelectedRows(this DataGridView @this) {
			return @this.SelectedRows.ToGeneric();
		}

		/// <summary>
		/// ジェネリック型のコレクションに変換します。
		/// </summary>
		/// <param name="this">DataGridViewSelectedRowCollection</param>
		/// <returns>DataGridViewRow のコレクションを返します。</returns>
		public static IEnumerable<DataGridViewRow> ToGeneric(this DataGridViewSelectedRowCollection @this) {
			return @this.Cast<DataGridViewRow>();
		}

		#region データテーブル変換

		/// <summary>
		/// DataGridView のデータソースを、
		/// データテーブルに変換します。</summary>
		/// <param name="this">DataGridView</param>
		/// <returns>データテーブルのインスタンスを返します。</returns>
		public static DataTable ToDataTable(this DataGridView @this) {
			var dt = @this.DataSource as DataTable;
			if (dt != null) {
				dt.AcceptChanges();
				return dt;
			}

			dt = new DataTable();

			// 列追加
			dt.AddColumns(@this.Columns);

			// 行データ追加
			dt.AddRows(@this.Rows);

			return dt;
		}

		#endregion

		#region データ追加

		/// <summary>
		/// DataGridView の列コレクションを指定して、
		/// データテーブルに列を追加します。</summary>
		/// <param name="this">データテーブル</param>
		/// <param name="columns">列コレクション</param>
		public static void AddColumns(this DataTable @this, DataGridViewColumnCollection columns) {
			foreach (var col in columns.Cast<DataGridViewColumn>()) {
				@this.Columns.Add(col.Name, col.ValueType != null ? col.ValueType : typeof(Object));
			}
		}

		/// <summary>
		/// DataGridView の行コレクションを指定して、
		/// データテーブルに行データを追加します。</summary>
		/// <param name="this">データテーブル</param>
		/// <param name="rows">行コレクション</param>
		public static void AddRows(this DataTable @this, DataGridViewRowCollection rows) {
			foreach (var row in rows.Cast<DataGridViewRow>()) {
				try {
					var r = (DataRowView)row.DataBoundItem;
					@this.Rows.Add(r.Row);
				} catch (Exception) {
					continue;
				}
			}
		}

		#endregion

		#endregion
	}
}
