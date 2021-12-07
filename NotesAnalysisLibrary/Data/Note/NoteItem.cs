using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Note {
    using Common;
    using Common.Primitive;

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class NoteItem : ContentItemBase {
        #region Number

        /// <summary></summary>
        [XmlElement("number")]
        public int Number { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool NumberSpecified { get; set; }

        #endregion

        /// <summary></summary>
        [XmlElement("rawitemdata")]
        public TypeNode RawItemData { get; set; }

        /// <summary></summary>
        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary></summary>
        [XmlArray("textlist")]
        [XmlArrayItem("text", IsNullable = false)]
        public List<string> TextList { get; set; }
    }
}
