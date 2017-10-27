using System.IO;
using OfficeLibrary.Providers.Primitive;

namespace OfficeLibrary.Providers.Access {
	/// <summary>
	/// Access ファイル用のデータベースの Connection を提供するクラスです。
	/// </summary>
	public class AccessConnection : FileConnectionBase {
		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		public AccessConnection(string fileName) : base(fileName) {
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="file">ファイル</param>
		public AccessConnection(FileInfo file) : base(file) {
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// 接続文字列を取得します。(オーバーライド)
		/// </summary>
		public override string ConnectionString
			=> this.File.GetConnectionStringByAccess(this.Imex);

		/// <summary>
		/// テーブル名
		/// </summary>
		public string TableName { get; set; } = null;

		#endregion

		#region メソッド

		/// <summary>
		/// SELECT 文を取得します。(オーバーライド)
		/// </summary>
		/// <param name="selects">Select 句</param>
		/// <returns>SELECT 文を返します。</returns>
		public override string GetSelectCommandText(params string[] selects)
			=> this.File.GetSelectCommandTextOfAccess(this.TableName, selects);

		#endregion
	}
}
