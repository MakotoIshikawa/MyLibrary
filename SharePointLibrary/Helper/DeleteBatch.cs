using System;
using System.Collections.Generic;
using System.Linq;
using SharePointLibrary.Enums;
using SharePointLibrary.Helper.Primitive;

namespace SharePointLibrary.Helper {
	/// <summary>
	/// 削除用のバッチ文字列を作成するクラスです。
	/// </summary>
	public class DeleteBatch : BaseBatchData {
		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="listGuid">リストGUID</param>
		/// <param name="itemIds">アイテムIDのコレクション</param>
		public DeleteBatch(Guid listGuid, IEnumerable<int> itemIds) : base(listGuid) {
			itemIds.Select((id, inx) => new {
				ID = id,
				Num = inx + 1,
			}).ToList().ForEach(t => {
				this.Methods.Append($@"<Method ID=""{t.Num}"">")
				.Append($@"<SetList>{this.ListGuid}</SetList>")
				.Append($@"<SetVar Name=""ID"">{t.ID}</SetVar>")
				.Append($@"<SetVar Name=""Cmd"">{BatchCommandTyps.Delete}</SetVar>")
				.Append($@"</Method>");
			});
		}

		#endregion
	}
}
