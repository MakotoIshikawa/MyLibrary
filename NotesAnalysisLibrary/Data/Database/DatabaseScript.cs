using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Database {
    using Common;
    using Common.Primitive;

    #region DatabaseScript

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class DatabaseScript : AppInfoBase<ContentItem> {
    }

    #endregion
}
