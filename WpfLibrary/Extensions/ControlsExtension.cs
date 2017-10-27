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
		#region メソッド

		/// <summary>
		/// 現在選択されている最初の項目の KeyValuePair を取得します。
		/// </summary>
		/// <param name="this">ComboBox</param>
		/// <returns>選択されている KeyValuePair を返します。</returns>
		public static KeyValuePair<string, int> SelectedKeyValuePair(this ComboBox @this)
			=> @this.SelectedItem.GetValueOrDefault(i => ((KeyValuePair<string, int>)i), new KeyValuePair<string, int>(string.Empty, int.MinValue));

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

		#region Canvas

		#region 取得

		/// <summary>
		/// Canvas.Left 添付プロパティの値を取得します。
		/// </summary>
		/// <param name="this">Control</param>
		/// <returns>Canvas.Left 座標を返します。</returns>
		public static double GetLeft(this Control @this) => Convert.ToDouble(@this.GetValue(Canvas.LeftProperty));

		/// <summary>
		/// Canvas.Top 添付プロパティの値を取得します。
		/// </summary>
		/// <param name="this">Control</param>
		/// <returns>Canvas.Top 座標を返します。</returns>
		public static double GetTop(this Control @this) => Convert.ToDouble(@this.GetValue(Canvas.TopProperty));

		/// <summary>
		/// Canvas.Right 添付プロパティの値を取得します。
		/// </summary>
		/// <param name="this">Control</param>
		/// <returns>Canvas.Right 座標を返します。</returns>
		public static double GetRight(this Control @this) => Convert.ToDouble(@this.GetValue(Canvas.RightProperty));

		/// <summary>
		/// Canvas.Bottom 添付プロパティの値を取得します。
		/// </summary>
		/// <param name="this">Control</param>
		/// <returns>Canvas.Bottom 座標を返します。</returns>
		public static double GetBottom(this Control @this) => Convert.ToDouble(@this.GetValue(Canvas.BottomProperty));

		#endregion

		#region 設定

		/// <summary>
		/// Canvas.Left 添付プロパティの値を設定します。
		/// </summary>
		/// <param name="this">Control</param>
		/// <param name="length">Canvas.Left 属性に設定する値</param>
		public static void SetLeft(this Control @this, double length) => @this.SetValue(Canvas.LeftProperty, length);

		/// <summary>
		/// Canvas.Top 添付プロパティの値を設定します。
		/// </summary>
		/// <param name="this">Control</param>
		/// <param name="length">Canvas.Top 属性に設定する値</param>
		public static void SetTop(this Control @this, double length) => @this.SetValue(Canvas.TopProperty, length);

		/// <summary>
		/// Canvas.Top 添付プロパティの値を設定します。
		/// </summary>
		/// <param name="this">Control</param>
		/// <param name="length">Canvas.Top 属性に設定する値</param>
		public static void SetRight(this Control @this, double length) => @this.SetValue(Canvas.RightProperty, length);

		/// <summary>
		/// Canvas.Bottom 添付プロパティの値を設定します。
		/// </summary>
		/// <param name="this">Control</param>
		/// <param name="length">Canvas.Bottom 属性に設定する値</param>
		public static void SetBottom(this Control @this, double length) => @this.SetValue(Canvas.BottomProperty, length);

		#endregion

		#endregion

		#endregion
	}
}
