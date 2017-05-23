using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary.Extensions;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestNet {
		#region メソッド

		[TestMethod]
		[Owner(nameof(NetLibrary))]
		[TestCategory("変更")]
		public void テストその１() {
		}

		#endregion
	}
}
