using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// <see cref="IConvertible"/> インターフェイス実装したクラスを拡張するメソッドを提供します。
	/// </summary>
	public static partial class ConvertibleExtension {
		#region メソッド

		#region ChangeType

		/// <summary>
		/// 指定されたオブジェクトと等しい値を持つ、指定された型のオブジェクトを返します。
		/// </summary>
		/// <typeparam name="TConvertible">IConvertible 型</typeparam>
		/// <param name="this">IConvertible インターフェイスを実装するオブジェクト。</param>
		/// <param name="conversionType">返すオブジェクトの型。</param>
		/// <returns>型が conversionType であり、@this と等価の値を持つオブジェクト。</returns>
		public static object ChangeType<TConvertible>(this TConvertible @this, Type conversionType)
			where TConvertible : IConvertible
			=> conversionType.IsNullable()
				? (@this == null)
					? null
					: Convert.ChangeType(@this, conversionType.GenericTypeArguments.First())
				: Convert.ChangeType(@this, conversionType);

		#endregion

		#endregion
	}
}
