using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;
using SharePointLibrary.Helper;
using SharePointLibrary.Model;

namespace SharePointLibrary.Extensions
{
    /// <summary>
    /// SPWeb を拡張するメソッドを提供します。
    /// </summary>
    public static partial class SPWebExtension
    {
        #region メソッド

        #region 追加

        /// <summary>
        /// 列名と値の連想配列を指定して、
        /// リストにアイテムを追加します。
        /// </summary>
        /// <param name="this">SPList</param>
        /// <param name="item">列名と値の連想配列</param>
        /// <returns>SPList のインスタンスを返します。</returns>
        public static SPList AddItem(this SPList @this, Dictionary<string, object> item)
        {
            @this.AddItem().Update(item);
            return @this;
        }

        /// <summary>
        /// リスト名、列名と値の連想配列を指定して、
        /// リストにアイテムを 1 件ずつ追加します。
        /// </summary>
        /// <param name="web">SPWeb</param>
        /// <param name="listTitle">リスト名</param>
        /// <param name="item">列名と値の連想配列</param>
        public static void AddItemsOneByOne(this SPWeb web, string listTitle, params Dictionary<string, object>[] items)
        {
            var list = web.Lists.TryGetList(listTitle);
            items.ToList().ForEach(i => {
                list.AddItem(i);
            });
        }

        /// <summary>
        /// リスト名、列名と値の連想配列を指定して、
        /// リストにアイテムを追加します。(バッチ処理)
        /// </summary>
        /// <param name="web">SPWeb</param>
        /// <param name="listTitle">リスト名</param>
        /// <param name="item">列名と値の連想配列</param>
        public static string AddItemsByBatch(this SPWeb web, string listTitle, params Dictionary<string, object>[] items)
        {
            var list = web.Lists.TryGetList(listTitle);
            var bat = new InsertBatch(list.ID, items);
            var xml = bat.ToString();

            var ret = web.ProcessBatchData(xml);
            return ret;
        }

        #endregion

        #region 更新

        /// <summary>
        /// 列名と値の連想配列を指定して、
        /// リスト項目に加えられた変更をデータベースに更新します。
        /// </summary>
        /// <param name="this">SPListItem</param>
        /// <param name="item">列名と値の連想配列</param>
        /// <returns>SPListItem のインスタンスを返します。</returns>
        public static SPListItem Update(this SPListItem @this, Dictionary<string, object> item)
        {
            item.ToList().ForEach(kv => @this[kv.Key] = kv.Value);
            @this.Update();
            return @this;
        }

        /// <summary>
        /// リスト名、列名と値の連想配列を指定して、
        /// リストにアイテムを追加します。(バッチ処理)
        /// </summary>
        /// <param name="web">SPWeb</param>
        /// <param name="listTitle">リスト名</param>
        /// <param name="func">列名と値の連想配列を取得するメソッド</param>
        public static string UpdateByBatch(this SPWeb web, string listTitle, Func<SPList, IEnumerable<IdentifiedListItem>> func)
        {
            var list = web.Lists.TryGetList(listTitle);
            var items = func?.Invoke(list);
            if (items?.Any() ?? false)
            {
                return string.Empty;
            }

            var bat = new UpdateBatch(list.ID, items);
            var xml = bat.ToString();

            var ret = web.ProcessBatchData(xml);
            return ret;
        }

        #endregion

        #region 削除

        /// <summary>
        /// リスト名と削除対象のアイテムのIDを取得するメソッドを指定して、
        /// リストのアイテムを削除します。(バッチ処理)
        /// </summary>
        /// <param name="web">SPWeb</param>
        /// <param name="listTitle">リスト名</param>
        /// <param name="getIds">削除対象のアイテムのIDを取得するメソッド</param>
        /// <returns>結果を含む文字列を返します。</returns>
        public static string DeleteByBatch(this SPWeb web, string listTitle, Func<SPList, IEnumerable<int>> getIds)
        {
            var list = web.Lists.TryGetList(listTitle);
            var items = getIds?.Invoke(list);
            if (items?.Any() ?? false)
            {
                return string.Empty;
            }

            var bat = new DeleteBatch(list.ID, items);
            var xml = bat.ToString();

            var ret = web.ProcessBatchData(xml);
            return ret;
        }

        /// <summary>
        /// リスト名を指定して、
        /// リストの全てのアイテムを削除します。(バッチ処理)
        /// </summary>
        /// <param name="web">SPWeb</param>
        /// <param name="listTitle">リスト名</param>
        /// <returns>結果を含む文字列を返します。</returns>
        public static string DeleteAllByBatch(this SPWeb web, string listTitle)
        {
            var ret = web.DeleteByBatch(listTitle, list
                => list.GetItems("ID")?.Cast<SPListItem>()?.Select(i => i.ID));

            // ゴミ箱を空にする
            web.RecycleBin.DeleteAll();
            return ret;
        }

        #endregion

        #endregion
    }
}
