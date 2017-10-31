using System;
using System.Linq;
using System.Collections.Generic;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Object を拡張するメソッドを提供します。
	/// </summary>
	public static partial class ObjectExtension {
		#region メソッド

		#region Boolean 型変換

		/// <summary>
		/// Boolean 型に変換します。
		/// </summary>
		/// <param name="this">object</param>
		/// <returns>変換した Boolean 値を返します。</returns>
		public static bool ToBoolean<T>(this T @this)
			=> Convert.ToBoolean(@this);

		#endregion

		#endregion
	}
}
