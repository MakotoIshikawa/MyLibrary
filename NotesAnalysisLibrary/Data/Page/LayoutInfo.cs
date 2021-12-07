using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Page {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class LayoutInfo {
        /// <summary></summary>
        [XmlAttribute("labelalign")]
        public string LabelAlign { get; set; }

        /// <summary>エントリーの水平オフセット</summary>
        [XmlAttribute("entryhoffset")]
        public string EntryHOffset { get; set; }

        /// <summary>エントリーの垂直オフセット</summary>
        [XmlAttribute("entryvoffset")]
        public string EntryVOffset { get; set; }

        /// <summary></summary>
        [XmlAttribute("imagealign")]
        public string ImageAlign { get; set; }

        /// <summary>ラベルの水平オフセット</summary>
        [XmlAttribute("labelhoffset")]
        public string LabelHOffset { get; set; }

        /// <summary>ラベルの垂直オフセット</summary>
        [XmlAttribute("labelvoffset")]
        public int LabelVOffset { get; set; }
    }
}
