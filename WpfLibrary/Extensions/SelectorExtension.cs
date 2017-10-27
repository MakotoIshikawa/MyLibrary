using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Windows.Controls.Primitives;
using ExtensionsLibrary.Extensions;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// Selector を拡張するメソッドを提供します。
	/// </summary>
	public static partial class SelectorExtension {
		#region メソッド

		/// <summary>
		/// Selector を継承するコントロールにデータコレクションをバインドします。
		/// </summary>
		/// <typeparam name="T">コレクション内の要素の型</typeparam>
		/// <typeparam name="TMember">視覚的表現に使用するメンバーの型</typeparam>
		/// <typeparam name="TValue">選択値に使用するメンバーの型</typeparam>
		/// <param name="this">Selector</param>
		/// <param name="data">バインドするデータコレクション</param>
		/// <param name="displayMember">オブジェクトの視覚的表現として機能するメンバーを抽出する式木</param>
		/// <param name="selectedValue">SelectedValue に使用するメンバーを抽出する式木</param>
		public static void BindData<T, TMember, TValue>(this Selector @this, ObservableCollection<T> data, Expression<Func<T, TMember>> displayMember, Expression<Func<T, TValue>> selectedValue = null) {
			var dsp = displayMember?.GetMemberName();
			if (!dsp.IsWhiteSpace()) {
				@this.DisplayMemberPath = dsp;

				var val = selectedValue?.GetMemberName();
				@this.SelectedValuePath = val.IsWhiteSpace() ? dsp : val;
			}

			@this.ItemsSource = data;
		}

		#endregion
	}
}
