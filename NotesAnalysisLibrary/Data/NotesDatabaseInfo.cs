using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ExtensionsLibrary.Extensions;
using NotesAnalysisLibrary.Extensions;

namespace NotesAnalysisLibrary.Data {
    using Acl;
    using Agent;
    using Common;
    using Common.Primitive;
    using Database;
    using Form;
    using FrameSet;
    using LaunchSettings;
    using Note;
    using Outline;
    using Page;
    using ScriptLibrary;
    using SharedField;
    using View;

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    [XmlRoot("database", Namespace = "http://www.lotus.com/dxl", IsNullable = false)]
    public partial class NotesDatabaseInfo {
        /// <summary></summary>
        [XmlElement("acl", typeof(AclInfo))]
        [XmlElement("agent", typeof(AgentInfo))]
        [XmlElement("databaseinfo", typeof(DatabaseInfo))]
        [XmlElement("databasescript", typeof(DatabaseScript))]
        [XmlElement("form", typeof(FormInfo))]
        [XmlElement("frameset", typeof(FrameSetInfo))]
        [XmlElement("launchsettings", typeof(LaunchSettingInfo))]
        [XmlElement("note", typeof(NoteInfo))]
        [XmlElement("outline", typeof(OutlineInfo))]
        [XmlElement("page", typeof(PageInfo))]
        [XmlElement("scriptlibrary", typeof(ScriptLibraryInfo))]
        [XmlElement("sharedfield", typeof(SharedFieldInfo))]
        [XmlElement("view", typeof(ViewInfo))]
        public List<object> Items { get; set; }

        /// <summary></summary>
        [XmlAttribute("version")]
        public decimal Version { get; set; }

        /// <summary></summary>
        [XmlAttribute("maintenanceversion")]
        public decimal MaintenanceVersion { get; set; }

        /// <summary></summary>
        [XmlAttribute("replicaid")]
        public string ReplicaID { get; set; }

