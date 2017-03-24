﻿using System;
using System.Linq;
using System.Reflection;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Type を拡張するメソッドを提供します。
	/// </summary>
	public static partial class TypeExtension {
		#region インデクサ

		#region GetIndexer

		/// <summary>
		/// インデクサを取得します。
		/// </summary>
		/// <param name="this"><see cref="System.Type" /></param>
		/// <returns>インデクサを返します。</returns>
		public static PropertyInfo GetIndexer(this Type @this) {
			return @this.GetProperty(@this.GetIndexerName());
		}

		/// <summary>
		/// インデクサを取得します。
		/// </summary>
		/// <param name="this"><see cref="System.Type" /></param>
		/// <param name="returnType">プロパティの戻り値の型。</param>
		/// <returns>インデクサを返します。</returns>
		public static PropertyInfo GetIndexer(this Type @this, Type returnType) {
			return @this.GetProperty(@this.GetIndexerName(), returnType);
		}

		/// <summary>
		/// インデクサを取得します。
		/// </summary>
		/// <param name="this"><see cref="System.Type" /></param>
		/// <param name="types">取得するインデックス付きプロパティに対するパラメーターの数値、順序、および型を表す System.Type オブジェクトの配列。 または インデックス付けされていないプロパティを取得するための、System.Type 型の空の配列 (Type[] types = new Type[0])。</param>
		/// <returns>インデクサを返します。</returns>
		public static PropertyInfo GetIndexer(this Type @this, Type[] types) {
			return @this.GetProperty(@this.GetIndexerName(), types);
		}

		/// <summary>
		/// インデクサを取得します。
		/// </summary>
		/// <param name="this"><see cref="System.Type" /></param>
		/// <param name="returnType">プロパティの戻り値の型。</param>
		/// <param name="types">取得するインデックス付きプロパティに対するパラメーターの数値、順序、および型を表す System.Type オブジェクトの配列。 または インデックス付けされていないプロパティを取得するための、System.Type 型の空の配列 (Type[] types = new Type[0])。</param>
		/// <returns>インデクサを返します。</returns>
		public static PropertyInfo GetIndexer(this Type @this, Type returnType, Type[] types) {
			return @this.GetProperty(@this.GetIndexerName(), returnType, types);
		}

		/// <summary>
		/// インデクサを取得します。
		/// </summary>
		/// <param name="this"><see cref="System.Type" /></param>
		/// <param name="returnType">プロパティの戻り値の型。</param>
		/// <param name="types">取得するインデックス付きプロパティに対するパラメーターの数値、順序、および型を表す System.Type オブジェクトの配列。 または インデックス付けされていないプロパティを取得するための、System.Type 型の空の配列 (Type[] types = new Type[0])。</param>
		/// <param name="modifiers">types 配列内の対応する要素に関連付けられている属性を表す System.Reflection.ParameterModifier オブジェクトの配列。既定のバインダーは、このパラメーターを処理しません。</param>
		/// <returns>インデクサを返します。</returns>
		public static PropertyInfo GetIndexer(this Type @this, Type returnType, Type[] types, ParameterModifier[] modifiers) {
			return @this.GetProperty(@this.GetIndexerName(), returnType, types, modifiers);
		}

		#endregion

		/// <summary>
		/// インデクサの名前を取得します。
		/// </summary>
		/// <param name="this"><see cref="System.Type" /></param>
		/// <returns>インデクサの名前を返します。</returns>
		public static string GetIndexerName(this Type @this) {
			if (!@this.GetIndexers().Any()) {
				return string.Empty;
			}

			var attr = @this.GetCustomAttribute<DefaultMemberAttribute>();
			if (attr != null) {
				return attr.MemberName;
			}

			return "Item";
		}

		/// <summary>
		/// インデクサ情報の配列を取得します。
		/// </summary>
		/// <param name="this"><see cref="System.Type" /></param>
		/// <returns>インデクサ情報の配列を返します。</returns>
		public static PropertyInfo[] GetIndexers(this Type @this) {
			return @this.GetDefaultMembers().OfType<PropertyInfo>().ToArray();
		}

		#endregion

		/// <summary>
		/// Nullable かどうかを判定します。
		/// </summary>
		/// <param name="this"></param>
		/// <returns>Nullable かどうかを返します。</returns>
		public static bool IsNullable(this Type @this) {
			return @this.IsGenericType && @this.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
	}
}