using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Common {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class LotusScriptNode : FormulaNode {
        /// <summary></summary>
        [XmlElement("lotusscript")]
        public string LotusScript { get; set; }
    }

    public static partial class LotusScriptNodeExtension {
        public static string ToMarkdown<TScript>(this List<TScript> codes) where TScript : LotusScriptNode {
            var sb = new StringBuilder();
            sb.AppendLine();
            foreach (var code in codes) {
                sb.AppendLine($"##### {code.Event}");
                sb.AppendLine();
                sb.AppendLine("```vb");
                sb.AppendLine($"{code.LotusScript}");
                sb.AppendLine("```");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
