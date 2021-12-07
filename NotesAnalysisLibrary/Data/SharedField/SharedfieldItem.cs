using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.SharedField {
    using Common;
    using Common.Primitive;

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class SharedfieldItem : ContentItemBase {
        /// <summary></summary>
        [XmlElement("rawitemdata")]
        public TypeNode RawItemData { get; set; }
    }
}
