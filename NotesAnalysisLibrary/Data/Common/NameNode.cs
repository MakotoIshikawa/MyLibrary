using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Common {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class NameNode {
        /// <summary></summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// このインスタンスの値を <see cref="string"/> に変換します。
        /// </summary>
        /// <returns>このオブジェクトを表す文字列を返します。</returns>
        public override string ToString()
            => this.Name;
    }
}
