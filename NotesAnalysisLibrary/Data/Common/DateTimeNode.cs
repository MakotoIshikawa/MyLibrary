using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace NotesAnalysisLibrary.Data.Common {
    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class DateTimeNode {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DateTimeNode() {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dateStr">日時文字列 "yyyyMMddTHHmmss"</param>
        public DateTimeNode(string dateStr) {
            this.Datetime = dateStr;
        }

        #endregion

        #region プロパティ

        /// <summary></summary>
        [XmlElement("datetime")]
        public string Datetime { get; set; }

        [XmlIgnore()]
        public virtual DateTime? Value {
            get {
                try {
                    return DateTime.ParseExact(this.Datetime.Split(',').FirstOrDefault(), "yyyyMMddTHHmmss", null);
                } catch (Exception) {
                    return null;
                }
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// このインスタンスの値を <see cref="string"/> に変換します。
        /// </summary>
        /// <returns>このオブジェクトを表す文字列を返します。</returns>
        public override string ToString()
            => this.Value?.ToString();

        #endregion
    }
}
