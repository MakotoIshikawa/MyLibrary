using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Acl {
    #region Acl

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class AclInfo {
        /// <summary></summary>
        [XmlElement("role")]
        public List<string> Role { get; set; }

        /// <summary></summary>
        [XmlElement("aclentry")]
        public List<AclEntryItem> AclEntries { get; set; }

        /// <summary></summary>
        [XmlElement("logentry")]
        public List<string> Logentry { get; set; }

        /// <summary></summary>
        [XmlAttribute("consistentacl")]
        public bool ConsistentAcl { get; set; }

        /// <summary></summary>
        [XmlAttribute("maxinternetaccess")]
        public string MaxInternetAccess { get; set; }
    }

    #endregion
}
