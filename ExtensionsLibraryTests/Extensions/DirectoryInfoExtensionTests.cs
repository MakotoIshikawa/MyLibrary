using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionsLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExtensionsLibrary.Extensions.Tests {
	[TestClass()]
	public class DirectoryInfoExtensionTests {
		#region プロパティ

		/// <summary>
		/// リソースフォルダのディレクトリ情報を取得します。
		/// </summary>
		public static DirectoryInfo Resources => new DirectoryInfo(@".");

		#endregion

		[TestMethod]
		public void CreateFileInfoTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void CreateChildTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.DirectoryInfoExtension))]
		[DeploymentItem(nameof(Resources))]
		public void GetFileInfosTest() {
			var dir = Resources;
			var files = dir.GetFileInfos(true, ".htm", ".html");

			Assert.IsTrue(files.Any());
			Assert.IsTrue(files.Any(f => f.Extension == ".csv"));
			Assert.IsFalse(files.Any(f => f.Extension == ".htm"));
			Assert.IsFalse(files.Any(f => f.Extension == ".html"));
		}

		[TestMethod]
		public void IsHiddenTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void HasAttributeTest() {
			throw new NotImplementedException();
		}
	}
}