using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ExtensionsLibrary.Extensions;

namespace NotesAnalysisLibrary.Data.Agent {
    using Common;
    using Common.Primitive;

    #region Agent

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class AgentInfo : AppInfoBase<ContentItem> {
        /// <summary></summary>
        [XmlElement("designchange")]
        public DateTimeNode DesignChange { get; set; }

        /// <summary></summary>
        [XmlElement("trigger")]
        public AgentTrigger Trigger { get; set; }

        /// <summary></summary>
        [XmlElement("documentset")]
        public TypeNode DocumentSet { get; set; }

        /// <summary></summary>
        [XmlElement("code")]
        public List<AgentCode> Codes { get; set; }

        /// <summary></summary>
        [XmlElement("rundata")]
        public AgentRunData RunData { get; set; }

        /// <summary></summary>
        [XmlAttribute("hide")]
        public string Hide { get; set; }

        /// <summary></summary>
        [XmlAttribute("publicaccess")]
        public bool PublicAccess { get; set; }

        /// <summary></summary>
        [XmlAttribute("comment")]
        public string Comment { get; set; }

        #region Activatable

        /// <summary></summary>
        [XmlAttribute("activatable")]
        public bool Activatable { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool ActivatableSpecified { get; set; }

        #endregion

        #region Enabled

        /// <summary></summary>
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool EnabledSpecified { get; set; }

        #endregion

        #region NoReplace

        /// <summary></summary>
        [XmlAttribute("noreplace")]
        public bool NoReplace { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool NoReplaceSpecified { get; set; }

        #endregion
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class AgentTrigger {
        /// <summary></summary>
        [XmlElement("schedule")]
        public TriggerSchedule Schedule { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>開始日時</summary>
        [XmlIgnore]
        public string StartDateTime => this.Schedule?.ToString();
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class TriggerSchedule {
        #region プロパティ

        /// <summary></summary>
        [XmlElement("starttime")]
        public ScheduleStartDateOrTime StartTime { get; set; }

        /// <summary></summary>
        [XmlElement("startdate")]
        public ScheduleStartDateOrTime StartDate { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute("runlocation")]
        public string RunLocation { get; set; }

        /// <summary></summary>
        [XmlAttribute("runserver")]
        public string RunServer { get; set; }

        #endregion

        #region メソッド

        /// <summary>
        /// このインスタンスの値を <see cref="string"/> に変換します。
        /// </summary>
        /// <returns>このオブジェクトを表す文字列を返します。</returns>
        public override string ToString() {
            try {
                var date = $"{this.StartDate}";
                var time = $"{this.StartTime}";

                if (!date.IsEmpty() && !time.IsEmpty()) {
                    var dateTime = new DateTimeNode($"{this.StartDate}{this.StartTime}").Value;
                    return $"{dateTime}";
                }

                if (!time.IsEmpty()) {
                    var ts = TimeSpan.ParseExact(time.Substring(1, 6), "hhmmss", null);
                    return $"{ts}";
                }

                return "※スタート時間未設定";
            } catch (Exception ex) {
                return ex.Message;
            }
        }

        #endregion
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ScheduleStartDateOrTime {
        /// <summary></summary>
        [XmlElement("datetime")]
        public string Datetime { get; set; }

        /// <summary>
        /// このインスタンスの値を <see cref="string"/> に変換します。
        /// </summary>
        /// <returns>このオブジェクトを表す文字列を返します。</returns>
        public override string ToString() => this.Datetime;
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class AgentCode : LotusScriptNode {
        /// <summary></summary>
        public AgentCodeSimpleaction simpleaction { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class AgentCodeSimpleaction {
        /// <summary>方式</summary>
        [XmlElement("formula")]
        public string Formula { get; set; }

        /// <summary></summary>
        [XmlAttribute("action")]
        public string Action { get; set; }

        /// <summary></summary>
        [XmlAttribute("agent")]
        public string Agent { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class AgentRunData {
        /// <summary></summary>
        [XmlElement("agentmodified")]
        public DateTimeNode AgentModified { get; set; }

        /// <summary></summary>
        [XmlElement("agentrun")]
        public DateTimeNode AgentRun { get; set; }

        /// <summary></summary>
        [XmlElement("runlog")]
        public string RunLog { get; set; }

        /// <summary></summary>
        [XmlAttribute("processeddocs")]
        public ushort ProcessedDocs { get; set; }

        /// <summary></summary>
        [XmlAttribute("exitcode")]
        public int ExitCode { get; set; }

        /// <summary></summary>
        [XmlAttribute("agentdata")]
        public string AgentData { get; set; }
    }

    #endregion
}
