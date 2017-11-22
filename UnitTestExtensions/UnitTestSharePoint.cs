using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary.Extensions;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestSharePoint {
		#region メソッド

		[TestMethod]
		[Owner(nameof(SharePointLibrary))]
		[TestCategory("変更")]
		public void チャック毎の処理() {
			var items = (
				from i in Enumerable.Range(1, 5000)
				select new {
					Index = i,
					Title = $"タイトル{i:0000000}",
					ID = $"{i:0000000}",
				}
			);

			var chunks = items.MakeChunksPerSize(500)
				.Select(i => i.ToList())
				.ToList();

			Assert.AreEqual(10, chunks.Count());
		}

		#endregion
	}
}
