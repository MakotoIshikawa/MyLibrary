using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Acl {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class AclEntryItem {
        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        #region Default

        /// <summary></summary>
        [XmlAttribute("default")]
        public bool Default { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool DefaultSpecified { get; set; }

        #endregion

        /// <summary></summary>
        [XmlAttribute("level")]
        public string Level { get; set; }

        /// <summary></summary>
        [XmlAttribute("deletedocs")]
        public bool DeleteDocs { get; set; }

        #region CreateLsJavaAgents

        /// <summary></summary>
        [XmlAttribute("createlsjavaagents")]
        public bool CreateLsJavaAgents { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool CreateLsJavaAgentsSpecified { get; set; }

        #endregion

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
