using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensionsLibrary.Extensions;

namespace NotesAnalysisLibrary.Extensions {
    /// <summary>
    /// ジェネリックスを拡張するメソッドを提供します。
    /// </summary>
	public static partial class GenericsExtension {
        #region メソッド

        /// <summary>
        /// プロパティ情報を Markdown 形式のリスト文字列に変換します。
        /// </summary>
        /// <typeparam name="T">インスタンスの型</typeparam>
        /// <param name="this">対象のインスタンス</param>
        /// <returns>Markdown 形式のリスト文字列を返します。</returns>
        public static string GetPropertiesMarkdownList<T>(this T @this) {
            var pros = @this.GetProperties().Where(p => p.Code != TypeCode.Object && !(p.Value is null));
            var query = pros.Select((p, i) => new {
                Num = i + 1,
                Name = p.Name,
                ValueStr = p.Value.ToString(),
            });

            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"| No. | 項目 | 値 |");
            sb.AppendLine($"| :-: | ---- | -- |");
            foreach (var i in query) {
                sb.AppendLine($"| {i.Num} | {i.Name} | {i.ValueStr} |");
            }
            sb.AppendLine();

            return sb.ToString();
        }

        #endregion
    }
}
