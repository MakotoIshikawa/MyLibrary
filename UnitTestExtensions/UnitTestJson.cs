using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary.Extensions;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonLibrary.Extensions;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestJson {
		#region メソッド

		[TestMethod]
		[Owner(nameof(JsonLibrary))]
		[TestCategory("変換")]
		public void JSON変換() {
			var tim = new {
				Start = DateTime.Today,
				End = DateTime.Now,
			};
			{
				var json = tim.ToJson();

				Assert.IsFalse(json.IsEmpty());
			}
		}

		#endregion
	}
}
