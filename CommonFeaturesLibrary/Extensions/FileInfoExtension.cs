using System.IO;
using ExtensionsLibrary.Extensions;

namespace CommonFeaturesLibrary.Extensions {
	/// <summary>
	/// <see cref="FileInfo"/> を拡張するメソッドを提供します。
	/// </summary>
	public static partial class FileInfoExtension {
		#region メソッド

		#region GetFileNameWithVersion

		/// <summary>
		/// バージョン番号を付与したファイル情報を取得します。
		/// </summary>
		/// <param name="this"><see cref="FileInfo"/></param>
		/// <param name="version">バージョン番号</param>
		/// <returns>バージョン番号を付与したファイル情報を返します。</returns>
		public static FileInfo GetFileNameWithVersion(this FileInfo @this, uint version)
			=> new FileInfo(@this.FullName.GetFileNameWithVersion(version));

		/// <summary>
		/// バージョン番号を付与したファイル名を取得します。
		/// </summary>
		/// <param name="this"><see cref="string"/></param>
		/// <param name="version">バージョン番号</param>
		/// <returns>バージョン番号を付与したファイル名を返します。</returns>
		public static string GetFileNameWithVersion(this string @this, uint version) {
			if (version <= 0) {
				return @this;
			}

			var dir = Path.GetDirectoryName(@this);
			var ext = Path.GetExtension(@this);
			var name = Path.GetFileNameWithoutExtension(@this);
			return Path.Combine(dir, $@"{name} ({version}){ext}");
		}

		#endregion

		#endregion
	}
}
