using System;
using System.Collections.Generic;
using System.Linq;
using SharePointLibrary.Enums;
using SharePointLibrary.Helper.Primitive;
using SharePointLibrary.Model;

namespace SharePointLibrary.Helper
{
    public class UpdateBatch : BaseBatchData
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="listGuid">リストGUID</param>
        /// <param name="items">アイテムの列名と値がセットになった連想配列のコレクション</param>
        public UpdateBatch(Guid listGuid, IEnumerable<IdentifiedListItem> items) : base(listGuid)
        {
            items.Select((item, inx) => new {
                ID = item.ID.HasValue ? $"{item.ID}" : $"{BatchCommandTyps.New}",
                Item = item.Cells,
                Num = inx + 1,
            }).ToList().ForEach(t => {
                this.Methods.Append($@"<Method ID=""{t.Num}"">")
                .Append($@"<SetList>{this.ListGuid}</SetList>")
                .Append($@"<SetVar Name=""ID"">{t.ID}</SetVar>")
                .Append($@"<SetVar Name=""Cmd"">{BatchCommandTyps.Save}</SetVar>");

                t.Item.ToList().ForEach(kv => {
                    this.Methods.Append($@"<SetVar Name=""urn:schemas-microsoft-com:office:office#{kv.Key}"">{kv.Value}</SetVar>");
                });

                this.Methods.Append($@"</Method>");
            });
        }

        #endregion
    }
}
