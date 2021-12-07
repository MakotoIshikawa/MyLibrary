using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Common {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class TypeNode {
        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlText()]
        public string Value { get; set; }

        /// <summary>
        /// このインスタンスの値を <see cref="string"/> に変換します。
        /// </summary>
        /// <returns>このオブジェクトを表す文字列を返します。</returns>
        public override string ToString()
            => this.Value;
    }
}
