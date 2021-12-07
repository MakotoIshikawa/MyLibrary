using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Page {
    using Common.Primitive;

    #region PageInfo

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class PageInfo : AppInfoBase<PageItem> {
        /// <summary></summary>
        [XmlElement("body")]
        public PageBody Body { get; set; }

        /// <summary></summary>
        [XmlAttribute("publicaccess")]
        public bool PublicAccess { get; set; }

        /// <summary></summary>
        [XmlAttribute("renderpassthrough")]
        public bool RenderPassThrough { get; set; }

        /// <summary>背景色</summary>
        [XmlAttribute("bgcolor")]
        public string BgColor { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class PageBody {
        /// <summary></summary>
        [XmlElement("richtext")]
        public Richtext Richtext { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class Richtext {
        /// <summary></summary>
        [XmlElement("par", typeof(RichtextPar))]
        [XmlElement("pardef", typeof(RichtextPardef))]
        public List<object> Items { get; set; }
    }

    #endregion
}
