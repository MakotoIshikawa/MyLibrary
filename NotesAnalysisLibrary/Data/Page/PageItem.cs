using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Page {
    using Common.Primitive;

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class PageItem : ContentItemBase {
        /// <summary></summary>
        [XmlElement("text")]
        public string Text { get; set; }
    }
}
