using System;
using System.Data;
using System.IO;
using System.Linq;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeLibrary.Providers.Excel;

namespace UnitTestExtensions {
    [TestClass]
    public partial class UnitTestOffice {
        #region フィールド

        private string _root = @"C:\Excel";

        #endregion

        #region メソッド

        #region Excel

        [TestMethod]
        [Owner(nameof(CommonFeaturesLibrary))]
        [TestCategory(nameof(OfficeLibrary.Providers.Excel.ExcelConnection))]
        public void Excel読込() {
            var fileName = Path.Combine(_root, @"交番カレンダー\マスタ_交番カレンダー_テンプレート.xlsx");
            var file = new FileInfo(fileName);
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
