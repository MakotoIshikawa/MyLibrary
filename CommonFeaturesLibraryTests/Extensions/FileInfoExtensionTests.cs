using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonFeaturesLibrary.Extensions.Tests {
	[TestClass]
	public class FileInfoExtensionTests {
		#region メソッド

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(FileInfoExtension))]
		[TestCategory(nameof(FileInfoExtension.GetFileNameWithVersion))]
		[TestCategory(nameof(FileInfo) + " バージョン番号付与")]
		public void GetFileNameWithVersionOfFileInfoTest() {
			var file = new FileInfo("test.log");
			{
				var expected = file.Name;
				var actual = file.GetFileNameWithVersion(0).Name;
				Assert.AreEqual(expected, actual);
			}
			{
				var expected = "test (1).log";
				var actual = file.GetFileNameWithVersion(1).Name;
				Assert.AreEqual(expected, actual);
			}
			{
				var expected = "test (4294967295).log";
				var actual = file.GetFileNameWithVersion(uint.MaxValue).Name;
				Assert.AreEqual(expected, actual);
			}
		}

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(FileInfoExtension))]
		[TestCategory(nameof(FileInfoExtension.GetFileNameWithVersion))]
		[TestCategory(nameof(String) + " バージョン番号付与")]
		public void GetFileNameWithVersionOfStringTest() {
			var file = "test.log";
			{
				var expected = file;
				var actual = file.GetFileNameWithVersion(0);
				Assert.AreEqual(expected, actual);
			}
			{
				var expected = "test (1).log";
				var actual = file.GetFileNameWithVersion(1u);
				Assert.AreEqual(expected, actual);
			}
			{
				var expected = "test (4294967295).log";
				var actual = file.GetFileNameWithVersion(uint.MaxValue);
				Assert.AreEqual(expected, actual);
			}
		}

		#endregion
	}
}