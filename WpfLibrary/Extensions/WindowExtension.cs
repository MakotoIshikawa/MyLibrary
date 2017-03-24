using System.Windows;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// Window を拡張するメソッドを提供します。
	/// </summary>
	public static class WindowExtension {
		#region メソッド

		/// <summary>
		/// 指定されたウィンドウの前面にメッセージ ボックスを表示します。
		/// このメッセージ ボックスは、メッセージ、タイトル バー キャプション、ボタン、およびアイコンを表示し、
		/// 既定のメッセージボックスの結果を受け入れ、指定されたオプションに準拠し、結果を返します。
		/// </summary>
		/// <param name="owner">メッセージ ボックスのオーナー ウィンドウを表す Window。</param>
		/// <param name="messageBoxText">メッセージ ボックスに表示するテキスト。</param>
		/// <param name="caption">表示するタイトル バー キャプションを指定するテキスト。</param>
		/// <param name="button">表示する 1 つ以上のボタンを指定する MessageBoxButton 値。</param>
		/// <param name="icon">表示するアイコンを指定する MessageBoxImage 値。</param>
		/// <param name="defaultResult">メッセージ ボックスの既定の結果を指定する MessageBoxResult 値。</param>
		/// <param name="options">オプションを指定する MessageBoxOptions 値オブジェクト。</param>
		/// <returns>DialogResult 値のいずれか。</returns>
		public static MessageBoxResult ShowMessageBox(this Window owner, string messageBoxText, string caption = "", MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None, MessageBoxOptions options = MessageBoxOptions.None) {
			return MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult, options);
		}

		#endregion
	}
}
