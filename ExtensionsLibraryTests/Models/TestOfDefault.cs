using System.Reflection;

namespace ExtensionsLibraryTests.Models {
	/// <summary>
	/// 既定メンバーを指定したテストクラス。
	/// </summary>
	[DefaultMember(nameof(Age))]
	public class TestOfDefault {
		/// <summary>
		/// 年齢
		/// </summary>
		public int Age
			=> 42;
	}
}
