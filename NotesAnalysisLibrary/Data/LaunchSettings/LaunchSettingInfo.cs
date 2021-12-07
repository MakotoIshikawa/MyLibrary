using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.LaunchSettings {
    #region LaunchSettings

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class LaunchSettingInfo {
        /// <summary></summary>
        [XmlElement("noteslaunch")]
        public NotesLaunch NotesLaunch { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class NotesLaunch {
        /// <summary></summary>
        [XmlAttribute("whenopened")]
        public string WhenOpened { get; set; }

        /// <summary></summary>
        [XmlAttribute("restorelastview")]
        public bool RestoreLastView { get; set; }

        /// <summary></summary>
        [XmlAttribute("frameset")]
        public string FrameSet { get; set; }
    }

    #endregion
}
