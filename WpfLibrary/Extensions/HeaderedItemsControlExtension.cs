using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using ExtensionsLibrary.Extensions;
using WpfLibrary.Data;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// HeaderedItemsControl を拡張するメソッドを提供します。
	/// </summary>
	public static class HeaderedItemsControlExtension {
		/// <summary>
		/// URI文字列の配列を指定して、
		/// ページ情報のコレクションを取得します。
		/// </summary>
		/// <param name="this">MenuItem のコレクション</param>
		/// <param name="uriStrings">URI文字列の配列</param>
		/// <returns>ページ情報のコレクションをかえします。</returns>
		public static IEnumerable<PageInfo> GetPageInfoCollection(this IEnumerable<MenuItem> @this, params string[] uriStrings) {
			var ms = @this.Select((m, i) => new {
				Index = i,
				MenuItem = m,
			});

			var ps = uriStrings.Select((p, i) => new {
				Index = i,
				Uri = new Uri(p, UriKind.Relative),
			});

			return ms.Join(ps, m => m.Index, p => p.Index,
				(m, p) => new PageInfo {
					Item = m.MenuItem,
					Uri = p.Uri,
				}
			);
		}
	}
}
