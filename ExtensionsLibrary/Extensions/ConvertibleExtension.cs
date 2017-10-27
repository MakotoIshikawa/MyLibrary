using System;
using System.Linq;

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
		/// <param name="this"><see cref="IConvertible"/> インターフェイスを実装するオブジェクト。</param>
		/// <param name="conversionType">返すオブジェクトの型。</param>
		/// <returns>型が conversionType であり、@this と等価の値を持つオブジェクト。</returns>
		public static object ChangeType(this IConvertible @this, Type conversionType)
			=> conversionType.IsNullable()
				? @this?.ChangeTypeOrEnum(conversionType.GenericTypeArguments.First())
				: @this.ChangeTypeOrEnum(conversionType);

		private static object ChangeTypeOrEnum(this IConvertible @this, Type conversionType)
			=> conversionType.IsEnum
				? Enum.Parse(conversionType, @this?.ToString())
				: Convert.ChangeType(@this, conversionType);

		#endregion

		#region OfType

		/// <summary>
		/// 指定されたオブジェクトと等しい値を持つ、<typeparamref name="TChange"/> 型のオブジェクトを返します。
		/// </summary>
		/// <typeparam name="TChange"></typeparam>
		/// <param name="this"><see cref="IConvertible"/> インターフェイスを実装するオブジェクト。</param>
		/// <returns>型が <typeparamref name="TChange"/> であり、@this と等価の値を持つオブジェクト。</returns>
		public static TChange OfType<TChange>(this IConvertible @this)
			=> (TChange)@this.ChangeType(typeof(TChange));

		#endregion

		#endregion
	}
}
