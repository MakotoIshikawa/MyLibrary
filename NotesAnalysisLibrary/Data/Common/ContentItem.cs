using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Common {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ContentItem : DateTimeNode {
        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
