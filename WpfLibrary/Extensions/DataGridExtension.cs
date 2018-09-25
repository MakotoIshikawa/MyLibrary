using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// DataGrid を拡張するメソッドを提供します。
	/// </summary>
	public static partial class DataGridExtension {
		#region メソッド

		/// <summary>
		/// １行セルリストをコレクションとして取得します。
		/// </summary>
		/// <param name="this">DataGrid</param>
		/// <returns>１行セルリストのコレクションを返します。</returns>
		public static IEnumerable<List<DataGridCell>> GetRowItems(this DataGrid @this) {
			var rows = @this.GetRows();
			return rows.Select(r => r.GetCells(@this.Columns).ToList());
		}

		/// <summary>
		/// DataGrid から行のコレクションを取得します。
		/// </summary>
		/// <param name="this">DataGrid</param>
		/// <returns>行のコレクションを返します。</returns>
		public static IEnumerable<DataGridRow> GetRows(this DataGrid @this) {
			for (var i = 0; i < @this.Items.Count; i++) {
				var item = @this.ItemContainerGenerator.ContainerFromIndex(i);
				if (item is DataGridRow row) {
					yield return row;
				}
			}
		}

		/// <summary>
		/// 行データからセルのコレクションを取得します。
		/// </summary>
		/// <param name="this">DataGridRow</param>
		/// <param name="columns">列情報</param>
		/// <returns>セルのコレクションを返します。</returns>
		public static IEnumerable<DataGridCell> GetCells(this DataGridRow @this, IEnumerable<DataGridColumn> columns)
			=> columns.Select(c => c.GetCellContent(@this))
				.Where(e => e != null)
				.Select(e => e.Parent as DataGridCell);

		#endregion
	}
}
