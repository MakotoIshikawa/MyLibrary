using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using ExtensionsLibrary.Extensions;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// Control の拡張するメソッドを提供します。
	/// </summary>
	public static partial class ControlsExtension {
		/// <summary>
		/// 現在選択されている最初の項目の KeyValuePair を取得します。
		/// </summary>
		/// <param name="this">ComboBox</param>
		/// <returns>選択されている KeyValuePair を返します。</returns>
		public static KeyValuePair<string, int> SelectedKeyValuePair(this ComboBox @this) {
			return @this.SelectedItem.GetValueOrDefault(i => ((KeyValuePair<string, int>)i), new KeyValuePair<string, int>(string.Empty, int.MinValue));
		}

		/// <summary>
		/// カンマ区切りの文字列を指定して、
		/// コンボボックスのアイテムを設定します。
		/// </summary>
		/// <param name="this">ComboBox</param>
		/// <param name="itemsString">カンマ区切りのアイテム文字列</param>
		/// <param name="blank">先頭に空白行を入れるかどうか</param>
		public static void SetComboBox(this ComboBox @this, string itemsString, bool blank = false) {
			if (itemsString.IsEmpty()) {
				return;
			}

			try {
				var ls = itemsString.Split(',').ToList();
				if (blank) {
					ls.Prepend(string.Empty);
				}
				var items = ls.Select((n, i) => new { Name = n, Index = i })
					.ToDictionary(c => c.Name, c => c.Index);

				@this.SetKeyValuePairItems(items);
			} catch (Exception ex) {
				Debug.WriteLine(ex.Message);
			}
		}
	}
}
