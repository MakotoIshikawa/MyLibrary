using System;
using System.IO;
using OfficeOpenXml;

namespace OfficeLibrary {
	/// <summary>
	/// Excel 管理クラス
	/// </summary>
	public class ExcelManager {
		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="path">ファイルパス</param>
		public ExcelManager(string path)
			: this(new FileInfo(path)) {
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="file">ファイル情報</param>
		public ExcelManager(FileInfo file) {
			this.File = file;
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// ファイル情報
		/// </summary>
		public FileInfo File { get; protected set; }

		#endregion

		#region メソッド

		/// <summary>
		/// Excelのデータを参照するメソッドです。
		/// </summary>
		/// <param name="refer">参照したデータを加工するメソッド</param>
		public virtual void Refer(Action<ExcelPackage> refer) {
			using (var xlsx = new ExcelPackage(this.File)) {
				refer?.Invoke(xlsx);
			}
		}

		/// <summary>
		/// Excelのデータから値を取り出すメソッドです。
		/// </summary>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="fetch">値を取り出すメソッド</param>
		/// <returns>取り出した値を返します。</returns>
		public virtual TResult Fetch<TResult>(Func<ExcelPackage, TResult> fetch) {
			if (fetch == null) {
				return default(TResult);
			}

			var file = this.File;
			using (var xlsx = new ExcelPackage(this.File)) {
				return fetch(xlsx);
			}
		}

		#endregion
	}
}