        /// <summary>
        /// パス
        /// </summary>
        [XmlAttribute("path")]
        public string Path { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary></summary>
        [XmlAttribute("increasemaxfields")]
        public bool IncreaseMaxFields { get; set; }

        /// <summary></summary>
        [XmlAttribute("showinopendialog")]
        public bool ShowInOpenDialog { get; set; }

        /// <summary></summary>
        [XmlAttribute("markmodifiedunread")]
        public bool MarkModifiedUnread { get; set; }

        /// <summary></summary>
        [XmlAttribute("uselz1")]
        public bool Uselz1 { get; set; }

        #region 参照情報

        /// <summary>
        /// ファイル情報
        /// </summary>
        public FileInfo File => new FileInfo(this.Path);

        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName => this.File.Name;

        /// <summary>Acls</summary>
        [XmlIgnore]
        public List<AclInfo> Acls => this.Items.OfType<AclInfo>().ToList();

        /// <summary>Agents</summary>
        [XmlIgnore]
        public List<AgentInfo> Agents => this.Items.OfType<AgentInfo>().ToList();

        /// <summary>DatabaseInfos</summary>
        [XmlIgnore]
        public List<DatabaseInfo> DatabaseInfos => this.Items.OfType<DatabaseInfo>().ToList();

        /// <summary>DatabaseScripts</summary>
        [XmlIgnore]
        public List<DatabaseScript> DatabaseScripts => this.Items.OfType<DatabaseScript>().ToList();

        /// <summary>Forms</summary>
        [XmlIgnore]
        public List<FormInfo> Forms => this.Items.OfType<FormInfo>().ToList();

        /// <summary>FrameSets</summary>
        [XmlIgnore]
        public List<FrameSetInfo> FrameSets => this.Items.OfType<FrameSetInfo>().ToList();

        /// <summary>LaunchSettings</summary>
        [XmlIgnore]
        public List<LaunchSettingInfo> LaunchSettings => this.Items.OfType<LaunchSettingInfo>().ToList();

        /// <summary>Notes</summary>
        [XmlIgnore]
        public List<NoteInfo> Notes => this.Items.OfType<NoteInfo>().ToList();

        /// <summary>Outlines</summary>
        [XmlIgnore]
        public List<OutlineInfo> Outlines => this.Items.OfType<OutlineInfo>().ToList();

        /// <summary>Pages</summary>
        [XmlIgnore]
        public List<PageInfo> Pages => this.Items.OfType<PageInfo>().ToList();

        /// <summary>ScriptLibraries</summary>
        [XmlIgnore]
        public List<ScriptLibraryInfo> ScriptLibraries => this.Items.OfType<ScriptLibraryInfo>().ToList();

        /// <summary>Pages</summary>
        [XmlIgnore]
        public List<SharedFieldInfo> SharedFields => this.Items.OfType<SharedFieldInfo>().ToList();

        /// <summary>Views</summary>
        [XmlIgnore]
        public List<ViewInfo> Views => this.Items.OfType<ViewInfo>().ToList();

        #endregion

        #region メソッド

        /// <summary>
        /// NotesDB の情報を Markdown 書式で書き出します。
        /// </summary>
        /// <param name="tw"><see cref="TextWriter"/> を継承するクラスのオブジェクトを指定します。</param>
        public void WriteMarkdown(TextWriter tw) {
            var tmpOut = Console.Out;
            try {
                Console.SetOut(tw);

                Console.WriteLine($"# {this.Title}");
                Console.WriteLine();
                Console.WriteLine($"## 情報");
                Console.Write(this.GetPropertiesMarkdownList());

                var num = 1;
                Console.WriteLine($"## 項目数一覧");
                Console.WriteLine();
                Console.WriteLine($"| No. | 名前 | 個数 |");
                Console.WriteLine($"| :-: | ---- | ---- |");
                Console.WriteLine($"| {num} | [ビュー](#{num++}. ビュー)             | {this.Views.Count} |");
                Console.WriteLine($"| {num} | [フォーム](#{num++}. フォーム)         | {this.Forms.Count} |");
                Console.WriteLine($"| {num} | [エージェント](#{num++}. エージェント) | {this.Agents.Count} |");
                Console.WriteLine($"| {num} | [スクリプト](#{num++}. スクリプト)     | {this.ScriptLibraries.Count} |");
                Console.WriteLine();

                Console.WriteLine($"# 詳細");

                var chapterLv01 = 1;
                {// ビュー
                    Console.WriteLine($"## {chapterLv01}. ビュー");
                    Console.WriteLine();

                    var views = this.Views.OrderBy(v => v.Name).ToList();
                    Console.WriteLine($"数 : {views.Count}");

                    Console.Write(views.ToMarkdownList(chapterLv01));

                    var chapterLv02 = 1;
                    foreach (var v in views) {
                        Console.WriteLine($"### {chapterLv01}-{chapterLv02++}. {v.Name}");
                        Console.WriteLine();
                        Console.WriteLine($"| No. | 名前 | 別名 | 備考 |");
                        Console.WriteLine($"| :-: | ---- | ---- | ---- |");
                        v.Columns.Select((c, i) => new {
                            Num = i + 1,
                            Name = c.ColumnHeader.Title ?? "列名なし",
                            Alias = c.ItemName,
                            Remarks = c.Code?.Formula.Split('\n').Select(s => s.Trim()).Join("<br />")
                        }).ToList().ForEach(c => {
                            Console.WriteLine($"| {c.Num} | {c.Name} | {c.Alias} | {c.Remarks} |");
                        });
                        Console.WriteLine();
                    }
                    chapterLv01++;
                }
                {// フォーム
                    Console.WriteLine();
                    Console.WriteLine($"## {chapterLv01}. フォーム");
                    Console.WriteLine();

                    var forms = this.Forms;
                    Console.WriteLine($"数 : {forms.Count}");

                    Console.Write(forms.ToMarkdownList(chapterLv01));

                    var chapterLv02 = 1;
                    foreach (var f in forms) {
                        Console.WriteLine($"### {chapterLv01}-{chapterLv02}. {f.Name}");
                        Console.WriteLine();

                        var chapterLv03 = 1;
                        Console.WriteLine($"#### {chapterLv01}-{chapterLv02}-{chapterLv03++}. コード");
                        Console.Write(f.Codes.ToMarkdown());

                        chapterLv02++;
                    }

                    chapterLv01++;
                }
                {// エージェント
                    Console.WriteLine();
                    Console.WriteLine($"## {chapterLv01}. エージェント");
                    Console.WriteLine();

                    var agents = this.Agents;
                    Console.WriteLine($"数 : {agents.Count}");

                    Console.Write(agents.ToMarkdownList(chapterLv01));

                    var chapterLv02 = 1;
                    foreach (var a in agents) {
                        Console.WriteLine($"### {chapterLv01}-{chapterLv02}. {a.Name}");
                        Console.WriteLine();

                        var chapterLv03 = 1;
                        Console.WriteLine($"#### {chapterLv01}-{chapterLv02}-{chapterLv03++}. トリガー");
                        Console.Write(a.Trigger.GetPropertiesMarkdownList());

                        Console.WriteLine($"#### {chapterLv01}-{chapterLv02}-{chapterLv03++}. コード");
                        Console.Write(a.Codes.ToMarkdown());

                        chapterLv02++;
                    }
                    chapterLv01++;
                }
                {// スクリプト
                    Console.WriteLine();
                    Console.WriteLine($"## {chapterLv01}. スクリプト");
                    Console.WriteLine();

                    var scriptlibraries = this.ScriptLibraries;
                    Console.WriteLine($"数 : {scriptlibraries.Count}");

                    Console.Write(scriptlibraries.ToMarkdownList(chapterLv01));

                    var chapterLv02 = 1;
                    foreach (var p in scriptlibraries) {
                        Console.WriteLine($"### {chapterLv01}-{chapterLv02}. {p.Name}");
                        Console.WriteLine();

                        var chapterLv03 = 1;
                        Console.WriteLine($"#### {chapterLv01}-{chapterLv02}-{chapterLv03++}. コード");
                        Console.Write(p.Codes.ToMarkdown());

                        chapterLv02++;
                    }

                    chapterLv01++;
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } finally {
                Console.SetOut(tmpOut);
            }
        }

        #region オーバーライド

        /// <summary>
        /// このインスタンスの値を <see cref="string"/> に変換します。
        /// </summary>
        /// <returns>このオブジェクトを表す文字列を返します。</returns>
        public override string ToString() {
            var sb = new StringBuilder();
            using (var tw = new StringWriter(sb)) {
                this.WriteMarkdown(tw);
            }

            return sb.ToString();
        }

        #endregion

        #endregion
    }
}
