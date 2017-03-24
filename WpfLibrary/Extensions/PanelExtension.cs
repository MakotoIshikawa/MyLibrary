using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// Panel クラスを拡張するメソッドを提供します。
	/// </summary>
	public static partial class PanelExtension {
		/// <summary>
		/// Panel に子要素を追加します。
		/// </summary>
		/// <typeparam name="TElement">子要素の型</typeparam>
		/// <param name="this">Panel</param>
		/// <param name="element">追加する子要素</param>
		/// <param name="action">子要素へ変更を加えるメソッド</param>
		/// <returns>Panel を返します。</returns>
		public static Panel Add<TElement>(this Panel @this, TElement element, Action<TElement> action = null) where TElement : UIElement {
			var index = @this.Children.Add(element);
			var elmt = @this.Children[index] as TElement;
			action?.Invoke(elmt);

			return @this;
		}

		/// <summary>
		/// 子要素のコレクションを取得します。
		/// </summary>
		/// <typeparam name="TElement">子要素の型</typeparam>
		/// <param name="this">Panel</param>
		/// <returns>子要素のコレクションを返します。</returns>
		public static IEnumerable<TElement> GetElements<TElement>(this Panel @this) where TElement : UIElement {
			return @this.Children.OfType<TElement>();
		}
	}
}
