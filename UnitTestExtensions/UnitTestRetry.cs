using System;
using System.IO;
using System.Linq;
using System.Text;
using CommonFeaturesLibrary.Extensions;
using ExtensionsLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetryLibrary;
using static System.Threading.Thread;

namespace UnitTestExtensions {
	[TestClass]
	public partial class UnitTestRetry {
		#region メソッド

		[TestMethod]
		[Owner(nameof(RetryLibrary))]
		[TestCategory("変更")]
		public void リトライ処理() {
			var re = new RetryExecutor(3, 1000, 2000, 100);
			re.Execute(()=> {
				Sleep(10000);
			});
		}

		#endregion
	}
}
