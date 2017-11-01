using System.Collections.Generic;
using SharePointLibrary.Model;

namespace SharePointLibrary.Extensions {
	/// <summary>
	/// IdentifiedListItem を拡張メソッドを提供します。
	/// </summary>
	public static partial class IdentifiedListItemExtension {
		#region メソッド

		#region 追加

		/// <summary>
		/// 末尾にオブジェクトを追加します。
		/// </summary>
		/// <param name="this">IdentifiedListItem のリスト</param>
		/// <param name="id">ID</param>
		/// <param name="cells">列名と値の連想配列</param>
		public static void Add(this List<IdentifiedListItem> @this, int id, Dictionary<string, object> cells) {
			@this.Add(new IdentifiedListItem(id, cells));
		}

		/// <summary>
		/// 末尾にオブジェクトを追加します。
		/// </summary>
		/// <param name="this">IdentifiedListItem のリスト</param>
		/// <param name="cells">列名と値の連想配列</param>
		public static void Add(this List<IdentifiedListItem> @this, Dictionary<string, object> cells) {
			@this.Add(new IdentifiedListItem(cells));
		}

		#endregion

		#endregion
	}
}
