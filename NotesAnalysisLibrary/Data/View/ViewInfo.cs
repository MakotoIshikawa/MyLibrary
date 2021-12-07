using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using ExtensionsLibrary.Extensions;

namespace NotesAnalysisLibrary.Data.View {
    using Common;
    using Common.Primitive;

    #region View

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ViewInfo : AppInfoBase<ViewItem> {
        /// <summary></summary>
        [XmlElement("code")]
        public List<LotusScriptNode> Codes { get; set; }

        /// <summary></summary>
        [XmlElement("actionbar")]
        public ActionBarInfo ActionBar { get; set; }

        /// <summary></summary>
        [XmlElement("column")]
        public List<ViewColumn> Columns { get; set; }

        /// <summary></summary>
        [XmlAttribute("showinmenu")]
        public bool ShowInMenu { get; set; }

        /// <summary></summary>
        [XmlAttribute("publicaccess")]
        public bool PublicAccess { get; set; }

        /// <summary>未読マーク</summary>
        [XmlAttribute("unreadmarks")]
        public string UnreadMarks { get; set; }

        /// <summary></summary>
        [XmlAttribute("onopengoto")]
        public string OnOpenGoTo { get; set; }

        /// <summary></summary>
        [XmlAttribute("onrefresh")]
        public string OnRefresh { get; set; }

        /// <summary></summary>
        [XmlAttribute("headers")]
        public string Headers { get; set; }

        /// <summary></summary>
        [XmlAttribute("opencollapsed")]
        public bool OpenCollapsed { get; set; }

        /// <summary></summary>
        [XmlAttribute("showresponsehierarchy")]
        public bool ShowResponseHierarchy { get; set; }

        /// <summary></summary>
        [XmlAttribute("showmargin")]
        public bool ShowMargin { get; set; }

        /// <summary></summary>
        [XmlAttribute("shrinkrows")]
        public bool ShrinkRows { get; set; }

        /// <summary></summary>
        [XmlAttribute("extendlastcolumn")]
        public bool ExtendLastColumn { get; set; }

        /// <summary></summary>
        [XmlAttribute("showhierarchies")]
        public bool ShowHierarchies { get; set; }

        /// <summary>未読色</summary>
        [XmlAttribute("unreadcolor")]
        public string UnreadColor { get; set; }

        /// <summary></summary>
        [XmlAttribute("rowlinecount")]
        public int RowlineCount { get; set; }

        /// <summary></summary>
        [XmlAttribute("headerlinecount")]
        public int HeaderlineCount { get; set; }

        /// <summary></summary>
        [XmlAttribute("rowspacing")]
        public decimal RowSpacing { get; set; }

        /// <summary>背景色</summary>
        [XmlAttribute("bgcolor")]
        public string BgColor { get; set; }

        /// <summary></summary>
        [XmlAttribute("altrowcolor")]
        public string AltRowColor { get; set; }

        /// <summary></summary>
        [XmlAttribute("totalscolor")]
        public string TotalsColor { get; set; }

        /// <summary>ヘッダー背景色</summary>
        [XmlAttribute("headerbgcolor")]
        public string HeaderBgColor { get; set; }

        /// <summary></summary>
        [XmlAttribute("boldunreadrows")]
        public bool BoldUnreadRows { get; set; }

        /// <summary></summary>
        [XmlAttribute("evaluateactions")]
        public bool EvaluateActions { get; set; }

        /// <summary></summary>
        [XmlAttribute("allownewdocuments")]
        public bool AllowNewDocuments { get; set; }

        /// <summary>カスタマイズを許可する</summary>
        [XmlAttribute("allowcustomizations")]
        public bool AllowCustomizations { get; set; }

        /// <summary>余白の境界線を非表示</summary>
        [XmlAttribute("hidemarginborder")]
        public bool HideMarginBorder { get; set; }

        /// <summary></summary>
        [XmlAttribute("marginwidth")]
        public string MarginWidth { get; set; }

        /// <summary></summary>
        [XmlAttribute("marginbgcolor")]
        public string MarginBgColor { get; set; }

        /// <summary></summary>
        [XmlAttribute("uniquekeys")]
        public bool UniqueKeys { get; set; }

        #region InitialBuildRestricted

        /// <summary></summary>
        [XmlAttribute("initialbuildrestricted")]
        public bool InitialBuildRestricted { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool InitialBuildRestrictedSpecified { get; set; }

        #endregion

        #region NoEmptyCategories

        /// <summary></summary>
        [XmlAttribute("noemptycategories")]
        public bool NoEmptyCategories { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool NoEmptyCategoriesSpecified { get; set; }

        #endregion

        /// <summary></summary>
        [XmlAttribute("formatnoteid")]
        public string FormatNoteID { get; set; }

        #region Default

        /// <summary></summary>
        [XmlAttribute("default")]
        public bool Default { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool DefaultSpecified { get; set; }

        #endregion

        #region ColorizeIcons

        /// <summary>アイコンを色付けする</summary>
        [XmlAttribute("colorizeicons")]
        public bool ColorizeIcons { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool ColorizeIconsSpecified { get; set; }

        #endregion

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append(this.Name);
            if (!this.Alias.IsEmpty()) {
                sb.Append($"[{this.Alias}]");
            } else {
                sb.Append($"[別名なし]");
            }
            return sb.ToString();
        }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ActionBarInfo {
        /// <summary></summary>
        public ActionbarStyle actionbarstyle { get; set; }

        /// <summary></summary>
        public ActionButtonStyle actionbuttonstyle { get; set; }

        /// <summary></summary>
        public ActionbarFont font { get; set; }

        /// <summary></summary>
        public ActionbarBorder border { get; set; }

        /// <summary></summary>
        [XmlElement("action")]
        public List<ActionbarAction> Actions { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string linestyle { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bgcolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bordercolor { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ActionbarStyle {
        /// <summary></summary>
        [XmlAttribute()]
        public string height { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ActionButtonStyle {
        /// <summary></summary>
        [XmlAttribute()]
        public string bgcolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string displayborder { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ActionbarFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ActionbarBorder {
        /// <summary></summary>
        [XmlAttribute()]
        public string width { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string style { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ActionbarAction {
        /// <summary></summary>
        [XmlElement("code")]
        public LotusScriptNode[] code { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string title { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int icon { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool iconSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool showinmenu { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool showinmenuSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool showinbar { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool showinbarSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string systemcommand { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FontInfo {
        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute("pitch")]
        public string Pitch { get; set; }

        #region TrueType

        /// <summary></summary>
        [XmlAttribute("truetype")]
        public bool TrueType { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool TrueTypeSpecified { get; set; }

        #endregion

        #region FamilyID

        /// <summary></summary>
        [XmlAttribute("familyid")]
        public int FamilyID { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool FamilyIDSpecified { get; set; }

        #endregion

        /// <summary></summary>
        [XmlAttribute("style")]
        public string Style { get; set; }

        /// <summary></summary>
        [XmlAttribute("color")]
        public string Color { get; set; }

        /// <summary></summary>
        [XmlAttribute("size")]
        public string Size { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ViewColumn {
        /// <summary></summary>
        [XmlElement("font")]
        public FontInfo Font { get; set; }

        /// <summary></summary>
        [XmlElement("columnheader")]
        public ViewColumnHeader ColumnHeader { get; set; }

        /// <summary></summary>
        [XmlElement("datetimeformat")]
        public ViewDatetimeFormat DatetimeFormat { get; set; }

        /// <summary></summary>
        [XmlElement("numberformat")]
        public ViewNumberFormat NumberFormat { get; set; }

        /// <summary></summary>
        [XmlElement("code")]
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute("sort")]
        public string Sort { get; set; }

        /// <summary></summary>
        [XmlAttribute("hidedetailrows")]
        public bool HideDetailRows { get; set; }

        /// <summary></summary>
        [XmlAttribute("itemname")]
        public string ItemName { get; set; }

        /// <summary></summary>
        [XmlAttribute("width")]
        public decimal Width { get; set; }

        /// <summary></summary>
        [XmlAttribute("resizable")]
        public bool Resizable { get; set; }

        /// <summary></summary>
        [XmlAttribute("separatemultiplevalues")]
        public bool SeparateMultipleValues { get; set; }

        /// <summary></summary>
        [XmlAttribute("sortnoaccent")]
        public bool SortNoAccent { get; set; }

        /// <summary></summary>
        [XmlAttribute("sortnocase")]
        public bool SortNoCase { get; set; }

        /// <summary></summary>
        [XmlAttribute("showaslinks")]
        public bool ShowAsLinks { get; set; }

        #region Hidden

        /// <summary></summary>
        [XmlAttribute("hidden")]
        public bool Hidden { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool HiddenSpecified { get; set; }

        #endregion

        /// <summary></summary>
        [XmlAttribute("resort")]
        public string Resort { get; set; }

        /// <summary></summary>
        [XmlAttribute("align")]
        public string Align { get; set; }

        #region MyRegion

        /// <summary></summary>
        [XmlAttribute("showasicons")]
        public bool ShowAsIcons { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool ShowAsIconsSpecified { get; set; }

        #endregion

        #region Categorized

        /// <summary></summary>
        [XmlAttribute("categorized")]
        public bool Categorized { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool CategorizedSpecified { get; set; }

        #endregion

        #region Twisties

        /// <summary></summary>
        [XmlAttribute("twisties")]
        public bool Twisties { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool TwistiesSpecified { get; set; }

        #endregion

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append(this.ColumnHeader.Title ?? "列名なし");
            sb.Append($"[{this.ItemName}]");
            return sb.ToString();
        }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ViewColumnHeader {
        /// <summary></summary>
        [XmlElement("font")]
        public FontInfo Font { get; set; }

        /// <summary></summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        public override string ToString()
            => this.Title;
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ViewDatetimeFormat {
        /// <summary></summary>
        [XmlAttribute()]
        public string show { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string date { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool fourdigityearfor21stcentury { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string time { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string zone { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string dateformat { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string dayformat { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string monthformat { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string yearformat { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string weekdayformat { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string dateseparator1 { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string dateseparator2 { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string dateseparator3 { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string timeseparator { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool timeformat24 { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string preference { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ViewNumberFormat {
        /// <summary></summary>
        [XmlAttribute()]
        public string format { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool punctuated { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool parens { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool percent { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool ints { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class ViewItem : ContentItem {
        /// <summary></summary>
        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary></summary>
        [XmlArray("textlist")]
        [XmlArrayItem("text", IsNullable = false)]
        public List<string> TextList { get; set; }

        /// <summary></summary>
        [XmlElement("rawitemdata")]
        public TypeNode RawItemData { get; set; }

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

        #region Readers

        /// <summary></summary>
        [XmlAttribute("readers")]
        public bool Readers { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool ReadersSpecified { get; set; }

        #endregion
    }

    #endregion
}
