using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// DependencyObject クラスを拡張するメソッドを提供します。
	/// </summary>
	public static partial class DependencyObjectExtension {
		/// <summary>
		/// 子要素のコレクションを取得します。
		/// </summary>
		/// <param name="this">DependencyObject</param>
		/// <returns>子要素のコレクションを返します。</returns>
		public static IEnumerable<DependencyObject> GetAllChildren(this DependencyObject @this) {
			if (@this == null) {
				throw new ArgumentNullException(nameof(@this));
			}

			var count = VisualTreeHelper.GetChildrenCount(@this);
			if (count == 0) {
				yield break;
			}

			for (var i = 0; i < count; i++) {
				var child = VisualTreeHelper.GetChild(@this, i);
				if (child != null) {
					yield return child;
				}
			}
		}

		/// <summary>
		/// 子孫要素のコレクションを取得します。
		/// </summary>
		/// <param name="this">DependencyObject</param>
		/// <returns>子孫要素のコレクションを返します。</returns>
		public static IEnumerable<DependencyObject> GetAllDescendants(this DependencyObject @this) {
			if (@this == null) {
				throw new ArgumentNullException(nameof(@this));
			}

			foreach (var child in @this.GetAllChildren()) {
				yield return child;
				foreach (var grandChild in child.GetAllDescendants()) {
					yield return grandChild;
				}
			}
		}

		/// <summary>
		/// 要素の型を指定して子要素のコレクションを取得します。
		/// </summary>
		/// <typeparam name="TElement">子要素の型</typeparam>
		/// <param name="this">DependencyObject</param>
		/// <returns>子要素のコレクションを返します。</returns>
		public static IEnumerable<TElement> GetChildren<TElement>(this DependencyObject @this)
			where TElement : DependencyObject => @this.GetAllChildren().OfType<TElement>();

		/// <summary>
		/// 要素の型を指定して子孫要素のコレクションを取得します。
		/// </summary>
		/// <typeparam name="TElement">子孫要素の型</typeparam>
		/// <param name="this">DependencyObject</param>
		/// <returns>子要素のコレクションを返します。</returns>
		public static IEnumerable<TElement> GetDescendants<TElement>(this DependencyObject @this)
			where TElement : DependencyObject => @this.GetAllDescendants().OfType<TElement>();
	}
}
