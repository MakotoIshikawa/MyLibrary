using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Form {
    using Common;
    using Common.Primitive;

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FormItem : ContentItemBase {
        /// <summary></summary>
        [XmlElement("rawitemdata")]
        public TypeNode RawItemData { get; set; }

        /// <summary></summary>
        [XmlElement("text")]
        public FormItemText Text { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FormItemText {
        /// <summary></summary>
        [XmlElement("break")]
        public string Break { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }
    }
}
