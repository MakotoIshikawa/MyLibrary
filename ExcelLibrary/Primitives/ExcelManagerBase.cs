using System;
using System.IO;
using OfficeOpenXml;

namespace ExcelLibrary.Primitives {
	/// <summary>
	/// Excel を管理するための抽象クラスです。
	/// </summary>
	public abstract class ExcelManagerBase {
		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="path">ファイルパス</param>
		protected ExcelManagerBase(string path) : this(new FileInfo(path)) {
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="file">ファイル情報</param>
		protected ExcelManagerBase(FileInfo file) {
			this.File = file;

			if (!file.Directory.Exists) {
				file.Directory.Create();
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="newFile">ファイル情報</param>
		/// <param name="template">テンプレートファイル情報</param>
		protected ExcelManagerBase(FileInfo newFile, FileInfo template) : this(newFile) {
#if true
			using (var xlsx = new ExcelPackage(newFile, template)) {
				xlsx.Save();
			}
#else
			using (var xlsx = new ExcelPackage(template, true)) {
				xlsx.SaveAs(newFile);
			}
#endif
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
