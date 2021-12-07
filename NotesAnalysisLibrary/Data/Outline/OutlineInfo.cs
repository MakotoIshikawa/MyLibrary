using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Outline {
    using Common;
    using Common.Primitive;

    #region Outline

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class OutlineInfo : AppInfoBase<ContentItem> {
        /// <summary></summary>
        [XmlElement("outlineentry")]
        public List<OutlineEntry> OutlineEntries { get; set; }

        /// <summary></summary>
        [XmlAttribute("publicaccess")]
        public bool PublicAccess { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class OutlineEntry {
        /// <summary></summary>
        [XmlElement("namedelementlink")]
        public TypeNameNode NamedElementLink { get; set; }

        /// <summary></summary>
        [XmlElement("code")]
        public FormulaNode Code { get; set; }

        /// <summary></summary>
        [XmlAttribute("label")]
        public string Label { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        #region Level

        /// <summary></summary>
        [XmlAttribute("level")]
        public int Level { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool LevelSpecified { get; set; }

        #endregion
    }

    #endregion
}
