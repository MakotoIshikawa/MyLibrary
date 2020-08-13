using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExtensionsLibrary.Extensions {
	using static BindingFlags;

	/// <summary>
	/// Type を拡張するメソッドを提供します。
	/// </summary>
	public static partial class TypeExtension {
		#region インデクサー

		/// <summary>
		/// インデクサーの名前を取得します。
		/// </summary>
		/// <param name="this"><see cref="Type"/></param>
		/// <returns>インデクサーの名前を返します。</returns>
		public static string GetIndexerName(this Type @this) {
			var indexers = @this.GetIndexers().Select(i => i.Info);
			var name = indexers.FirstOrDefault()?.Name;
			return name;
		}

		/// <summary>
		/// インデクサー情報と、そのパラメーター情報の列挙を取得します。
		/// </summary>
		/// <param name="this"><see cref="Type"/></param>
		/// <returns>インデクサー情報と、そのパラメーター情報の列挙を返します。</returns>
		public static IEnumerable<(PropertyInfo Info, ParameterInfo[] IndexParameters)> GetIndexers(this Type @this) {
			var defaultMembers = @this.GetDefaultMembers().OfType<PropertyInfo>();
			var indexers = (
				from i in defaultMembers
				let pi = i.GetIndexParameters()
				where
					pi.Length > 0
				select (
					Info: i,
					IndexParameters: pi
				)
			);

			return indexers;
		}

		#endregion

		#region プロパティ情報取得

		/// <summary>
		/// インデクサーを除いた、<see cref="Type"/> のプロパティ情報を取得します。
		/// </summary>
		/// <param name="this"><see cref="Type"/></param>
		/// <param name="bindingAttr">検索を実施する方法を指定する列挙値のビットごとの組み合わせ。</param>
		/// <returns>インデクサーを除いた、プロパティ情報を返します。</returns>
		public static PropertyInfo[] GetPropertiesWithoutIndexer(this Type @this, BindingFlags bindingAttr = Instance | Static | Public) {
			var indexerName = @this.GetIndexerName();
			var properties = @this.GetProperties(bindingAttr).Where(p => p.Name != indexerName);
			return properties.ToArray();
		}

		#endregion


		#region 型コード取得

		/// <summary>
		/// 指定された <see cref="Type" /> の基になる <see cref="TypeCode"/> を取得します。
		/// </summary>
		/// <param name="this">基になる <see cref="TypeCode" /> を取得する <see cref="Type"/>。</param>
		/// <returns>基になる <see cref="TypeCode"/> を返します。
		/// <paramref name="this"/> が null の場合は <see cref="TypeCode.Empty"/>。</returns>
		public static TypeCode GetTypeCode(this Type @this)
			=> Type.GetTypeCode(@this);

		#endregion

		#region Nullable 判定

		/// <summary>
		/// <see cref="Nullable"/> かどうかを判定します。
		/// </summary>
		/// <param name="this"><see cref="Type"/></param>
		/// <returns><see cref="Nullable"/> かどうかを返します。</returns>
		public static bool IsNullable(this Type @this)
			=> @this.IsGenericType && @this.GetGenericTypeDefinition() == typeof(Nullable<>);

		#endregion
	}
}
