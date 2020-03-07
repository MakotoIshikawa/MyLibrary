using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Reflection;

namespace XmlLibrary.Extensions {
	/// <summary>
	/// <see cref="Type"/> を拡張するメソッドを提供します。
	/// </summary>
	public static partial class TypeExtension {
		/// <summary>
		/// 指定した型宣言から、要素名を取得します。
		/// </summary>
		/// <param name="this"><see cref="Type"/></param>
		/// <returns>要素名を返します。</returns>
		public static XName GetElementName(this Type @this)
			=> @this.GetCustomAttribute<XmlRootAttribute>()?.ElementName;
	}
}
