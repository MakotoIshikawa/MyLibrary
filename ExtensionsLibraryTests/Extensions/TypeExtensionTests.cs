using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExtensionsLibrary.Extensions;
using ExtensionsLibraryTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsLibrary.Extensions.Tests {
	[TestClass]
	public class TypeExtensionTests {
		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(TypeExtension))]
		[TestCategory(nameof(TypeExtension.GetIndexerName))]
		[TestCategory("インデクサー")]
		[Description("インデクサー名取得")]
		public void GetIndexerNameTest() {
			Assert.AreEqual("Item", typeof(DataRow).GetIndexerName());
			Assert.AreEqual("Item", typeof(Dictionary<string, int>).GetIndexerName());
			Assert.AreEqual("Indexer", typeof(TestOfIndexer).GetIndexerName());

			var defType = typeof(TestOfDefault);
			Assert.AreEqual(nameof(TestOfDefault.Age), defType.GetCustomAttribute<DefaultMemberAttribute>()?.MemberName);
			Assert.AreEqual(null, defType.GetIndexerName());
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(TypeExtension))]
		[TestCategory(nameof(TypeExtension.GetIndexers))]
		[TestCategory("インデクサー")]
		[Description("インデクサー取得")]
		public void GetIndexersTest() {
			var dictExpr = Expression.Parameter(typeof(Dictionary<string, int>));

			// インデクサーのオーバーロードがない場合は、これで取得できます。
			var indexerInfo = dictExpr.Type.GetProperty("Item");

			// インデクサーのオーバーロードがある場合、パラメーターのタイプで探すこともできることに注意してください。
			var indexer = (
				from p in dictExpr.Type.GetIndexers()
				where
					// C＃では戻り値をオーバーロードできないため、このチェックでは絞れないでしょう。
					p.Info.PropertyType == typeof(int)
					// ここで、正確なオーバーロードを検索できます。
					// 長さはインデクサーの「パラメーター」の数であり、そのタイプを確認できます。
					&& p.IndexParameters.Length == 1
					&& p.IndexParameters[0].ParameterType == typeof(string)
				select
					p.Info
			).Single();

			Assert.AreEqual(indexerInfo, indexer);

			var keyExpr = Expression.Parameter(typeof(string));
			var valueExpr = Expression.Parameter(typeof(int));
			var indexExpr = Expression.Property(dictExpr, indexer, keyExpr);
			var assign = Expression.Assign(indexExpr, valueExpr);

			var lambdaSetter = Expression.Lambda<Action<Dictionary<string, int>, string, int>>(assign, dictExpr, keyExpr, valueExpr);
			var setter = lambdaSetter.Compile();

			var lambdaGetter = Expression.Lambda<Func<Dictionary<string, int>, string, int>>(indexExpr, dictExpr, keyExpr);
			var getter = lambdaGetter.Compile();

			var key = "MyKey";
			var expected = 2;

			var dict = new Dictionary<string, int>();
			setter(dict, key, expected);

			var actual = getter(dict, key);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(TypeExtension))]
		[TestCategory(nameof(TypeExtension.GetIndexers))]
		[TestCategory("インデクサー")]
		[Description("インデクサー取得")]
		public void GetIndexersTest01() {
			var rowExpr = Expression.Parameter(typeof(DataRow));
			var keyExpr = Expression.Parameter(typeof(string));
			var valueExpr = Expression.Parameter(typeof(object));

			var indexers = rowExpr.Type.GetIndexers().Where(i => i.IndexParameters[0].ParameterType == keyExpr.Type);

			Assert.AreEqual(2, indexers.Count());

			var indexer = indexers.Select(i => i.Info).First();
			var indexExpr = Expression.Property(rowExpr, indexer, keyExpr);
			var assign = Expression.Assign(indexExpr, valueExpr);

			var lambdaSetter = Expression.Lambda<Action<DataRow, string, object>>(assign, rowExpr, keyExpr, valueExpr);
			var setter = lambdaSetter.Compile();

			var lambdaGetter = Expression.Lambda<Func<DataRow, string, object>>(indexExpr, rowExpr, keyExpr);
			var getter = lambdaGetter.Compile();

			var key = "列１";
			var expected = "データ";

			var tb = new DataTable();
			_ = tb.Columns.Add(key);
			var row = tb.NewRow();
			setter(row, key, expected);

			var actual = getter(row, key);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(TypeExtension))]
		[TestCategory(nameof(TypeExtension.GetPropertiesWithoutIndexer))]
		[TestCategory("インデクサー")]
		[Description("インデクサー抜きのプロパティ情報取得")]
		public void GetPropertiesWithoutIndexerTest() {
			var type = typeof(TestOfIndexer);

			var properties = type.GetPropertiesWithoutIndexer();

			foreach (var item in properties) {
				Debug.WriteLine(item.Name);
			}

			Assert.AreEqual(2, properties.Count());
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(TypeExtension))]
		[TestCategory(nameof(TypeExtension.IsNullable))]
		[TestCategory(nameof(Nullable) + " 判定")]
		public void IsNullableTest() {
			Assert.IsTrue(typeof(int?).IsNullable());
			Assert.IsTrue(typeof(DateTime?).IsNullable());
			Assert.IsFalse(typeof(int).IsNullable());
			Assert.IsFalse(typeof(DateTime).IsNullable());
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(TypeExtension))]
		[TestCategory(nameof(TypeExtension.GetTypeCode))]
		[TestCategory(nameof(TypeCode) + " 取得")]
		public void GetTypeCodeTest() {
			Assert.AreEqual(TypeCode.Empty, ((Type)null).GetTypeCode());
			Assert.AreEqual(TypeCode.Object, typeof(object).GetTypeCode());
			Assert.AreEqual(TypeCode.DBNull, typeof(DBNull).GetTypeCode());
			Assert.AreEqual(TypeCode.Boolean, typeof(bool).GetTypeCode());
			Assert.AreEqual(TypeCode.Int32, typeof(int).GetTypeCode());
			Assert.AreEqual(TypeCode.Double, typeof(double).GetTypeCode());
			Assert.AreEqual(TypeCode.Decimal, typeof(decimal).GetTypeCode());
			Assert.AreEqual(TypeCode.DateTime, typeof(DateTime).GetTypeCode());
			Assert.AreEqual(TypeCode.String, typeof(string).GetTypeCode());
		}
	}
}