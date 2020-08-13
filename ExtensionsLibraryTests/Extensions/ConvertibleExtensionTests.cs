using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsLibrary.Extensions.Tests {
	[TestClass]
	public class ConvertibleExtensionTests {
		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ConvertibleExtension))]
		[TestCategory(nameof(ConvertibleExtension.ChangeType))]
		public void ChangeTypeTest() {
			Assert.AreEqual(1, "1".ChangeType(typeof(int)));
			Assert.AreEqual(1.0, "1.0".ChangeType(typeof(double)));
			Assert.AreEqual(1.0m, "1.0".ChangeType(typeof(decimal)));

			Assert.AreEqual(1, "1".ChangeType(typeof(int?)));
			Assert.AreEqual(1.0, "1.0".ChangeType(typeof(double?)));
			Assert.AreEqual(1.0m, "1.0".ChangeType(typeof(decimal?)));

			Assert.AreEqual(new DateTime(2020, 08, 13), "2020/08/13 00:00:00".ChangeType(typeof(DateTime?)));
			Assert.AreEqual(new DateTime(2020, 08, 13, 12, 30, 0), "2020-8-13T12:30:00".ChangeType(typeof(DateTime?)));

			var today = DateTime.Today;
			Debug.WriteLine(today);
			Assert.AreEqual(new DateTime(today.Year, today.Month, today.Day, 23, 59, 59), "23:59:59".ChangeType(typeof(DateTime)));

			Assert.IsNull(((string)null).ChangeType(typeof(int?)));
			Assert.IsNull(((string)null).ChangeType(typeof(double?)));
			Assert.IsNull(((string)null).ChangeType(typeof(decimal?)));
			Assert.IsNull(((string)null).ChangeType(typeof(DateTime?)));
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ConvertibleExtension))]
		[TestCategory(nameof(ConvertibleExtension.ChangeType))]
		[TestCategory(nameof(Int32) + " 型変換 例外")]
		[ExpectedException(typeof(FormatException))]
		public void ChangeTypeTest_Int32_FormatException() {
			_ = "1.0".ChangeType(typeof(int));
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ConvertibleExtension))]
		[TestCategory(nameof(ConvertibleExtension.ChangeType))]
		[TestCategory(nameof(Int32) + " 型変換 例外")]
		[ExpectedException(typeof(InvalidCastException))]
		public void ChangeTypeTest_Int32_InvalidCastException() {
			_ = ((string)null).ChangeType(typeof(int));
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ConvertibleExtension))]
		[TestCategory(nameof(ConvertibleExtension.ChangeType))]
		[TestCategory(nameof(Int32) + " 型変換 例外")]
		[ExpectedException(typeof(FormatException))]
		public void ChangeTypeTest_DateTime_FormatException() {
			_ = "20200813".ChangeType(typeof(DateTime));
		}
	}
}