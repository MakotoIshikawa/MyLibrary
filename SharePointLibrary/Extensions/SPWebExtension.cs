using System;
using Microsoft.SharePoint;

namespace SharePointLibrary.Extensions {
	/// <summary>
	/// SPWeb を拡張するメソッドを提供します。
	/// </summary>
	public static partial class SPWebExtension {
		#region メソッド

		#region リスト取得

		/// <summary>
		/// リストの内部名を指定して、
		/// リストを取得します。
		/// </summary>
		/// <param name="this">SPWeb</param>
		/// <param name="internalName">リストの内部名</param>
		/// <returns>SPList のインスタンスを返します。</returns>
		public static SPList GetListByInternalName(this SPWeb @this, string internalName)
			=> @this.GetListByUri(@this.GetListUrl(internalName));

		/// <summary>
		/// リストの URI を指定して、
		/// リストを取得します。
		/// </summary>
		/// <param name="this">SPWeb</param>
		/// <param name="uri">URI</param>
		/// <returns>SPList のインスタンスを返します。</returns>
		public static SPList GetListByUri(this SPWeb @this, Uri uri)
			=> @this.GetList(uri.AbsolutePath);

		/// <summary>
		/// リストの URL を取得します。
		/// </summary>
		/// <param name="this">SPWeb</param>
		/// <param name="internalName">リストの内部名</param>
		/// <returns>リストの URL を返します。</returns>
		public static Uri GetListUrl(this SPWeb @this, string internalName)
			=> new Uri($"{@this.Url}/Lists/{internalName}");

		#endregion

		#endregion
	}
}
