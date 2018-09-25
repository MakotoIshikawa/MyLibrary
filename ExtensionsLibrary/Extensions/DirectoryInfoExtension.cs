using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// DirectoryInfo を拡張するメソッドを提供します。
	/// </summary>
	public static partial class DirectoryInfoExtension {
		#region メソッド

		#region 作成

		/// <summary>
		/// ファイル名を指定して、ファイル情報を作成します。
		/// </summary>
		/// <param name="this">DirectoryInfo</param>
		/// <param name="fileName">ファイル名</param>
		/// <returns>ファイル情報を返します。</returns>
		public static FileInfo CreateFileInfo(this DirectoryInfo @this, string fileName)
			=> new FileInfo(Path.Combine(@this.FullName, fileName));

		/// <summary>
		/// ディレクトリー名を指定して、
		/// 子ディレクトリーの情報を作成します。
		/// </summary>
		/// <param name="this">DirectoryInfo</param>
		/// <param name="name">ディレクトリー名</param>
		/// <returns>ディレクトリー情報を返します。</returns>
		public static DirectoryInfo CreateChild(this DirectoryInfo @this, string name) {
			var child = new DirectoryInfo(Path.Combine(@this.FullName, name));
			if (!child.Exists) {
				child.Create();
			}

			return child;
		}

		#endregion

		#region GetFileInfos (+1 オーバーロード)

		/// <summary>
		/// ディレクトリ内のファイル情報を列挙します。
		/// </summary>
		/// <param name="this">DirectoryInfo</param>
		/// <param name="searchPattern">ファイル名と照合する検索文字列。</param>
		/// <param name="searchOption">
		/// <para>検索操作に現在のディレクトリのみか、すべてのサブディレクトリを含めるのかを指定する</para>
		/// </param>
		/// <returns>ファイル情報の列挙を返します。</returns>
		public static IEnumerable<FileInfo> GetFileInfos(this DirectoryInfo @this, string searchPattern = null, SearchOption searchOption = SearchOption.TopDirectoryOnly) {
			var files = @this.EnumerateFiles(searchPattern.IsEmpty() ? "*" : searchPattern, searchOption);
			return files;
		}

		/// <summary>
		/// ディレクトリ内のファイル情報を列挙します。
		/// </summary>
		/// <param name="this">DirectoryInfo</param>
		/// <param name="all">すべてのサブディレクトリを含めるのかを指定する。</param>
		/// <param name="excludes">除外パターン</param>
		/// <returns>ファイル情報の列挙を返します。</returns>
		public static IEnumerable<FileInfo> GetFileInfos(this DirectoryInfo @this, bool all, params string[] excludes) {
			var files = @this.GetFileInfos(searchOption: all ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
				.Where(fi => !fi.IsHidden());

			if (!(excludes?.Any() ?? false)) {
				return files;
			}

			return files.Where(f => !excludes.Contains(f.Extension));
		}

		#endregion

		#region 属性判定

		/// <summary>
		/// 隠しファイルかどうかを判定します。
		/// </summary>
		/// <param name="this">FileInfo</param>
		/// <returns>隠しファイル属性であれば true を返します。</returns>
		public static bool IsHidden(this FileSystemInfo @this) {
			var atr = FileAttributes.Hidden;
			return HasAttribute(@this, atr);
		}

		/// <summary>
		/// 指定した属性を持っているか判定します。
		/// </summary>
		/// <param name="this">FileInfo</param>
		/// <param name="attribute">属性</param>
		/// <returns>属性を持っていれば true を返します。</returns>
		public static bool HasAttribute(this FileSystemInfo @this, FileAttributes attribute)
			=> (@this.Attributes & attribute) == attribute;

		#endregion

		#endregion
	}
}
