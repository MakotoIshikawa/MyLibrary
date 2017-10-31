using System;
using System.Collections.Generic;
using System.Linq;
using SharePointLibrary.Model;

namespace SharePointLibrary.Helper
{
    public class InsertBatch : UpdateBatch
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="listGuid">リストGUID</param>
        /// <param name="items">アイテムの列名と値がセットになった連想配列のコレクション</param>
        public InsertBatch(Guid listGuid, params Dictionary<string, object>[] items)
            : base(listGuid, items.Select(i => new IdentifiedListItem(i)))
        {
        }

        #endregion
    }
}
