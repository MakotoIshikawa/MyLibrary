using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary.Extensions;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestWindowsForms {
		#region メソッド

		[TestMethod]
		[Owner(nameof(WindowsFormsLibrary))]
		[TestCategory("変更")]
		public void テストその１() {
		}

		#endregion
	}
}
