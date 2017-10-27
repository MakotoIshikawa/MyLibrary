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

			Assert.AreEqual(DayOfWeek.Sunday, 0.ChangeType(typeof(DayOfWeek)));
			Assert.AreEqual(DayOfWeek.Monday, 1.ToString().ChangeType(typeof(DayOfWeek)));
			Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.Wednesday.ChangeType(typeof(DayOfWeek)));
			Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.Friday.ToString().ChangeType(typeof(DayOfWeek)));

			Assert.IsNull(((string)null).ChangeType(typeof(int?)));
			Assert.IsNull(((string)null).ChangeType(typeof(double?)));
			Assert.IsNull(((string)null).ChangeType(typeof(decimal?)));
			Assert.IsNull(((string)null).ChangeType(typeof(DateTime?)));
			Assert.IsNull(((string)null).ChangeType(typeof(DayOfWeek?)));
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
		[TestCategory(nameof(DateTime) + " 型変換 例外")]
		[ExpectedException(typeof(FormatException))]
		public void ChangeTypeTest_DateTime_FormatException() {
			_ = "20200813".ChangeType(typeof(DateTime));
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ConvertibleExtension))]
		[TestCategory(nameof(ConvertibleExtension.ChangeType))]
		[TestCategory(nameof(Enum) + " 型変換 例外")]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ChangeTypeTest_Enum_FormatException() {
			_ = ((string)null).ChangeType(typeof(DayOfWeek));
		}

		[TestMethod]
		[Owner(nameof(ExtensionsLibrary))]
		[TestCategory(nameof(ConvertibleExtension))]
		[TestCategory(nameof(ConvertibleExtension.OfType))]
		public void OfTypeTest() {
			Assert.AreEqual(1, "1".OfType<int>());
			Assert.AreEqual(1.0, "1.0".OfType<double>());
			Assert.AreEqual(1.0m, "1.0".OfType<decimal>());

			Assert.AreEqual(1, "1".OfType<int?>());
			Assert.AreEqual(1.0, "1.0".OfType<double?>());
			Assert.AreEqual(1.0m, "1.0".OfType<decimal?>());

			Assert.AreEqual(new DateTime(2020, 08, 13), "2020/08/13 00:00:00".OfType<DateTime?>());
			Assert.AreEqual(new DateTime(2020, 08, 13, 12, 30, 0), "2020-8-13T12:30:00".OfType<DateTime?>());

			var today = DateTime.Today;
			Debug.WriteLine(today);
			Assert.AreEqual(new DateTime(today.Year, today.Month, today.Day, 23, 59, 59), "23:59:59".OfType<DateTime>());

			Assert.AreEqual(DayOfWeek.Sunday, 0.OfType<DayOfWeek>());
			Assert.AreEqual(DayOfWeek.Monday, 1.ToString().OfType<DayOfWeek>());
			Assert.AreEqual(DayOfWeek.Wednesday, DayOfWeek.Wednesday.OfType<DayOfWeek>());
			Assert.AreEqual(DayOfWeek.Friday, DayOfWeek.Friday.ToString().OfType<DayOfWeek>());

			Assert.IsNull(((string)null).OfType<int?>());
			Assert.IsNull(((string)null).OfType<double?>());
			Assert.IsNull(((string)null).OfType<decimal?>());
			Assert.IsNull(((string)null).OfType<DateTime?>());
		}
	}
}