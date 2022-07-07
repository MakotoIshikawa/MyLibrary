using System;
using System.IO;
using System.Linq;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesAnalysisLibrary.Data;
using XmlLibrary.Extensions;
using NotesAnalysisLibrary.Extensions;

namespace UnitTestExtensions {
    [TestClass]
    public partial class UnitTestXml {
        #region メソッド

        [TestMethod]
        [Owner(nameof(XmlLibrary))]
        [TestCategory("変更")]
        public void Xmlデータ解析() {
            var dir = new DirectoryInfo(@"C:\NotesDb\xml\202107_5DB");
            foreach (var xml in dir.GetFiles().Where(f => f.Extension.EndsWith("xml"))) {
                var xmlData = xml.DeSerializeFromXml<NotesDatabaseInfo>();
                Console.WriteLine(xmlData.ToString());
            }
        }

        [TestMethod]
        [Owner(nameof(XmlLibrary))]
        [TestCategory("変換")]
        public void Markdown変換() {
            //var dir = new DirectoryInfo(@"C:\NotesDb\xml\202105_6DB");
            var dir = new DirectoryInfo(@"C:\NotesDb\xml\202110_Ph3");
            foreach (var xml in dir.GetFiles().Where(f => f.Extension.EndsWith("xml"))) {
                xml.ConvertMarkdown();
            }
        }

        [TestMethod]
        [Owner(nameof(XmlLibrary))]
        [TestCategory("変換")]
        public void Markdown変換_個別() {
            var xml = new FileInfo(@"C:\NotesDb\xml\202105_6DB\cf0030.xml");
            xml.ConvertMarkdown();
        }

        [TestMethod]
        [Owner(nameof(XmlLibrary))]
        [TestCategory("変換")]
        public void TimeSpanTest() {
            var val = "T210000,00".Substring(1, 6);
            var actual = TimeSpan.ParseExact(val, "hhmmss", null);
            Assert.AreEqual(new TimeSpan(21, 0, 0), actual);
        }

        #endregion
    }
}
