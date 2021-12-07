using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.ScriptLibrary {
    using Common;
    using Common.Primitive;

    #region ScriptLibrary

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ScriptLibraryInfo : AppInfoBase<ContentItem> {
        /// <summary></summary>
        [XmlElement("code")]
        public List<LotusScriptNode> Codes { get; set; }

        /// <summary></summary>
        [XmlAttribute("hide")]
        public string Hide { get; set; }
    }

    #endregion
}
