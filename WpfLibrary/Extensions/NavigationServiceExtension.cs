using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Navigation;
using ExtensionsLibrary.Extensions;
using WpfLibrary.Data;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// NavigationService クラスを拡張するメソッドを提供します。
	/// </summary>
	public static partial class NavigationServiceExtension {
		#region メソッド

		/// <summary>
		/// uriString で指定されたコンテンツに非同期に移動します。
		/// </summary>
		/// <param name="this">NavigationService</param>
		/// <param name="uriString">URI 文字列</param>
		public static void SetNavigate(this NavigationService @this, string uriString)
			=> @this.Navigate(new Uri(uriString, UriKind.Relative));

		/// <summary>
		/// ページ情報のコレクションを指定して、
		/// ナビゲーションを設定します。
		/// </summary>
		/// <param name="this">NavigationService</param>
		/// <param name="pageCollection">pageCollection</param>
		/// <returns>ナビゲーションを返します。</returns>
		public static NavigationService Setting(this NavigationService @this, IEnumerable<PageInfo> pageCollection) {
			var pages = pageCollection.ToList();
			@this.Navigate(pages[0].Uri);
			@this.Navigated += (sender, e) => {
				try {// 表示中のページのメニューを無効にする
					var index = pages.FindIndex(p => p.Uri.GetFileName() == e.Uri.GetFileName());
					var page = pages[index];
					pages.ToList().ForEach(i => {
						var item = i.Item;
						item.IsEnabled = (index == 0) ? true : (item != page.Item);
						// TODO:無効時の表示色等検討
					});
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			};

			return @this;
		}

		#endregion
	}
}
