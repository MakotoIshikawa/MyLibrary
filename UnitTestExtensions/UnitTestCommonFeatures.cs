using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary;
using CommonFeaturesLibrary.Extensions;
using CommonFeaturesLibrary.Providers.Excel;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.CompilerServices;
using System.Data;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestCommonFeatures {
		#region プロパティ

		/// <summary>
		/// リソースフォルダのディレクトリ情報を取得します。
		/// </summary>
		public static DirectoryInfo Resources => new DirectoryInfo(@".");

		#endregion

		#region メソッド

		#region FileInfoExtension

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(CommonFeaturesLibrary.Extensions.FileInfoExtension))]
		public void ファイル名変更() {
			var dir = Resources.FullName;
			var file = new FileInfo(Path.Combine(dir, @"L.txt"));
			var fname0 = file.GetVersionName(0);
			var fname1 = file.GetVersionName(1);

			var expected = Path.Combine(dir, @"L (1).txt");
			var actual = fname1;
			Assert.AreEqual(expected, actual);
		}

		#endregion

		#region CsvReader

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(CommonFeaturesLibrary.Extensions.FileInfoExtension))]
		[DeploymentItem(@"Resources")]
		public void CSV読込() {
			var dir = Resources.FullName;
			var file = new FileInfo(Path.Combine(dir, @"UserInfos.csv"));
			var tbl = file.GetCsvTable();
			var rows = tbl.GetRows().ToList();

			var expected = $"斎藤";
			var actual = rows[0][0];
			Assert.AreEqual(expected, actual);
		}

		#endregion

		#region Excel

		[TestMethod]
		[Owner(nameof(CommonFeaturesLibrary))]
		[TestCategory(nameof(CommonFeaturesLibrary.Providers.Excel.ExcelConnection))]
		public void Excel読込() {
			var file = new FileInfo(@"C:\Excel\交番カレンダー\マスタ_交番カレンダー_テンプレート.xlsx");
			{
				var con = new ExcelConnection(file) { TableName = "月次勤怠情報" };
				var tbl = con.Load();
				var rows = (
					from row in tbl.GetRows()
					select new {
						月 = row.Field<double>("月"),
						月次計画労働時間 = new TimeSpan(Convert.ToInt32(row.Field<double>("月次計画労働時間")), 0, 0),
						月次所定時間 = new TimeSpan(Convert.ToInt32(row.Field<double>("月次所定時間")), 0, 0),
						月次公休日数 = row.Field<double>("月次公休日数"),
						社員区分 = row.Field<string>("社員区分"),
					}
				).ToList();

				var expected = 4.0;
				var actual = rows[0].月;
				Assert.AreEqual(expected, actual);
			}
			{
				var con = new ExcelConnection(file) { TableName = "日次勤怠情報" };
				var tbl = con.Load();
				var rows = (
					from row in tbl.GetRows()
					select new {
						勤務日 = row.Field<DateTime>("勤務日"),
						勤怠区分 = row.Field<string>("勤怠区分"),
						所定時間 = row.Field<string>("所定時間").ToTimeSpan(),
						出勤時間 = row.Field<string>("出勤時間").ToTimeSpan(),
						退勤時間 = row.Field<string>("退勤時間").ToTimeSpan(),
						休憩時間 = row.Field<string>("休憩時間").ToTimeSpan(),
						社員区分 = row.Field<string>("社員区分"),
						計画時間 = row.Field<string>("計画時間").ToTimeSpan(),
					}
				).ToList();

				var expected = new DateTime(2017, 3, 16);
				var actual = rows[0].勤務日;
				Assert.AreEqual(expected, actual);
			}
		}

		#endregion

		#endregion
	}
}
