using System;
using System.Drawing;
using System.IO;
using System.Linq;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeLibrary;
using OfficeOpenXml.Style;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestOffice {
		#region メソッド

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[WorkItem(1)]
		[TestCategory("コンストラクタ")]
		public void ExcelManagerTest() {
			var xlsx = new ExcelManager(@"C:\Excel\test.xlsx");

			Assert.AreEqual("Sheet1", xlsx.SheetName);
			Assert.AreEqual(1, xlsx.Position);
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("コンストラクタ")]
		[WorkItem(2)]
		[ExpectedException(typeof(System.ArgumentException))]
		public void ExcelManagerTest1() {
			var xlsx = new ExcelManager(@"C:\Excel\test.xlsx", "XXXXX");
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("コンストラクタ")]
		[WorkItem(3)]
		[ExpectedException(typeof(System.ArgumentException))]
		public void ExcelManagerTest2() {
			var xlsx = new ExcelManager(@"C:\Excel\test.xlsx", -1);
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("コンストラクタ")]
		[WorkItem(4)]
		[ExpectedException(typeof(System.ArgumentException))]
		public void ExcelManagerTest3() {
			var xlsx = new ExcelManager(@"C:\Excel\test.xlsx", 99);
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("コンストラクタ")]
		[WorkItem(5)]
		public void ExcelManagerTest4() {
			var xlsx = new ExcelManager(@"C:\Excel\test02.xlsx", new FileInfo(@"C:\Excel\test01.xlsx"));
		}

		[TestMethod]
		[Owner(nameof(ExcelManager))]
		[TestCategory("追加")]
		[WorkItem(5)]
		public void ワークシート追加() {
			var xlsx = new ExcelManager(@"C:\Excel\test.xlsx");
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
			var xlsx = new ExcelManager(@"C:\Excel\Book1.xlsx", "シート１");
			var cnt = xlsx.SheetCount;

			var sheet = xlsx.AddSheet("シート２");

			cnt++;
			Assert.AreEqual(cnt, xlsx.SheetCount);
		}

		[TestMethod]
		[Owner("Excel 出力")]
		[TestCategory("更新処理")]
		public void セル更新() {
			var xlsx = new ExcelManager(@"C:\Excel\test.xlsx");
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
		public void 更新データ確認() {
			var xlsx = new ExcelManager(@"C:\Excel\test.xlsx");
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

		#endregion
	}
}
