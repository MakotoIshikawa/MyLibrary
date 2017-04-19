﻿using System;
using System.Collections;
using System.IO;
using System.Linq;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectAnalysisProject.Extensions;
using UnitTestExtensions.Data;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestExtensions {
		#region メソッド

		#region DataTableExtension

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.DataTableExtension))]
		public void テーブル変換() {
			var items = new[] {
				new UserInfo { 姓="斎藤", 名="一郎", 生年月日=new DateTime(1980,2,1), 住所="東京都" },
				new UserInfo { 姓="鈴木", 名="次郎", 生年月日=new DateTime(1990,5,5), 住所="埼玉県" },
				new UserInfo { 姓="田中", 名="三郎", 生年月日=new DateTime(1975,4,20), 住所="千葉県" },
			}.ToList();

			var tbl = items.ToDataTable();
			Assert.IsNotNull(tbl);

			var rows = tbl.GetRows().ToList();
			{
				// 期待値
				var expected = 3;

				// 実際値
				var actual = rows.Count;

				Assert.AreEqual(expected, actual);
			}

			var cols = tbl.GetColumns().ToList();
			{
				// 期待値
				var expected = 5;

				// 実際値
				var actual = cols.Count;

				Assert.AreEqual(expected, actual);
			}

			var collection = tbl.ConvertCollection<UserInfo>();

			var ret = items.SequenceEqual(collection);
			Assert.IsTrue(ret);
		}

		#endregion

		#region DateTimeExtension

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.DateTimeExtension))]
		public void 日付判定() {
			var tim1 = DateTime.Now;
			var tim2 = DateTime.Today;

			Assert.IsFalse(tim1.IsDay());
			Assert.IsTrue(tim2.IsDay());

			{
				// 期待値
				var expected = tim2.ToMilliSecondString();

				// 実際値
				var actual = tim1.Date.ToMilliSecondString();

				Assert.AreEqual(expected, actual);
			}
		}

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

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.FileInfoExtension))]
		public void ファイル名取得() {
			var name = "abcdef";
			{
				var file = new FileInfo($@"C:\work\{name}.JPG");

				// 期待値
				var expected = name;

				// 実際値
				var actual = file.GetNameWithoutExtension();

				Assert.AreEqual(expected, actual);
			}
			{
				var file = new FileInfo($@"C:\work\{name}.exe.zip");

				// 期待値
				var expected = name;

				// 実際値
				var actual = file.GetNameWithoutExtension();

				Assert.AreEqual(expected, actual);
			}
		}

		#endregion

		#region GenericsExtension

		#endregion

		#region ListExtension

		#endregion

		#region ObjectExtension

		#endregion

		#region StringExtension

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.StringExtension))]
		public void 文字列連結() {
			{
				var strs = new[] { "abcd", "efgh", "ijkl", };

				// 期待値
				var expected = $"{strs[0]}{strs[1]}{strs[2]}";

				// 実際値
				var actual = strs.Join();

				Assert.AreEqual(expected, actual);
			}
			{
				var strs = "abcdefghijkl";

				// 期待値
				var expected = strs;

				// 実際値
				var actual = strs.Join();

				Assert.AreEqual(expected, actual);
			}
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.StringExtension))]
		public void 繰り返し文字列生成() {
			{
				var str = "_/";

				// 期待値
				var expected = $"{str}{str}{str}";

				// 実際値
				var actual = str.Repeat(3);

				Assert.AreEqual(expected, actual);
			}
			{
				var chr = '0';

				// 期待値
				var expected = $"{chr}{chr}{chr}";

				// 実際値
				var actual = chr.Repeat(3);

				Assert.AreEqual(expected, actual);
			}
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.StringExtension))]
		public void 文字列細分化() {
			{
				var separator = ", ";
				var ary = new[] { "月", "火", "水", "木", "金", "土", "日", };
				var str = ary.Join(separator);

				// 期待値
				var expected = ary;

				// 実際値
				var actual = str.Split(true, separator);

				var ret = expected.StructuralEquals(actual);
				Assert.IsTrue(ret);
			}
		}

		#endregion

		#region TupleExtension

		#endregion

		#region TypeExtension

		#endregion

		#region UriExtension

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ExtensionsLibrary.Extensions.UriExtension))]
		public void URLファイル種別判定() {
			Assert.IsTrue(new Uri(@"http://www.hogohogo.com/aaaaa.JPG").IsImage());
			Assert.IsTrue(new Uri(@"http://www.hogohogo.com/aaaaa.jpg").IsSharePointIcon());
			Assert.IsTrue(new Uri(@"http://www.hogohogo.com/aaaaa.JPEG").IsImage());
			Assert.IsTrue(new Uri(@"http://www.hogohogo.com/aaaaa.jpeg").IsSharePointIcon());
			Assert.IsTrue(new Uri(@"http://www.hogohogo.com/aaaaa.xlsm").IsSharePointIcon());
			Assert.IsTrue(new Uri(@"http://www.hogohogo.com/aaaaa.docm").IsSharePointIcon());
			Assert.IsTrue(new Uri(@"http://www.hogohogo.com/aaaaa.htm").IsSharePointIcon());
			Assert.IsFalse(new Uri(@"http://www.hitachi.co.jp/New/cnews/month/2015/08/0825.html").IsSharePointIcon());
		}

		#endregion

		#endregion
	}
}
