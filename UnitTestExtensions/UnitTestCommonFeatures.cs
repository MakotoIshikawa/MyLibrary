using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary;
using CommonFeaturesLibrary.Extensions;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestCommonFeatures {
		#region メソッド

		#region FileInfoExtension

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(CommonFeaturesLibrary.Extensions.FileInfoExtension))]
		public void ファイル名変更() {
			var file = new FileInfo(@"C:\Users\ishikawm\Documents\L.txt");
			var fname0 = file.GetVersionName(0);
			var fname1 = file.GetVersionName(1);

			var expected = @"C:\Users\ishikawm\Documents\L (1).txt";
			var actual = fname1;
			Assert.AreNotEqual(expected, actual);
		}

		#endregion

		#region CsvReader

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(CommonFeaturesLibrary.Extensions.FileInfoExtension))]
		public void CSV読込() {
			var file = new FileInfo(@"C:\Users\mossSystemAdmin\Documents\data\MedicalCheckup_Data.csv");
			var tbl = file.GetCsvTable();
			var rows = tbl.GetRows().ToList();

			var expected = $"{1}";
			var actual = rows[0][0];
			Assert.AreEqual(expected, actual);
		}

		#endregion

		#endregion
	}
}
