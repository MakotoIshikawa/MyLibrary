using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.FrameSet {
    using Common;
    using Common.Primitive;

    #region FrameSet

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FrameSetInfo : AppInfoBase<ContentItem> {
        /// <summary></summary>
        [XmlElement("frameset")]
        public List<FrameSetItem> FrameSets { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool publicaccess { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string columns { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string spacing { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string borderwidth { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bordercolor { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FrameSetItem {
        /// <summary></summary>
        [XmlElement("frame")]
        public databaseFramesetFramesetFrame[] frame { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string rows { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string spacing { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFramesetFramesetFrame {
        /// <summary></summary>
        public databaseFramesetFramesetFrameBordercaption bordercaption { get; set; }

        /// <summary></summary>
        public TypeNameNode namedelementlink { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string scrolling { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool noresize { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool noresizeSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string targetframe { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool initialfocus { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool initialfocusSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFramesetFramesetFrameBordercaption {
        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string show { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string justify { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bgcolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string open { get; set; }
    }

    #endregion
}
