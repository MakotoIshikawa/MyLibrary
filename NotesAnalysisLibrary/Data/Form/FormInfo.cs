using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using ExtensionsLibrary.Extensions;

namespace NotesAnalysisLibrary.Data.Form {
    using Common;
    using Common.Primitive;

    #region Form

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class FormInfo : AppInfoBase<FormItem> {
        /// <summary></summary>
        [XmlArray("globals")]
        [XmlArrayItem("code", IsNullable = false)]
        public List<LotusScriptNode> Globals { get; set; }

        /// <summary></summary>
        [XmlElement("code")]
        public List<LotusScriptNode> Codes { get; set; }

        /// <summary></summary>
        [XmlElement("actionbar")]
        public databaseFormActionbar ActionBar { get; set; }

        /// <summary></summary>
        [XmlElement("body")]
        public databaseFormBody Body { get; set; }

        #region NoCompose

        /// <summary></summary>
        [XmlAttribute("nocompose")]
        public bool NoCompose { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool NoComposeSpecified { get; set; }

        #endregion

        /// <summary></summary>
        [XmlAttribute("publicaccess")]
        public bool PublicAccess { get; set; }

        #region Default

        /// <summary></summary>
        [XmlAttribute("default")]
        public bool Default { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool DefaultSpecified { get; set; }

        #endregion

        #region RenderPassThrough

        /// <summary></summary>
        [XmlAttribute("renderpassthrough")]
        public bool RenderPassThrough { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool RenderPassThroughSpecified { get; set; }

        #endregion
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormActionbar {
        /// <summary></summary>
        public databaseFormActionbarActionbarstyle actionbarstyle { get; set; }

        /// <summary></summary>
        public databaseFormActionbarActionbuttonstyle actionbuttonstyle { get; set; }

        /// <summary></summary>
        public databaseFormActionbarFont font { get; set; }

        /// <summary></summary>
        public databaseFormActionbarBorder border { get; set; }

        /// <summary></summary>
        [XmlElement("action")]
        public List<databaseFormActionbarAction> Actions { get; set; }

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
    public partial class databaseFormActionbarActionbarstyle {
        /// <summary></summary>
        [XmlAttribute()]
        public string height { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormActionbarActionbuttonstyle {
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
    public partial class databaseFormActionbarFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormActionbarBorder {
        /// <summary></summary>
        [XmlAttribute()]
        public string style { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string width { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormActionbarAction {
        /// <summary></summary>
        [XmlElement("code")]
        public List<LotusScriptNode> code { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string title { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int icon { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool showinmenu { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string hide { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBody {
        /// <summary></summary>
        [XmlElement("richtext")]
        public databaseFormBodyRichtext RichText { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtext {
        /// <summary></summary>
        [XmlElement("par", typeof(RichtextPar))]
        [XmlElement("pardef", typeof(RichtextPardef))]
        [XmlElement("section", typeof(RichtextSection))]
        [XmlElement("table", typeof(RichtextTable))]
        public List<object> Items { get; set; }

        #region 参照

        /// <summary>Forms</summary>
        [XmlIgnore]
        public List<RichtextPar> Pars => this.Items.OfType<RichtextPar>().ToList();

        /// <summary>Forms</summary>
        [XmlIgnore]
        public List<RichtextPardef> Pardefs => this.Items.OfType<RichtextPardef>().ToList();

        /// <summary>Forms</summary>
        [XmlIgnore]
        public List<RichtextSection> Sections => this.Items.OfType<RichtextSection>().ToList();

        /// <summary>Forms</summary>
        [XmlIgnore]
        public List<RichtextTable> Tables => this.Items.OfType<RichtextTable>().ToList();

        #endregion
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class RichtextPar {
        /// <summary></summary>
        [XmlElement("compositedata", typeof(databaseFormBodyRichtextParCompositedata))]
        [XmlElement("field", typeof(databaseFormBodyRichtextParField))]
        [XmlElement("run", typeof(databaseFormBodyRichtextParRun))]
        public List<object> Items { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int def { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextParCompositedata {
        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string prevtype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int nexttype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int afterparcount { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public ushort containertype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int aftercontainercount { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int afterbegincount { get; set; }

        /// <summary></summary>
        [XmlText()]
        public string Value { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextParField {
        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string kind { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextParRun {
        /// <summary></summary>
        public databaseFormBodyRichtextParRunFont font { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextParRunField field { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextParRunFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string style { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string pitch { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool truetype { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool truetypeSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int familyid { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool familyidSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string size { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextParRunField {
        /// <summary></summary>
        public databaseFormBodyRichtextParRunFieldKeywords keywords { get; set; }

        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string kind { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool allowmultivalues { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool allowmultivaluesSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listinputseparators { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listdisplayseparator { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string borderstyle { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool lookupeachchar { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool lookupeachcharSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool lookupaddressonrefresh { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool lookupaddressonrefreshSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextParRunFieldKeywords {
        /// <summary></summary>
        [XmlArrayItem("text", IsNullable = false)]
        public List<string> textlist { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool helperbutton { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int columns { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string ui { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class RichtextPardef {
        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int id { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string leftmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string hide { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string firstlineleftmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string tabs { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string rightmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public decimal spacebefore { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool spacebeforeSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string align { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class RichtextSection {
        /// <summary></summary>
        [XmlElement("par", typeof(databaseFormBodyRichtextSectionPar))]
        [XmlElement("pardef", typeof(databaseFormBodyRichtextSectionPardef))]
        [XmlElement("sectiontitle", typeof(databaseFormBodyRichtextSectionSectiontitle))]
        [XmlElement("table", typeof(databaseFormBodyRichtextSectionTable))]
        public List<object> Items { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string onread { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string onpreview { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string onedit { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string onprint { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool expanded { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionPar {
        /// <summary></summary>
        [XmlElement("compositedata", typeof(databaseFormBodyRichtextSectionParCompositedata))]
        [XmlElement("run", typeof(databaseFormBodyRichtextSectionParRun))]
        public List<object> Items { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int def { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionParCompositedata {
        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string prevtype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int nexttype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int afterparcount { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public ushort containertype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int aftercontainercount { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int afterbegincount { get; set; }

        /// <summary></summary>
        [XmlText()]
        public string Value { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionParRun {
        /// <summary></summary>
        public databaseFormBodyRichtextSectionParRunFont font { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextSectionParRunField field { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionParRunFont {
        /// <summary></summary>
        [XmlAttribute("size")]
        public string Size { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute("color")]
        public string Color { get; set; }

        /// <summary></summary>
        [XmlAttribute("pitch")]
        public string Pitch { get; set; }

        /// <summary></summary>
        [XmlAttribute("truetype")]
        public bool TrueType { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool TrueTypeSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute("familyid")]
        public int FamilyID { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool FamilyIDSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute("style")]
        public string Style { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionParRunField {
        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute("kind")]
        public string Kind { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute("description")]
        public string Description { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionPardef {
        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int id { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string hide { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string leftmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string tabs { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string rightmargin { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionSectiontitle {
        /// <summary></summary>
        public databaseFormBodyRichtextSectionSectiontitleFont font { get; set; }

        /// <summary></summary>
        public string text { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int pardef { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionSectiontitleFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string style { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTable {
        /// <summary></summary>
        [XmlElement("tablecolumn")]
        public List<databaseFormBodyRichtextSectionTableTablecolumn> tablecolumn { get; set; }

        /// <remarks>TODO: [][]</remarks>
        [XmlArrayItem("tablecell", typeof(databaseFormBodyRichtextSectionTableTablerowTablecell), IsNullable = false)]
        public List<databaseFormBodyRichtextSectionTableTablerowTablecell> tablerow { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string cellbordercolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string leftmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string widthtype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string rowspacing { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string refwidth { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string rightmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string cellborderstyle { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablecolumn {
        /// <summary></summary>
        [XmlAttribute("width")]
        public string width { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecell {
        /// <summary></summary>
        [XmlElement("par", typeof(databaseFormBodyRichtextSectionTableTablerowTablecellPar))]
        [XmlElement("pardef", typeof(databaseFormBodyRichtextSectionTableTablerowTablecellPardef))]
        public List<object> Items { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bgcolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int columnspan { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool columnspanSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int rowspan { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool rowspanSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string borderwidth { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string valign { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellPar {
        /// <summary></summary>
        [XmlElement("actionhotspot", typeof(databaseFormBodyRichtextSectionTableTablerowTablecellParActionhotspot))]
        [XmlElement("button", typeof(databaseFormBodyRichtextSectionTableTablerowTablecellParButton))]
        [XmlElement("compositedata", typeof(databaseFormBodyRichtextSectionTableTablerowTablecellParCompositedata))]
        [XmlElement("field", typeof(databaseFormBodyRichtextSectionTableTablerowTablecellParField))]
        [XmlElement("imagemap", typeof(databaseFormBodyRichtextSectionTableTablerowTablecellParImagemap))]
        [XmlElement("run", typeof(databaseFormBodyRichtextSectionTableTablerowTablecellParRun))]
        public List<object> Items { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int def { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParActionhotspot {
        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParActionhotspotRun run { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string hotspotstyle { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParActionhotspotRun {
        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParActionhotspotRunFont font { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParActionhotspotRunFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string size { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string style { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParButton {
        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParButtonFont font { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string width { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string widthtype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool wraptext { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string edge { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bgcolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int maxlines { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool maxlinesSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParButtonFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string size { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParCompositedata {
        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public ushort prevtype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int nexttype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int afterparcount { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public ushort containertype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int aftercontainercount { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int afterbegincount { get; set; }

        /// <summary></summary>
        [XmlText()]
        public string Value { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParField {
        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string kind { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string description { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool allowmultivalues { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool allowmultivaluesSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listinputseparators { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listdisplayseparator { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParImagemap {

        private databaseFormBodyRichtextSectionTableTablerowTablecellParImagemapPicture pictureField;

        private databaseFormBodyRichtextSectionTableTablerowTablecellParImagemapArea areaField;

        private int lastdefaultidField;

        private int lastrectangleidField;

        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParImagemapPicture picture {
            get {
                return this.pictureField;
            }
            set {
                this.pictureField = value;
            }
        }

        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParImagemapArea area {
            get {
                return this.areaField;
            }
            set {
                this.areaField = value;
            }
        }

        /// <summary></summary>
        [XmlAttribute()]
        public int lastdefaultid {
            get {
                return this.lastdefaultidField;
            }
            set {
                this.lastdefaultidField = value;
            }
        }

        /// <summary></summary>
        [XmlAttribute()]
        public int lastrectangleid {
            get {
                return this.lastrectangleidField;
            }
            set {
                this.lastrectangleidField = value;
            }
        }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParImagemapPicture {

        private string gifField;

        private string widthField;

        private string heightField;

        private string scaledheightField;

        private string scaledwidthField;

        /// <summary></summary>
        public string gif {
            get {
                return this.gifField;
            }
            set {
                this.gifField = value;
            }
        }

        /// <summary></summary>
        [XmlAttribute()]
        public string width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
            }
        }

        /// <summary></summary>
        [XmlAttribute()]
        public string height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
            }
        }

        /// <summary></summary>
        [XmlAttribute()]
        public string scaledheight {
            get {
                return this.scaledheightField;
            }
            set {
                this.scaledheightField = value;
            }
        }

        /// <summary></summary>
        [XmlAttribute()]
        public string scaledwidth {
            get {
                return this.scaledwidthField;
            }
            set {
                this.scaledwidthField = value;
            }
        }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParImagemapArea {
        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string htmlid { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParRun {
        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParRunFont font { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParRunField field { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParRunFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string size { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string style { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParRunField {
        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParRunFieldDatetimeformat datetimeformat { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellParRunFieldKeywords keywords { get; set; }

        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string kind { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool lookupeachchar { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool lookupeachcharSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool lookupaddressonrefresh { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool lookupaddressonrefreshSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool allowmultivalues { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool allowmultivaluesSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string description { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listinputseparators { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listdisplayseparator { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string borderstyle { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool usenotesstyle { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool usenotesstyleSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string height { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string width { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool alignwithparagraph { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool alignwithparagraphSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool multiline { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool multilineSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParRunFieldDatetimeformat {
        /// <summary></summary>
        [XmlAttribute()]
        public string show { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string date { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool fourdigityear { get; set; }

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
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellParRunFieldKeywords {
        /// <summary></summary>
        [XmlArrayItem("text", IsNullable = false)]
        public List<string> textlist { get; set; }

        /// <summary></summary>
        public string formula { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool recalcchoices { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool recalcchoicesSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int columns { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool columnsSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string ui { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool allownew { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool allownewSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool recalconchange { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool recalconchangeSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool helperbutton { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool helperbuttonSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellPardef {
        /// <summary></summary>
        public databaseFormBodyRichtextSectionTableTablerowTablecellPardefCode code { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int id { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string hide { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool keepwithnext { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool keeptogether { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string leftmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string tabs { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string align { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextSectionTableTablerowTablecellPardefCode : FormulaNode {
        /// <summary></summary>
        [XmlAttribute()]
        public bool enabled { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool enabledSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class RichtextTable {
        /// <summary></summary>
        [XmlElement("tablecolumn")]
        public List<databaseFormBodyRichtextTableTablecolumn> tablecolumn { get; set; }

        /// <remarks>TODO: [][]</remarks>
        [XmlArrayItem("tablecell", typeof(databaseFormBodyRichtextTableTablerowTablecell), IsNullable = false)]
        public List<databaseFormBodyRichtextTableTablerowTablecell> tablerow { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string widthtype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string cellbordercolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string leftmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string refwidth { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string rowspacing { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablecolumn {
        /// <summary></summary>
        [XmlAttribute()]
        public string width { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecell {
        /// <summary></summary>
        [XmlElement("cellbackground", typeof(databaseFormBodyRichtextTableTablerowTablecellCellbackground))]
        [XmlElement("par", typeof(databaseFormBodyRichtextTableTablerowTablecellPar))]
        [XmlElement("pardef", typeof(databaseFormBodyRichtextTableTablerowTablecellPardef))]
        public List<object> Items { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string borderwidth { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bgcolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string valign { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int columnspan { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool columnspanSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int rowspan { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool rowspanSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellCellbackground {
        /// <summary></summary>
        public NameNode imageref { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string repeat { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellPar {
        /// <summary></summary>
        [XmlElement("button", typeof(databaseFormBodyRichtextTableTablerowTablecellParButton))]
        [XmlElement("compositedata", typeof(databaseFormBodyRichtextTableTablerowTablecellParCompositedata))]
        [XmlElement("field", typeof(databaseFormBodyRichtextTableTablerowTablecellParField))]
        [XmlElement("run", typeof(databaseFormBodyRichtextTableTablerowTablecellParRun))]
        public List<object> Items { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int def { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParButton {
        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParButtonCode code { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParButtonFont font { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string width { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string widthtype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int maxlines { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool wraptext { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string edge { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bgcolor { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParButtonCode {
        /// <summary></summary>
        public string formula { get; set; }

        /// <summary></summary>
        [XmlAttribute("event")]
        public string Event { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParButtonFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string size { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParCompositedata {
        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string prevtype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int nexttype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int afterparcount { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public ushort containertype { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int aftercontainercount { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int afterbegincount { get; set; }

        /// <summary></summary>
        [XmlText()]
        public string Value { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParField {
        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParFieldKeywords keywords { get; set; }

        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string kind { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string borderstyle { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool lookupeachchar { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool lookupeachcharSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool lookupaddressonrefresh { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool lookupaddressonrefreshSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string description { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool allowmultivalues { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool allowmultivaluesSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listinputseparators { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listdisplayseparator { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParFieldKeywords {
        /// <summary></summary>
        public string formula { get; set; }

        /// <summary></summary>
        [XmlArrayItem("text", IsNullable = false)]
        public List<string> textlist { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool helperbutton { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool recalconchange { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int columns { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string ui { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool recalcchoices { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool recalcchoicesSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParRun {
        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParRunFont font { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParRunComputedtext computedtext { get; set; }

        /// <summary></summary>
        public NameNode sharedfieldref { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParRunField field { get; set; }

        /// <summary></summary>
        [XmlText()]
        public List<string> Text { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParRunFont {
        /// <summary></summary>
        [XmlAttribute()]
        public string size { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string style { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string color { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string pitch { get; set; }
        /// <summary></summary>
        [XmlAttribute()]
        public bool truetype { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool truetypeSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int familyid { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool familyidSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParRunComputedtext {
        /// <summary></summary>
        public FormulaNode code { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParRunField {
        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParRunFieldDatetimeformat datetimeformat { get; set; }

        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParRunFieldKeywords keywords { get; set; }

        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string kind { get; set; }

        /// <summary></summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string borderstyle { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool usenotesstyle { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool usenotesstyleSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string height { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string width { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool alignwithparagraph { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool alignwithparagraphSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool multiline { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool multilineSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string description { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string bgcolor { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool showdelimiters { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool showdelimitersSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool lookupeachchar { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool lookupeachcharSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool lookupaddressonrefresh { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool lookupaddressonrefreshSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool allowmultivalues { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool allowmultivaluesSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listinputseparators { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string listdisplayseparator { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string choicesdialog { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParRunFieldDatetimeformat {
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

        /// <summary></summary>
        [XmlAttribute()]
        public bool fourdigityear { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool fourdigityearSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string time { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParRunFieldKeywords {
        /// <summary></summary>
        public databaseFormBodyRichtextTableTablerowTablecellParRunFieldKeywordsTextlist textlist { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool helperbutton { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool helperbuttonSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int columns { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool columnsSpecified { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string ui { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool allownew { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool allownewSpecified { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellParRunFieldKeywordsTextlist {
        /// <summary></summary>
        public string text { get; set; }
    }

    /// <summary></summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.lotus.com/dxl")]
    public partial class databaseFormBodyRichtextTableTablerowTablecellPardef {
        /// <summary></summary>
        public FormulaNode code { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public int id { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string align { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool keepwithnext { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public bool keeptogether { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string leftmargin { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public string tabs { get; set; }

        /// <summary></summary>
        [XmlAttribute()]
        public decimal spacebefore { get; set; }

        /// <summary></summary>
        [XmlIgnore()]
        public bool spacebeforeSpecified { get; set; }
    }

    #endregion
}
