using System;
using System.Collections.Generic;

namespace SharePointLibrary.Model {
	/// <summary>
	/// ID で管理されるリストのアイテムクラス
	/// </summary>
	public class IdentifiedListItem : Tuple<int?, Dictionary<string, object>> {
		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="cells">列名と値の連想配列</param>
		public IdentifiedListItem(Dictionary<string, object> cells) : this(null, cells) {
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="cells">列名と値の連想配列</param>
		public IdentifiedListItem(int? id, Dictionary<string, object> cells) : base(id, cells) {
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// ID
		/// </summary>
		public int? ID => this.Item1;

		/// <summary>
		/// 列名と値の連想配列
		/// </summary>
		public Dictionary<string, object> Cells => this.Item2;

		#endregion
	}
}
