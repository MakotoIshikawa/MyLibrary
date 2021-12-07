using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Database {
    using Common;

    #region DatabaseInfo

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class DatabaseInfo {
        /// <summary>データ更新日時</summary>
        [XmlElement("datamodified")]
        public DateTimeNode DataModified { get; set; }

        /// <summary>デザイン更新日時</summary>
        [XmlElement("designmodified")]
        public DateTimeNode DesignModified { get; set; }

        /// <summary></summary>
        [XmlAttribute("dbid")]
        public string DbID { get; set; }

        /// <summary></summary>
        [XmlAttribute("odsversion")]
        public int OdsVersion { get; set; }

        /// <summary></summary>
        [XmlAttribute("diskspace")]
        public uint DiskSpace { get; set; }

        /// <summary>使用率</summary>
        [XmlAttribute("percentused")]
        public decimal PercentUsed { get; set; }

        /// <summary></summary>
        [XmlAttribute("numberofdocuments")]
        public int NumberOfDocuments { get; set; }
    }

    #endregion
}
