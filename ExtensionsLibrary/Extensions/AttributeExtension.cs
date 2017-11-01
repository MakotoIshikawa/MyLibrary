using System;
using System.Reflection;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Attribute を拡張するメソッドを提供します。
	/// </summary>
	public static partial class AttributeExtension {
		#region メソッド

		/// <summary>
		/// カスタム属性が型のメンバーに適用されているかどうかを判断します。
		/// </summary>
		/// <typeparam name="TAttribute">Attribute を継承しているクラス</typeparam>
		/// <param name="this">MemberInfo</param>
		/// <returns>
		/// カスタム属性が型のメンバーに適用されていれば true
		/// それ以外は、false を返します。
		/// </returns>
		public static bool IsDefined<TAttribute>(this MemberInfo @this) where TAttribute : Attribute
			=> Attribute.IsDefined(@this, typeof(TAttribute));

		#endregion
	}
}
