using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Page {
    /// <summary>フォント情報</summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FontInfo {
        /// <summary>サイズ</summary>
        [XmlAttribute("size")]
        public string Size { get; set; }

        /// <summary>スタイル</summary>
        [XmlAttribute("style")]
        public string Style { get; set; }
    }
}
