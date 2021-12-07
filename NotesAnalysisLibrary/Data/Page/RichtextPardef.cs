using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Page {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class RichtextPardef {
        /// <summary></summary>
        [XmlAttribute("id")]
        public int ID { get; set; }

        /// <summary></summary>
        [XmlAttribute("align")]
        public string Align { get; set; }

        /// <summary></summary>
        [XmlAttribute("leftmargin")]
        public string LeftMargin { get; set; }

        /// <summary></summary>
        [XmlAttribute("firstlineleftmargin")]
        public string FirstLineLeftMargin { get; set; }

        /// <summary></summary>
        [XmlAttribute("rightmargin")]
        public string RightMargin { get; set; }
    }
}
