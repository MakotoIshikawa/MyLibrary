using System.IO;
using ExtensionsLibrary.Extensions;
using NotesAnalysisLibrary.Data;
using XmlLibrary.Extensions;

namespace NotesAnalysisLibrary.Extensions {
    /// <summary>
    /// <see cref="FileInfo"/> を拡張するメソッドを提供します。
    /// </summary>
	public static partial class FileInfoExtension {
        /// <summary>
        /// Notes DB 情報の XML ファイルを Markdown ファイルに変換します。
        /// </summary>
        /// <param name="this"><see cref="FileInfo"/></param>
        public static void ConvertMarkdown(this FileInfo @this) {
            var xmlData = @this.DeSerializeFromXml<NotesDatabaseInfo>();
            var md = @this.Directory.CreateFileInfo($"{xmlData.Title}.md");
            using (var sw = md.CreateText()) {
                xmlData.WriteMarkdown(sw);
            }
        }
    }
}
