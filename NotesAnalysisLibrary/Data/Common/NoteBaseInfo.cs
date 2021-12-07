using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Common {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class NoteBaseInfo {
        /// <summary></summary>
        [XmlElement("created")]
        public DateTimeNode Created { get; set; }

        /// <summary></summary>
        [XmlElement("modified")]
        public DateTimeNode Modified { get; set; }

        /// <summary></summary>
        [XmlElement("revised")]
        public DateTimeNode Revised { get; set; }

        /// <summary></summary>
        [XmlElement("lastaccessed")]
        public DateTimeNode LastAccessed { get; set; }

        /// <summary></summary>
        [XmlElement("addedtofile")]
        public DateTimeNode AddedToFile { get; set; }

        /// <summary></summary>
        [XmlAttribute("noteid")]
        public string NoteID { get; set; }

        /// <summary></summary>
        [XmlAttribute("unid")]
        public string UnID { get; set; }

        /// <summary></summary>
        [XmlAttribute("sequence")]
        public int Sequence { get; set; }
    }
}
