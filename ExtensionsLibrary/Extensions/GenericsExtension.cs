using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// ジェネリックスを拡張するメソッドを提供します。
	/// </summary>
	public static partial class GenericsExtension {
		#region メソッド

		#region 値取得

		#region GetValueOrDefault (+1 オーバーロード)

		/// <summary>
		/// null かどうかを判定して値を取得します。
		/// </summary>
		/// <typeparam name="T">値を取得するインスタンスの型</typeparam>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="this">値を取得するインスタンス</param>
		/// <param name="func">値を取得するメソッド</param>
		/// <returns>null かどうかを判定して値を返します。</returns>
		public static TResult GetValueOrDefault<T, TResult>(this T @this, Func<T, TResult> func)
			=> @this.GetValueOrDefault(func, default);

		/// <summary>
		/// null かどうかを判定して値を取得します。
		/// </summary>
		/// <typeparam name="T">値を取得するインスタンスの型</typeparam>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="this">値を取得するインスタンス</param>
		/// <param name="func">値を取得するメソッド</param>
		/// <param name="defaultValue">default 値</param>
		/// <returns>null かどうかを判定して値を返します。</returns>
		public static TResult GetValueOrDefault<T, TResult>(this T @this, Func<T, TResult> func, TResult defaultValue) {
			try {
				return (func != null)
					? func(@this)
					: defaultValue;
			} catch {
				return defaultValue;
			}
		}

		#endregion

		/// <summary>
		/// null かどうかを判定してコレクションを取得します。
		/// </summary>
		/// <typeparam name="T">値を取得するインスタンスの型</typeparam>
		/// <typeparam name="TResult">戻り値コレクションの型</typeparam>
		/// <param name="this">値を取得するインスタンス</param>
		/// <param name="func">値を取得するメソッド</param>
		/// <returns>null かどうかを判定してコレクションを返します。</returns>
		public static IEnumerable<TResult> GetCollection<T, TResult>(this T @this, Func<T, IEnumerable<TResult>> func) {
			try {
				return @this.GetValueOrDefault(v => func(v)) ?? Enumerable.Empty<TResult>();
			} catch {
				return Enumerable.Empty<TResult>();
			}
		}

		/// <summary>
		/// null かどうかを判定して文字列を取得します。
		/// </summary>
		/// <typeparam name="T">値を取得するインスタンスの型</typeparam>
		/// <param name="this">値を取得するインスタンス</param>
		/// <param name="func">文字列を取得するメソッド</param>
		/// <returns>null かどうかを判定して文字列を返します。</returns>
		public static string GetString<T>(this T @this, Func<T, string> func) {
			try {
				return func?.Invoke(@this) ?? string.Empty;
			} catch {
				return string.Empty;
			}
		}

		#endregion

		#region 型コード取得

		/// <summary>
		/// 基になる <see cref="TypeCode"/> を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">インスタンス</param>
		/// <returns>基になる <see cref="TypeCode"/> を返します。
		/// <paramref name="this"/> が null の場合は <see cref="TypeCode.Empty"/>。</returns>
		public static TypeCode GetTypeCode<T>(this T @this) {
			return @this.GetType().GetTypeCode();
		}

		#endregion

		#region メンバ情報取得

		/// <summary>
		/// パブリックなフィールドとプロパティの情報を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">インスタンス</param>
		/// <returns>メンバー情報を返します。</returns>
		public static IEnumerable<(string Name, Type Type, object Value, TypeCode Code, MemberTypes MemberType)> GetMembers<T>(this T @this) {
			var type = @this.GetType();
			var fields = type.GetFields();
			var properties = type.GetPropertiesWithoutIndexer();

			var ms = fields.Select(f => new {
				f.Name,
				Type = f.FieldType,
				Value = f.GetValue(@this),
				Code = f.FieldType.GetTypeCode(),
				f.MemberType,
			}).Union(properties.Select(p => new {
				p.Name,
				Type = p.PropertyType,
				Value = p.GetValue(@this),
				Code = p.PropertyType.GetTypeCode(),
				p.MemberType,
			})).ToList();

			switch (@this) {
			case var v when v.GetType().IsEnum:
				return ms.Select(m => (Name: m.Name is "value__" ? "Value" : m.Name, m.Type, m.Value, m.Code, m.MemberType));
			case string _:
			case decimal _:
			case DateTime _:
			case var v when v.GetType().IsPrimitive:
				ms.Add(new {
					Name = "Value",
					Type = type,
					Value = (object)@this,
					Code = @this.GetTypeCode(),
					MemberType = MemberTypes.Field,
				});
				break;
			}

			return ms.Select(m => (m.Name, m.Type, m.Value, m.Code, m.MemberType));
		}

		/// <summary>
		/// パブリックなフィールドとプロパティの情報の文字列を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">インスタンス</param>
		/// <param name="nullShow">NULL を表示するかどうか</param>
		/// <returns>メンバー情報の文字列を返します。</returns>
		public static string GetMembersString<T>(this T @this, bool nullShow = false)
			=> @this.GetMembers().ToString(nullShow);

		#endregion

		#region プロパティ情報

		/// <summary>
		/// プロパティ名を指定して、プロパティ情報を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="name">プロパティ名</param>
		/// <returns>プロパティ情報を返します。</returns>
		public static PropertyInfo GetPropertyInfo<T>(this T @this, string name)
			=> @this.GetType().GetProperty(name);

		#region 値取得

		/// <summary>
		/// プロパティ名を指定して、値を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="name">プロパティ名</param>
		/// <returns>値を返します。</returns>
		public static object GetPropertyValue<T>(this T @this, string name) {
			var info = @this.GetPropertyInfo(name);
			return info.CanRead
				? info.GetValue(@this)
				: null;
		}

		#endregion

		#region 値設定

		/// <summary>
		/// プロパティ名を指定して、値を設定します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="name">プロパティ名</param>
		/// <param name="value">設定する値</param>
		public static void SetPropertyValue<T>(this T @this, string name, object value) {
			var prop = @this.GetPropertyInfo(name);
			if (!prop.CanWrite) {
				return;
			}

			var propType = prop.PropertyType;
			if(propType == value.GetType()) {
				prop.SetValue(@this, value);
				return;
			}

			switch (value) {
			case IConvertible convertible when propType.IsPrimitive | propType.IsEnum:
				prop.SetValue(@this, convertible.ChangeType(propType));
				break;
			case null when propType.IsNullable():
				prop.SetValue(@this, null);
				break;
			default:
				prop.SetValue(@this, value);
				break;
			}
		}

		#endregion

		/// <summary>
		/// プロパティ情報のコレクションを取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <returns>プロパティ情報のコレクションを返します。</returns>
		public static IEnumerable<PropertyInfo> GetPropertyInfos<T>(this T @this)
			=> @this.GetType().GetProperties();

		/// <summary>
		/// プロパティ名と値の KeyValuePair のコレクションを指定して、
		/// 対象のインスタンスのプロパティに値を設定します。
		/// </summary>
		/// <typeparam name="T">対象のインスタンスの型</typeparam>
		/// <param name="this">T</param>
		/// <param name="properties">プロパティ名と値の KeyValuePair のコレクション</param>
		/// <returns>プロパティを設定した値を返します。</returns>
		public static T SetProperties<T>(this T @this, IEnumerable<KeyValuePair<string, object>> properties) {
			properties.ForEach(p => @this.SetPropertyValue(p.Key, p.Value));
			return @this;
		}

		/// <summary>
		/// プロパティの Dictionary に変換します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="predicate">フィルターする条件</param>
		/// <returns>Dictionary を返します。</returns>
		public static Dictionary<string, object> ToPropertyDictionary<T>(this T @this, Func<PropertyInfo, bool> predicate = null) {
			var properties = @this.GetPropertyInfos();
			return predicate == null
				? properties.ToDictionary(p => p.Name, p => p.GetValue(@this))
				: properties.Where(predicate).ToDictionary(p => p.Name, p => p.GetValue(@this));
		}

		/// <summary>
		/// プロパティの情報を列挙します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="predicate">フィルターする条件</param>
		/// <returns>プロパティの情報の列挙を返します。</returns>
		public static IEnumerable<(string Name, Type Type, object Value, TypeCode Code, MemberTypes MemberType)> GetProperties<T>(this T @this, Func<PropertyInfo, bool> predicate = null) {
			var properties = (predicate is null)
				? @this.GetPropertyInfos()
				: @this.GetPropertyInfos().Where(predicate);

			return
				from p in properties
				let typ = p.PropertyType
				let val = p.GetValue(@this)
				let tcd = typ.GetTypeCode()
				select (p.Name, Type: typ, Value: val, Code: tcd, p.MemberType);
		}

		/// <summary>
		/// プロパティ情報の文字列を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">インスタンス</param>
		/// <param name="nullShow">NULL を表示するかどうか</param>
		/// <returns>プロパティ情報の文字列を返します。</returns>
		public static string GetPropertiesString<T>(this T @this, bool nullShow = false)
			=> @this.GetProperties().ToString(nullShow);

		#endregion

		#region フィールド情報

		/// <summary>
		/// フィールド名を指定して、フィールド情報を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="name">フィールド名</param>
		/// <returns>フィールド情報を返します。</returns>
		public static FieldInfo GetFieldInfo<T>(this T @this, string name)
			=> @this.GetType().GetField(name);

		#region 値取得

		/// <summary>
		/// フィールド名を指定して、値を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="name">フィールド名</param>
		/// <returns>値を返します。</returns>
		public static object GetFieldValue<T>(this T @this, string name) {
			var info = @this.GetFieldInfo(name);
			return info.IsPublic
				? info.GetValue(@this)
				: null;
		}

		#endregion

		#region 値設定

		/// <summary>
		/// フィールド名を指定して、値を設定します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="name">フィールド名</param>
		/// <param name="value">設定する値</param>
		public static void SetFieldValue<T>(this T @this, string name, object value) {
			var info = @this.GetFieldInfo(name);
			if (!info.IsPublic) {
				return;
			}

			var val = (value as IConvertible)?.ChangeType(info.FieldType) ?? value;
			info.SetValue(@this, val);
		}

		#endregion

		/// <summary>
		/// フィールド情報のコレクションを取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <returns>フィールド情報のコレクションを返します。</returns>
		public static IEnumerable<FieldInfo> GetFieldInfos<T>(this T @this)
			=> @this.GetType().GetFields();

		/// <summary>
		/// フィールド名と値の KeyValuePair のコレクションを指定して、
		/// 対象のインスタンスのフィールドに値を設定します。
		/// </summary>
		/// <typeparam name="T">対象のインスタンスの型</typeparam>
		/// <param name="this">T</param>
		/// <param name="fields">フィールド名と値の KeyValuePair のコレクション</param>
		/// <returns>フィールドを設定した値を返します。</returns>
		public static T SetFields<T>(this T @this, IEnumerable<KeyValuePair<string, object>> fields) {
			fields.ForEach(p => @this.SetFieldValue(p.Key, p.Value));
			return @this;
		}

		/// <summary>
		/// フィールドの Dictionary に変換します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="predicate">フィルターする条件</param>
		/// <returns>Dictionary を返します。</returns>
		public static Dictionary<string, object> ToFieldDictionary<T>(this T @this, Func<FieldInfo, bool> predicate = null) {
			var fields = @this.GetFieldInfos();
			return predicate == null
				? fields.ToDictionary(p => p.Name, p => p.GetValue(@this))
				: fields.Where(predicate).ToDictionary(p => p.Name, p => p.GetValue(@this));
		}

		/// <summary>
		/// フィールドの情報を列挙します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">対象のインスタンス</param>
		/// <param name="predicate">フィルターする条件</param>
		/// <returns>フィールドの情報の列挙を返します。</returns>
		public static IEnumerable<(string Name, Type Type, object Value, TypeCode Code, MemberTypes MemberType)> GetFields<T>(this T @this, Func<FieldInfo, bool> predicate = null) {
			var fields = (predicate is null)
				? @this.GetFieldInfos()
				: @this.GetFieldInfos().Where(predicate);

			return
				from f in fields
				let typ = f.FieldType
				let val = f.GetValue(@this)
				let tcd = typ.GetTypeCode()
				select (f.Name, Type: typ, Value: val, Code: tcd, f.MemberType);
		}

		/// <summary>
		/// フィールド情報の文字列を取得します。
		/// </summary>
		/// <typeparam name="T">インスタンスの型</typeparam>
		/// <param name="this">インスタンス</param>
		/// <param name="nullShow">NULL を表示するかどうか</param>
		/// <returns>フィールド情報の文字列を返します。</returns>
		public static string GetFieldsString<T>(this T @this, bool nullShow = false)
			=> @this.GetFields().ToString(nullShow);

		#endregion

		private static string ToString(this IEnumerable<(string Name, Type Type, object Value, TypeCode Code, MemberTypes MemberType)> @this, bool nullShow) {
			var query =
				from p in @this
				let isNull = p.Value is null
				let code = p.Code
				let str = p.Value?.ToString() ?? "null"
				let value = (code == TypeCode.String) ? $@"""{str}""" : str
				select new {
					NameValue = $"{p.Name} = {value}",
					IsNull = isNull,
				};

			return nullShow
				? query.Select(p => p.NameValue).Join(", ")
				: query.Where(p => !p.IsNull).Select(p => p.NameValue).Join(", ");
		}

		#endregion
	}
}