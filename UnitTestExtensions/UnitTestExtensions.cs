using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary.Extensions;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectAnalysisProject.Extensions;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestExtensions {
		#region メソッド

		#region DataTableExtension

		class UserInfo {
			public string 姓 { get; set; }
			public string 名 { get; set; }
			public string 姓名 => this.姓 + this.名;
			public DateTime 生年月日 { get; set; }
			public string 住所 { get; set; }
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.DataTableExtension))]
		public void テーブル変換() {
			var items = new[] {
				new UserInfo { 姓="斎藤", 名="一郎", 生年月日=new DateTime(1980,2,1), 住所="東京都" },
				new UserInfo { 姓="鈴木", 名="次郎", 生年月日=new DateTime(1990,5,5), 住所="埼玉県" },
				new UserInfo { 姓="田中", 名="三郎", 生年月日=new DateTime(1975,4,20), 住所="千葉県" },
			};

			var tbl = items.ToDataTable();

			var rows = tbl.GetRows().ToList();
			var cols = tbl.GetColumns().ToList();

			var collection = tbl.ConvertCollection<UserInfo>().ToArray();

			Assert.IsTrue(items.SequenceEqual(collection));
		}

		#endregion

		#region DateTimeExtension

		#endregion

		#region DictionaryExtension

		#endregion

		#region DirectoryInfoExtension

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.DirectoryInfoExtension))]
		public void ディレクトリ内ファイル取得() {
			var fullPath = $@"C:\work";
			var dir = new DirectoryInfo(fullPath);
			var files = dir.GetFileInfos(true, ".htm", ".html");

			Assert.IsTrue(files.Any());
			Assert.IsFalse(files.Any(f => f.Extension == ".htm"));
			Assert.IsFalse(files.Any(f => f.Extension == ".html"));
		}

		#endregion

		#region EnumerableExtension

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

		#region GenericsExtension

		#endregion

		#region ListExtension

		#endregion

		#region ObjectExtension

		#endregion

		#region StringExtension

		#endregion

		#region TupleExtension

		#endregion

		#region TypeExtension

		#endregion

		#region UriExtension

		#endregion

		#endregion
	}
}
