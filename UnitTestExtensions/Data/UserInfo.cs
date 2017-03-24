using System;
using System.Diagnostics;

namespace UnitTestExtensions.Data {
	/// <summary>
	/// ユーザー情報(テスト用)
	/// </summary>
	[DebuggerDisplay("姓名={姓名}, 生年月日={生年月日}, 住所={住所}")]
	public class UserInfo {
		#region プロパティ

		public string 姓 { get; set; }
		public string 名 { get; set; }
		public string 姓名 => this.姓 + this.名;
		public DateTime 生年月日 { get; set; }
		public string 住所 { get; set; }

		#endregion

		#region メソッド

		#region オーバーライド

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}

			var p = obj as UserInfo;

			return this.Equals(p);
		}

		public bool Equals(UserInfo p) {
			if (p == null) {
				return false;
			}

			return (this.姓名 == p.姓名)
				&& (this.生年月日 == p.生年月日)
				&& (this.住所 == p.住所);
		}

		public override int GetHashCode() {
			return this.姓名.GetHashCode()
				^ this.生年月日.GetHashCode()
				^ this.住所.GetHashCode();
		}

		#endregion

		#endregion
	}
}
