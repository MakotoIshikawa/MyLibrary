using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfLibrary.Interface {
	/// <summary>
	/// メニュー付きのメインウインドウ内で使用されるページのインターフェイスを提供します。
	/// </summary>
	public interface IMenuPage<TWindow> where TWindow : Window {
		/// <summary>
		/// 親ウインドウを取得します。
		/// </summary>
		TWindow Parent { get; }

		/// <summary>
		/// メニューアイテムのリストを取得します。
		/// </summary>
		List<MenuItem> MenuItems { get; }
	}
}