using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Common {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FormulaNode {
        /// <summary>方式</summary>
        [XmlElement("formula")]
        public string Formula { get; set; }

        /// <summary>イベント</summary>
        [XmlAttribute("event")]
        public string Event { get; set; }
    }
}
