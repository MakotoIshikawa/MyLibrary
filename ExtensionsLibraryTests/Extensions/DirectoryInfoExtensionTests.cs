using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsLibrary.Extensions.Tests {
	[TestClass]
	public class DirectoryInfoExtensionTests {
		#region プロパティ

		/// <summary>
		/// リソースフォルダのディレクトリ情報を取得します。
		/// </summary>
		public static DirectoryInfo Resources => new DirectoryInfo(@".");

		#endregion

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(DirectoryInfoExtension))]
		[TestCategory(nameof(DirectoryInfoExtension.CreateFileInfo))]
		public void CreateFileInfoTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(DirectoryInfoExtension))]
		[TestCategory(nameof(DirectoryInfoExtension.CreateChild))]
		public void CreateChildTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(DirectoryInfoExtension))]
		[TestCategory(nameof(DirectoryInfoExtension.GetFileInfos))]
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
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(DirectoryInfoExtension))]
		[TestCategory(nameof(DirectoryInfoExtension.IsHidden))]
		public void IsHiddenTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(DirectoryInfoExtension))]
		[TestCategory(nameof(DirectoryInfoExtension.HasAttribute))]
		public void HasAttributeTest() {
			throw new NotImplementedException();
		}
	}
}