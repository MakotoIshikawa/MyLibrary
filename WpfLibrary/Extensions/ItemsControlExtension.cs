using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// ItemsControl クラスを拡張するメソッドを提供します。
	/// </summary>
	public static partial class ItemsControlExtension {
		/// <summary>
		/// ItemsControl のコンテンツの生成に使用するコレクションを設定します。
		/// </summary>
		/// <typeparam name="T">アイテムの型</typeparam>
		/// <param name="this">ItemsControl</param>
		/// <param name="items">アイテムのコレクション</param>
		/// <param name="wantsCopy">コピーするかどうか</param>
		public static void SetItemsSource<T>(this ItemsControl @this, IEnumerable<T> items, bool wantsCopy = true) {
			@this.Items.Clear();
			@this.ItemsSource = wantsCopy ? new ObservableCollection<T>(items) : items;
		}

		/// <summary>
		/// Selector のコンテンツの生成に使用するコレクションを設定します。
		/// </summary>
		/// <typeparam name="TKey">キーの型</typeparam>
		/// <typeparam name="TValue">値の型</typeparam>
		/// <param name="this">Selector</param>
		/// <param name="items">アイテムのコレクション</param>
		public static void SetKeyValuePairItems<TKey, TValue>(this Selector @this, IEnumerable<KeyValuePair<TKey, TValue>> items) {
			@this.DisplayMemberPath = "Key";
			@this.SelectedValuePath = "Value";
			@this.SetItemsSource(items, false);
			@this.SelectedIndex = 0;
		}

		/// <summary>
		/// TabControl にオブジェクトを含んだ、TabItem 追加します。
		/// </summary>
		/// <typeparam name="T">FrameworkElement</typeparam>
		/// <param name="this">TabControl</param>
		/// <param name="item">TabControl に追加するオブジェクト。</param>
		public static void Add<T>(this TabControl @this, T item) where T : FrameworkElement {
			var num = @this.Items.Count + 1;
			@this.Items.Add(new TabItem {
				Name = string.Format($"tab{num:00}"),
				Content = item,
				Header = item.Tag,
			});
		}
	}
}
