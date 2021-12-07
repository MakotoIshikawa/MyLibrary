using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ExtensionsLibrary.Extensions;

namespace NotesAnalysisLibrary.Data.Common.Primitive {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public abstract partial class AppInfoBase<TItem> : INameAndAlias where TItem : ContentItem {
        /// <summary></summary>
        [XmlElement("noteinfo", typeof(NoteBaseInfo))]
        public NoteBaseInfo NoteInfo { get; set; }

        /// <summary></summary>
        [XmlElement("item")]
        public List<TItem> Items { get; set; }

        /// <summary></summary>
        [XmlArray("updatedby")]
        [XmlArrayItem("name", IsNullable = false)]
        public List<string> UpdatedBy { get; set; }

        /// <summary></summary>
        [XmlArray("wassignedby")]
        [XmlArrayItem("name", IsNullable = false)]
        public List<string> WasSignedBy { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute("alias")]
        public string Alias { get; set; }

        /// <summary></summary>
        [XmlAttribute("designerversion")]
        public string DesignerVersion { get; set; }
    }

    public static partial class AppInfoBaseExtension {
        public static string ToMarkdownList<TInfo>(this List<TInfo> items, int? chapter = null) where TInfo : INameAndAlias {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"| No. | 名前 | 別名 |");
            sb.AppendLine($"| :-: | ---- | ---- |");
            items.Select((v, i) => new {
                Num = i + 1,
                v.Name,
                v.Alias
            }).ToList().ForEach(v => {
                if (chapter >= 1) {
                    sb.AppendLine($"| {v.Num} | [{v.Name}](#{chapter}-{v.Num}. {v.Name}) | {v.Alias} |");
                } else {
                    sb.AppendLine($"| {v.Num} | {v.Name} | {v.Alias} |");
                }
            });
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
