using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Page {
    using Common;

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class RichtextPar {
        /// <summary></summary>
        [XmlElement("run")]
        public RichtextParRun Run { get; set; }

        /// <summary></summary>
        [XmlElement("embeddedoutline")]
        public ParEmbeddedoutline EmbeddedOutline { get; set; }

        /// <summary></summary>
        [XmlAttribute("def")]
        public int Def { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class RichtextParRun {
        /// <summary></summary>
        [XmlElement("font")]
        public FontInfo Font { get; set; }

        /// <summary></summary>
        [XmlElement("computedtext")]
        public ComputedText ComputedText { get; set; }
    }

    /// <summary>計算されたテキスト</summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ComputedText {
        /// <summary></summary>
        [XmlElement("code")]
        public FormulaNode Code { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ParEmbeddedoutline {
        /// <summary></summary>
        [XmlElement("title")]
        public EmbeddedOutlineInfo Title { get; set; }

        /// <summary></summary>
        [XmlElement("toplevel")]
        public EmbeddedOutlineInfo TopLevel { get; set; }

        /// <summary></summary>
        [XmlElement("sublevel")]
        public SubOutlineInfo SubLevel { get; set; }

        /// <summary></summary>
        [XmlAttribute("outline")]
        public string Outline { get; set; }

        /// <summary></summary>
        [XmlAttribute("showtwistie")]
        public bool ShowTwistie { get; set; }

        /// <summary></summary>
        [XmlAttribute("osstyletwistie")]
        public bool OssTyleTwistie { get; set; }

        /// <summary></summary>
        [XmlAttribute("widthtype")]
        public string WidthType { get; set; }

        /// <summary></summary>
        [XmlAttribute("heighttype")]
        public string HeightType { get; set; }

        /// <summary></summary>
        [XmlAttribute("height")]
        public string Height { get; set; }

        /// <summary></summary>
        [XmlAttribute("expand")]
        public string Expand { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class EmbeddedOutlineInfo {
        /// <summary></summary>
        [XmlElement("font")]
        public FontInfo Font { get; set; }

        /// <summary></summary>
        [XmlElement("layout")]
        public LayoutInfo Layout { get; set; }

        /// <summary></summary>
        [XmlAttribute("mouseovercolor")]
        public string MouseOverColor { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class SubOutlineInfo : EmbeddedOutlineInfo {
        /// <summary></summary>
        [XmlElement("eoutlinebackground")]
        public BackgroundInfo EOutlineBackground { get; set; }
    }

    /// <summary>背景情報</summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class BackgroundInfo {
        /// <summary></summary>
        [XmlAttribute("selectedcolor")]
        public string SelectedColor { get; set; }
    }
}
