using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;

namespace SharePointLibrary.Extensions {
	/// <summary>
	/// SPList を拡張するメソッドを提供します。
	/// </summary>
	public static partial class SPListExtension {
		#region メソッド

		#region 選択肢取得

		/// <summary>
		/// リスト列(選択肢)の内部名を指定して、
		/// 選択肢の項目を取得します。
		/// </summary>
		/// <param name="this">SPList</param>
		/// <param name="name">列の内部名</param>
		/// <param name="blank">先頭に空白アイテムを挿入するかどうか</param>
		/// <returns>選択肢の項目のリストを返します。</returns>
		public static List<string> GetChoices(this SPList @this, string name, bool blank = true) {
			var items = (@this.Fields.TryGetFieldByStaticName(name) as SPFieldChoice)?
				.Choices?.Cast<string>()?.ToList();

			if (blank)
				items?.Insert(0, string.Empty);

			return items;
		}

		#endregion

		#endregion
	}
}
