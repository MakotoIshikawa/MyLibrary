using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonFeaturesLibrary.Extensions.Tests {
	[TestClass]
	public class CsvReaderExtensionTests {
		#region プロパティ

		/// <summary>
		/// リソースフォルダのディレクトリ情報を取得します。
		/// </summary>
		public static DirectoryInfo Resources => new DirectoryInfo(@".\Resources");

		#endregion

		#region メソッド

		#region GetCsvTable

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(CsvReaderExtension))]
		[TestCategory(nameof(CsvReaderExtension.GetCsvTable))]
		[DeploymentItem(@"Resources\UserInfos.csv", @"Resources")]
		public void GetCsvTableTest01() {
			foreach (var file in Resources.GetFiles("*.csv")) {
				var tbl = file.GetCsvTable();
				var rows = tbl.GetRows().ToList();

				var expected = $"斎藤";
				var actual = rows[0][0];
				Assert.AreEqual(expected, actual);
			}
		}

		#endregion

		#region GetCsvTableAsync

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(CsvReaderExtension))]
		[TestCategory(nameof(CsvReaderExtension.GetCsvTableAsync))]
		public async Task GetCsvTableAsyncTest() {
			foreach (var file in Resources.GetFiles("*.csv")) {
				var tbl = await file.GetCsvTableAsync();
				var rows = tbl.GetRows().ToList();

				var expected = $"斎藤";
				var actual = rows[0][0];
				Assert.AreEqual(expected, actual);
			}
		}

		#endregion

		#endregion
	}
}