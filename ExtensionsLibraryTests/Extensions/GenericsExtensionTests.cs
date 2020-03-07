using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionsLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExtensionsLibrary.Extensions.Tests {
	public enum TestTypes : short {
		Test01 = 1,
		Test02,
		Test03,
		Test04,
	}

	[TestClass]
	public class GenericsExtensionTests {
		[TestMethod]
		public void GetValueOrDefaultTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetValueOrDefaultTest1() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetCollectionTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetStringTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetMembersTest() {
			{
				var test = "こんにちわ";
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(string), Value: test), m.Single(i => i.Name is "Value"));
				Assert.AreEqual((Name: nameof(string.Length), Type: typeof(int), Value: test.Length), m.Single(i => i.Name is nameof(string.Length)));
				Assert.AreEqual((Name: nameof(string.Empty), Type: typeof(string), Value: string.Empty), m.Single(i => i.Name is nameof(string.Empty)));
			}
			{
				var test = MemberTypes.Field;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(int), Value: test.ToInt32()), m.Single(i => i.Name is "Value"));
			}
			{
				var test = TestTypes.Test03;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(short), Value: test.ToInt16()), m.Single(i => i.Name is "Value"));
			}
			{
				var test = DateTime.Now;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(DateTime), Value: test), m.Single(i => i.Name is "Value"));
			}
			{
				var test = 3.141592f;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(float), Value: test), m.Single(i => i.Name is "Value"));
			}
			{
				var test = 3.141592m;
				var m = test.GetMembers();

				Assert.AreEqual((Name: "Value", Type: typeof(decimal), Value: test), m.Single(i => i.Name is "Value"));
			}
			{
				var test = new {
					Col01 = "001",
					Col02 = "002",
					Col03 = "003",
				};
				var m = test.GetMembers();

				Assert.AreEqual((Name: nameof(test.Col01), Type: typeof(string), Value: test.Col01), m.Single(i => i.Name is nameof(test.Col01)));
			}
		}

		[TestMethod]
		public void GetPropertyInfoTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetPropertyValueTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void SetPropertyValueTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetPropertiesTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void SetPropertiesTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void ToPropertyDictionaryTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetPropertiesStringTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetFieldInfoTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetFieldValueTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void SetFieldValueTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetFieldsTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void SetFieldsTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void ToFieldDictionaryTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void GetFieldsStringTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void ChangeTypeTest() {
			throw new NotImplementedException();
		}

		[TestMethod]
		public void ChangeTypeTest1() {
			throw new NotImplementedException();
		}
	}
}