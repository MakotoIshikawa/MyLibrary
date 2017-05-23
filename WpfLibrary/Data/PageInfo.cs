using System;
using System.Windows.Controls;
using ExtensionsLibrary.Extensions;

namespace WpfLibrary.Data {
	/// <summary>
	/// ページ情報クラス
	/// </summary>
	public class PageInfo {
		#region プロパティ

		/// <summary>
		/// メニュー項目を取得、設定します。
		/// </summary>
		public MenuItem Item { get; set; }

		/// <summary>
		/// URI を取得、設定します。
		/// </summary>
		public Uri Uri { get; set; }

		#endregion

		#region メソッド

		/// <summary>
		/// オブジェクトを文字列に変換します。
		/// </summary>
		/// <returns>オブジェクトを表す文字列を返します。</returns>
		public override string ToString() {
			return this.GetPropertiesString();
		}

		#endregion
	}
}
