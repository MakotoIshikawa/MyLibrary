using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.SharedField {
    using Common;
    using Common.Primitive;

    #region SharedField

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class SharedFieldInfo : AppInfoBase<SharedfieldItem> {
        /// <summary></summary>
        [XmlElement("field")]
        public FieldInfo Field { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FieldInfo {
        /// <summary></summary>
        [XmlElement("datetimeformat")]
        public DateTimeFormat DatetimeFormat { get; set; }

        /// <summary></summary>
        [XmlElement("code")]
        public FormulaNode Code { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute("kind")]
        public string Kind { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class DateTimeFormat {
        /// <summary></summary>
        [XmlAttribute("show")]
        public string Show { get; set; }

        /// <summary></summary>
        [XmlAttribute("date")]
        public string Date { get; set; }

        /// <summary></summary>
        [XmlAttribute("time")]
        public string Time { get; set; }

        /// <summary></summary>
        [XmlAttribute("zone")]
        public string Zone { get; set; }
    }

    #endregion
}
