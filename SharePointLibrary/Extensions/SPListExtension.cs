﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;
using SharePointLibrary.Helper;
using SharePointLibrary.Model;

namespace SharePointLibrary.Extensions {
	/// <summary>
	/// SPList を拡張するメソッドを提供します。
	/// </summary>
	public static partial class SPListExtension {
		#region メソッド

		#region 追加

		/// <summary>
		/// 列名と値の連想配列を指定して、
		/// リストにアイテムを追加します。
		/// </summary>
		/// <param name="this">SPList</param>
		/// <param name="item">列名と値の連想配列</param>
		/// <returns>SPList のインスタンスを返します。</returns>
		public static SPList AddItem(this SPList @this, Dictionary<string, object> item) {
			@this.AddItem().Update(item);
			return @this;
		}

		/// <summary>
		/// 列名と値の連想配列を指定して、
		/// リストにアイテムを 1 件ずつ追加します。
		/// </summary>
		/// <param name="list">SPList</param>
		/// <param name="items">列名と値の連想配列</param>
		public static void AddItemsOneByOne(this SPList list, params Dictionary<string, object>[] items)
			=> items.ToList().ForEach(i => list.AddItem(i));

		/// <summary>
		/// 列名と値の連想配列を指定して、
		/// リストにアイテムを追加します。(バッチ処理)
		/// </summary>
		/// <param name="list">SPList</param>
		/// <param name="items">列名と値の連想配列</param>
		/// <returns></returns>
		public static string AddItemsByBatch(this SPList list, params Dictionary<string, object>[] items) {
			var bat = new InsertBatch(list.ID, items);
			var xml = bat.ToString();

			var ret = list.ParentWeb.ProcessBatchData(xml);
			return ret;
		}

		#endregion

		#region 更新

		/// <summary>
		/// アイテム情報を指定して、
		/// リストのアイテムを更新します。
		/// </summary>
		/// <param name="this">SPList</param>
		/// <param name="item">アイテム情報</param>
		/// <returns>SPList のインスタンスを返します。</returns>
		public static SPList UpdateItem(this SPList @this, IdentifiedListItem item) {
			if (!item.ID.HasValue) {
				return @this.AddItem(item.Cells);
			}

			@this.GetItemById(item.ID.Value).Update(item.Cells);

			return @this;
		}

		/// <summary>
		/// 列名と値の連想配列を指定して、
		/// リストにアイテムを 1 件ずつ追加します。
		/// </summary>
		/// <param name="list">SPList</param>
		/// <param name="items">列名と値の連想配列</param>
		public static void UpdateItemsOneByOne(this SPList list, params IdentifiedListItem[] items)
			=> items.ToList().ForEach(i => list.UpdateItem(i));

		/// <summary>
		/// 列名と値の連想配列を指定して、
		/// リストのアイテムを更新します。(バッチ処理)
		/// </summary>
		/// <param name="list">SPList</param>
		/// <param name="items">リストアイテムの配列</param>
		/// <returns>結果を含む文字列を返します。</returns>
		public static string UpdateItemsByBatch(this SPList list, params IdentifiedListItem[] items) {
			var bat = new UpdateBatch(list.ID, items);
			var xml = bat.ToString();

			var ret = list.ParentWeb.ProcessBatchData(xml);
			return ret;
		}

		#endregion

		#region 削除

		/// <summary>
		/// 削除対象のアイテムIDの配列を指定して、
		/// リストのアイテムを削除します。(バッチ処理)
		/// </summary>
		/// <param name="list">SPList</param>
		/// <param name="itemIds">アイテムIDの配列</param>
		/// <returns>結果を含む文字列を返します。</returns>
		public static string DeleteByBatch(this SPList list, params int[] itemIds) {
			var bat = new DeleteBatch(list.ID, itemIds);
			var xml = bat.ToString();

			var ret = list.ParentWeb.ProcessBatchData(xml);
			return ret;
		}

		/// <summary>
		/// 条件を指定して、
		/// リストのアイテムを削除します。(バッチ処理)
		/// </summary>
		/// <param name="list">SPList</param>
		/// <param name="query">条件</param>
		/// <param name="withRecycleBin">ゴミ箱を空にするかどうか</param>
		/// <returns>結果を含む文字列を返します。</returns>
		public static string DeleteByBatch(this SPList list, SPQuery query, bool withRecycleBin = true) {
			var itemIds = list.GetItemIds(query).ToArray();
			var ret = list.DeleteByBatch(itemIds);

			if (withRecycleBin) {
				list.ParentWeb.RecycleBin.DeleteAll();
			}

			return ret;
		}

		/// <summary>
		/// リストの全てのアイテムを削除します。(バッチ処理)
		/// </summary>
		/// <param name="list">SPList</param>
		/// <param name="withRecycleBin">ゴミ箱を空にするかどうか</param>
		/// <returns>結果を含む文字列を返します。</returns>
		public static string DeleteAllByBatch(this SPList list, bool withRecycleBin = true) {
			var itemIds = list.GetItemIds().ToArray();
			var ret = list.DeleteByBatch(itemIds);

			if (withRecycleBin) {
				list.ParentWeb.RecycleBin.DeleteAll();
			}

			return ret;
		}

		#endregion

		#region 取得

		#region ID取得

		/// <summary>
		/// リストアイテムのIDのコレクションを取得します。
		/// </summary>
		/// <param name="list">SPList</param>
		/// <returns>リストアイテムのIDのコレクションを返します。</returns>
		public static IEnumerable<int> GetItemIds(this SPList list)
			=> list.GetItems("ID")?.Cast<SPListItem>()?.Select(i => i.ID);

		/// <summary>
		/// 条件を指定して、
		/// リストアイテムのIDのコレクションを取得します。
		/// </summary>
		/// <param name="list">SPList</param>
		/// <param name="query">条件</param>
		/// <returns>リストアイテムのIDのコレクションを返します。</returns>
		public static IEnumerable<int> GetItemIds(this SPList list, SPQuery query)
			=> list.GetItems(query)?.Cast<SPListItem>()?.Select(i => i.ID);

		#endregion

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

		#endregion
	}
}
