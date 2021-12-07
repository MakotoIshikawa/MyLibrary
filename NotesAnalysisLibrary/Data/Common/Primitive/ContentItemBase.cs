using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Common.Primitive {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public abstract partial class ContentItemBase : ContentItem {
        #region Summary

        /// <summary></summary>
        [XmlAttribute("summary")]
        public bool Summary { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool SummarySpecified { get; set; }

        #endregion

        #region Sign

        /// <summary></summary>
        [XmlAttribute("sign")]
        public bool Sign { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool SignSpecified { get; set; }

        #endregion
    }
}
