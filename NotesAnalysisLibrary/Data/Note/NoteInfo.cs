using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Note {
    using Common.Primitive;

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class NoteInfo : AppInfoBase<NoteItem> {
        #region Default

        /// <summary></summary>
        [XmlAttribute("default")]
        public bool Default { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool DefaultSpecified { get; set; }

        #endregion

        /// <summary></summary>
        [XmlAttribute("class")]
        public string Class { get; set; }
    }
}
