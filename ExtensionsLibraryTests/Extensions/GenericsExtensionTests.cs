﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using ExtensionsLibraryTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsLibrary.Extensions.Tests {
	public enum TestTypes : short {
		Test01 = 1,
		Test02,
		Test03,
		Test04,
	}

	[TestClass]
	public class GenericsExtensionTests {
		#region 値取得

		#region GetValueOrDefault (+1 オーバーロード)

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("値取得")]
		public void GetValueOrDefaultTest() {
			{
				var test = "こんにちわ";

				Assert.AreEqual("んにち", test.GetValueOrDefault(x => x[1..^1]));
				Assert.AreEqual(test.Length, test.GetValueOrDefault(x => x.Length));
				Assert.AreEqual(null, test.GetValueOrDefault(x => x[0..100]));
			}
			{
				var test = MemberTypes.Field;

				Assert.AreEqual(test.ToString(), test.GetValueOrDefault(x => x.ToString()));
			}
			{
				var test = TestTypes.Test03;

				Assert.AreEqual(test.ToString(), test.GetValueOrDefault(x => x.ToString()));
			}
			{
				var test = new {
					Col01 = "001",
					Col02 = "002",
					Col03 = "003",
				};
				var m = test.GetMembers();

				Assert.AreEqual(test.Col01, test.GetValueOrDefault(x => x.Col01));
			}
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("値取得")]
		public void GetValueOrDefaultTest1() {
			{
				var test = "こんにちわ";

				Assert.AreEqual("んにち", test.GetValueOrDefault(x => x[1..^1]));
				Assert.AreEqual(test.Length, test.GetValueOrDefault(x => x.Length));
				Assert.AreEqual(string.Empty, test.GetValueOrDefault(null, string.Empty));
			}
		}

		#endregion

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("値取得")]
		public void GetCollectionTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("値取得")]
		public void GetStringTest() {
			var type = typeof(TestOfIndexer);

			var properties = type.GetPropertiesWithoutIndexer();

			foreach (var item in properties) {
				Debug.WriteLine(item.Name);
			}

			Assert.AreEqual(1, properties.Count());
		}

		#endregion

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("メンバー情報取得")]
		public void GetMembersTest() {
			{
				var test = "こんにちわ";
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(string), Value: test, Code: TypeCode.String), m.Single(i => i.Name is "Value"));
				Assert.AreEqual((Name: nameof(string.Length), Type: typeof(int), Value: test.Length, Code: TypeCode.Int32), m.Single(i => i.Name is nameof(string.Length)));
				Assert.AreEqual((Name: nameof(string.Empty), Type: typeof(string), Value: string.Empty, Code: TypeCode.String), m.Single(i => i.Name is nameof(string.Empty)));
			}
			{
				var test = MemberTypes.Field;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(int), Value: test.ToInt32(), Code: TypeCode.Int32), m.Single(i => i.Name is "Value"));
			}
			{
				var test = TestTypes.Test03;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(short), Value: test.ToInt16(), Code: TypeCode.Int16), m.Single(i => i.Name is "Value"));
			}
			{
				var test = DateTime.Now;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(DateTime), Value: test, Code: TypeCode.DateTime), m.Single(i => i.Name is "Value"));
			}
			{
				var test = 3.141592f;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(float), Value: test, Code: TypeCode.Single), m.Single(i => i.Name is "Value"));
			}
			{
				var test = 3.141592m;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(decimal), Value: test, Code: TypeCode.Decimal), m.Single(i => i.Name is "Value"));
			}
			{
				var test = new {
					Col01 = "001",
					Col02 = "002",
					Col03 = "003",
				};
				var m = test.GetMembers();

				Assert.AreEqual((Name: nameof(test.Col01), Type: typeof(string), Value: test.Col01, Code: TypeCode.String), m.Single(i => i.Name is nameof(test.Col01)));
			}
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("プロパティ")]
		public void GetPropertyInfoTest() {
			var today = DateTime.Today;
			var info = today.GetPropertyInfo(nameof(DateTime.Year));
			Debug.WriteLine(info);
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("プロパティ")]
		public void GetPropertyValueTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("プロパティ")]
		public void SetPropertyValueTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("プロパティ")]
		public void GetPropertiesTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("プロパティ")]
		public void SetPropertiesTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("プロパティ")]
		public void ToPropertyDictionaryTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("プロパティ")]
		public void GetPropertiesStringTest() {
			{
				var test = new {
					Str = "001",
					Dec = 3.141592m,
					Tim = DateTime.Now,
					Typ = TestTypes.Test03,
					Length = 4,
				};
				var ps = test.GetPropertiesString();

				Assert.AreEqual($@"Str = ""001"", Dec = 3.141592, Tim = {test.Tim}, Typ = Test03, Length = 4", ps);
			}
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("フィールド")]
		public void GetFieldInfoTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("フィールド")]
		public void GetFieldValueTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("フィールド")]
		public void SetFieldValueTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("フィールド")]
		public void GetFieldsTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("フィールド")]
		public void SetFieldsTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("フィールド")]
		public void ToFieldDictionaryTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(GenericsExtension))]
		[TestCategory("フィールド")]
		public void GetFieldsStringTest() {
			throw new NotImplementedException();
		}
	}
}