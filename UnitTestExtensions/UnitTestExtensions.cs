using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary.Extensions;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestExtensions {
		#region メソッド

		#region DictionaryExtension

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.DictionaryExtension))]
		public void ディレクトリ内ファイル取得() {
			var fullPath = $@"C:\work";
			var dir = new DirectoryInfo(fullPath);
			var files = dir.GetFileInfos(true, ".htm", ".html");

			Assert.IsTrue(files.Any());
			Assert.IsFalse(files.Any(f => f.Extension == ".htm"));
			Assert.IsFalse(files.Any(f => f.Extension == ".html"));
		}

		#endregion

		#region FileInfoExtension

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.FileInfoExtension))]
		public void ファイル種別判定() {
			Assert.IsTrue(new FileInfo("aaaaa.JPG").IsSharePointIcon());
			Assert.IsTrue(new FileInfo("aaaaa.jpg").IsSharePointIcon());
			Assert.IsTrue(new FileInfo("aaaaa.JPEG").IsSharePointIcon());
			Assert.IsTrue(new FileInfo("aaaaa.jpeg").IsSharePointIcon());
			Assert.IsTrue(new FileInfo("aaaaa.xls").IsSharePointIcon());
			Assert.IsTrue(new FileInfo("aaaaa.doc").IsSharePointIcon());
			Assert.IsTrue(new FileInfo("aaaaa.xlsm").IsSharePointIcon());
			Assert.IsTrue(new FileInfo("aaaaa.docm").IsSharePointIcon());
			Assert.IsTrue(new FileInfo("aaaaa.htm").IsSharePointIcon());
			Assert.IsFalse(new FileInfo("aaaaa.html").IsSharePointIcon());
		}

		#endregion

		#endregion
	}
}
