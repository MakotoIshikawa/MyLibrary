using System;

namespace ExtensionsLibraryTests.Models {
	public class TestNullableItem {
		public string Name { get; set; }
		public bool? BooleanOrNull { get; set; }
		public int? IntegerOrNull { get; set; }
		public double? DoubleOrNull { get; set; }
		public decimal? DecimalOrNull { get; set; }
		public DateTime? DateOrNull { get; set; }
		public DateTime? TimeOrNull { get; set; }
	}
}
