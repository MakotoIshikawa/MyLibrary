﻿using System;
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
		#region プロパティ

		/// <summary>
		/// リソースフォルダのディレクトリ情報を取得します。
		/// </summary>
		public static DirectoryInfo Resources => new DirectoryInfo(@"..\..\..\..\..\..\..\..\UnitTestExtensions\Resources");

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
		public void CSV読込() {
			var dir = Resources.FullName;
			var file = new FileInfo(Path.Combine(dir, @"UserInfos.csv") );
			var tbl = file.GetCsvTable();
			var rows = tbl.GetRows().ToList();

			var expected = $"斎藤";
			var actual = rows[0][0];
			Assert.AreEqual(expected, actual);
		}

		#endregion

		#endregion
	}
}
