using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using ExcelLibrary;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectAnalysisProject.Extensions;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestExcel {
		#region フィールド

		private string _root = @"C:\Excel";

		#endregion

		#region メソッド

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[WorkItem(1)]
		[TestCategory("コンストラクタ")]
		public void ExcelManagerTest() {
			var xlsx = new ExcelManager($@"{this._root}\test.xlsx");

			Assert.AreEqual("Sheet1", xlsx.SheetName);
			Assert.AreEqual(1, xlsx.Position);
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("コンストラクタ")]
		[WorkItem(2)]
		[ExpectedException(typeof(System.ArgumentException))]
		public void ExcelManagerTest1() {
			var xlsx = new ExcelManager($@"{this._root}\test.xlsx", "XXXXX");
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("コンストラクタ")]
		[WorkItem(3)]
		[ExpectedException(typeof(System.ArgumentException))]
		public void ExcelManagerTest2() {
			var xlsx = new ExcelManager($@"{this._root}\test.xlsx", -1);
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("コンストラクタ")]
		[WorkItem(4)]
		[ExpectedException(typeof(System.ArgumentException))]
		public void ExcelManagerTest3() {
			var xlsx = new ExcelManager($@"{this._root}\test.xlsx", 99);
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("コンストラクタ")]
		[WorkItem(5)]
		public void ExcelManagerTest4() {
			var destDir = @"tmp2";
			var xltm = new ExcelManager($@"{this._root}\{destDir}\勤怠実績_tm.xlsm", new FileInfo($@"{this._root}\KinmuJisseki.xltm"));
			var xlsm = new ExcelManager($@"{this._root}\{destDir}\勤怠実績_sm.xlsm", new FileInfo($@"{this._root}\KinmuJisseki.xlsm"));
			var xltx = new ExcelManager($@"{this._root}\{destDir}\勤怠実績_tx.xlsx", new FileInfo($@"{this._root}\KinmuJisseki.xltx"));
			var xlsx = new ExcelManager($@"{this._root}\{destDir}\勤怠実績_sx.xlsx", new FileInfo($@"{this._root}\KinmuJisseki.xlsx"));
			var xlsx2 = new ExcelManager($@"{this._root}\{destDir}\勤怠実績表.xlsm", new FileInfo($@"{this._root}\KintaiJissekiList.xltm"));
			var xlsx3 = new ExcelManager($@"{this._root}\{destDir}\交番表.xlsm", new FileInfo($@"{this._root}\Koubanhyou.xltm"));
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("追加")]
		[WorkItem(5)]
		public void ワークシート追加() {
			var xlsx = new ExcelManager($@"{this._root}\test.xlsx");
			var cnt = xlsx.SheetCount;

			var sheet = xlsx.AddSheet();

			cnt++;
			Assert.AreEqual(cnt, xlsx.SheetCount);
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("追加")]
		[WorkItem(5)]
		public void ワークシート追加名前指定() {
			var xlsx = new ExcelManager($@"{this._root}\Book1.xlsx", "シート1");
			var cnt = xlsx.SheetCount;
			cnt++;

			var sheet = xlsx.AddSheet($"シート{cnt}");

			Assert.AreEqual(cnt, xlsx.SheetCount);
		}

		[TestMethod]
		[Owner("Excel 出力")]
		[TestCategory("更新処理")]
		public void セル更新() {
			var xlsx = new ExcelManager($@"{this._root}\test.xlsx");
			xlsx.Position = xlsx.SheetCount;
			xlsx.UpdateSheet(sheet => {
				sheet.Cells["A1"].Value = "ネタ";
				sheet.Cells["B1"].Value = "単価";
				sheet.Cells["C1"].Value = "個数";
				sheet.Cells["D1"].Value = "小計";

				var rnd = new Random();
				var neta = new[] { "鮪", "烏賊", "エンガワ", "雲丹", "イクラ", "鰺", "穴子", "石鯛", "鰯", "鰹" };

				var ls = neta.Select((n, i) => new {
					row = i + 2,
					ネタ = n,
					単価 = rnd.Next(100, 200),
					個数 = rnd.Next(0, 20),
				}).Select(r => new {
					r.row,
					r.ネタ,
					r.単価,
					r.個数,
					小計 = $"B{r.row}*C{r.row}",
				});

				ls.ForEach((r, i) => {
					sheet.Cells[r.row, 1].Value = r.ネタ;
					sheet.Cells[r.row, 2].Value = r.個数;
					sheet.Cells[r.row, 3].Value = r.単価;
					sheet.Cells[r.row, 4].Formula = r.小計;
				});

				using (var range = sheet.Cells[1, 1, 1, 4]) {
					// フォントをBoldにする。Italic や Strike（取消）、UnderLine も同様
					range.Style.Font.Bold = true;

					// セルの背景色指定（要 PatternType の指定）
					range.Style.Fill.PatternType = ExcelFillStyle.Solid;
					range.Style.Fill.BackgroundColor.SetColor(Color.DimGray);

					// フォントカラーの設定
					range.Style.Font.Color.SetColor(Color.WhiteSmoke);

					// フォントサイズの指定
					range.Style.Font.Size = 9;

					// 中央揃え
					range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
				}

				using (var range = sheet.Cells[2, 1, 11, 1]) {
					// フォントの指定 range.Style.Font.Name でフォントだけ指定することも可
					range.Style.Font.SetFromFont(new Font("ＭＳ Ｐ明朝", 9, FontStyle.Regular));
				}

				using (var range = sheet.Cells[2, 2, 11, 4]) {
					range.Style.Font.SetFromFont(new Font("Calibri Light", 9, FontStyle.Regular));

					// 数値を3桁区切り
					range.Style.Numberformat.Format = "#,##0";
				}
			});
		}

		[TestMethod]
		[Owner("Excel 出力")]
		[TestCategory("確認")]
		public void 更新データ確認() {
			var xlsx = new ExcelManager($@"{this._root}\test.xlsx");
			xlsx.Position = xlsx.SheetCount;
			var intRow = 1;
			{
				var expected = "ネタ";
				var actual = xlsx[$"A{intRow}"];
				Assert.AreEqual(expected, actual);
			}
			{
				var expected = "単価";
				var actual = xlsx[$"B{intRow}"];
				Assert.AreEqual(expected, actual);
			}
			{
				var expected = "個数";
				var actual = xlsx[$"C{intRow}"];
				Assert.AreEqual(expected, actual);
			}
			{
				var expected = "小計";
				var actual = xlsx[$"D{intRow}"];
				Assert.AreEqual(expected, actual);
			}
		}

		[TestMethod]
		[Owner("Excel 出力")]
		[TestCategory("出力テスト")]
		public void LoadFromCollection_MemberList_Test() {
			var ls = Enumerable.Range(1, 10).Select(i => new {
				Col1 = i,
				Col2 = i * 10,
				Col3 = $"{(i * 10)}E4",
				Col4 = DateTime.Now,
			}).ToList();

			var file = new FileInfo($@"{this._root}\LoadFromCollection_MemberList_Test.xlsx");
			if (file.Exists) {
				file.Delete();
			}

			var printHeaders = true;
			var tableStyle = TableStyles.Dark1;
			var memberFlags = BindingFlags.Public | BindingFlags.Instance;

			// Col1 を含めない
			var members = ls.First().GetType().GetProperties().Cast<MemberInfo>()
				.Where(pi => pi.Name != "Col1")
				.ToArray();

			var tbl = ls.ToDataTable();
			tbl.TableName = "テストテーブル";

			using (var pck = new ExcelPackage(file)) {
				var sheet1 = pck.Workbook.Worksheets.Add("Sheet1");
				sheet1.Cells.LoadFromCollection(ls, printHeaders, tableStyle, memberFlags, members);

				var sheet2 = pck.Workbook.Worksheets.Add("Sheet2");
				sheet2.Cells.LoadFromDataTable(tbl, true, TableStyles.Light1);

				pck.Save();
			}
		}

		#endregion
	}
}
