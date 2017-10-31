﻿using System;
using Microsoft.SharePoint;
using ExtensionsLibrary.Extensions;

namespace SharePointLibrary.Extensions {
	/// <summary>
	/// SPListItem を拡張するメソッドを提供します。
	/// </summary>
	public static partial class SPListItemExtension {
		#region メソッド

		#region フィールド値取得

		/// <summary>
		/// 内部名を指定して、フィールドの値を文字列として取得します。
		/// </summary>
		/// <param name="this">SPListItem</param>
		/// <param name="name">フィールドの内部名</param>
		/// <returns>フィールドの値を文字列を返します。</returns>
		public static string GetFieldText(this SPListItem @this, string name) {
			try {
				var field = @this.Fields.TryGetFieldByStaticName(name);
				return field.GetFieldValueAsText(@this[name]);
			} catch (Exception) {
				return string.Empty;
			}
		}

		public static object GetFieldValue(this SPListItem @this, string name) {
			try {
				return @this[name];
			} catch (Exception) {
				return null;
			}
		}

		/// <summary>
		/// 内部名を指定して、フィールドの数値を取得します。
		/// </summary>
		/// <param name="this">SPListItem</param>
		/// <param name="name">フィールドの内部名</param>
		/// <returns>フィールドの数値を返します。</returns>
		public static int? GetFieldNumber(this SPListItem @this, string name) {
			try {
				var field = @this.Fields.TryGetFieldByStaticName(name);
				return int.Parse(field.GetFieldValueAsText(@this[name]));
			} catch (Exception) {
				return null;
			}
		}

		/// <summary>
		/// 内部名を指定して、フィールドの bool 値を取得します。
		/// </summary>
		/// <param name="this">SPListItem</param>
		/// <param name="name">フィールドの内部名</param>
		/// <returns>フィールドの bool 値を返します。</returns>
		public static bool? GetFieldBoolean(this SPListItem @this, string name) {
			try {
				var field = @this.Fields.TryGetFieldByStaticName(name);
				var val = field.GetFieldValueAsText(@this[name]);
				if (string.IsNullOrEmpty(val)) {
					return null;
				}

				return (val == "はい" || val.ToLower() == "yes");
			} catch (Exception) {
				return null;
			}
		}

		/// <summary>
		/// 内部名を指定して、フィールドの DateTime 値を取得します。
		/// </summary>
		/// <param name="this">SPListItem</param>
		/// <param name="name">フィールドの内部名</param>
		/// <returns>フィールドの DateTime 値を返します。</returns>
		public static DateTime? GetFieldDateTime(this SPListItem @this, string name) {
			return @this.GetFieldText(name).ToNullable(v => Convert.ToDateTime(v));
		}

		#endregion

		#endregion
	}
}
