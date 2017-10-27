using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelLibrary.Extensions;
using ExcelLibrary.Primitives;
using OfficeOpenXml;

namespace ExcelLibrary {
	/// <summary>
	/// Excel 管理クラス
	/// </summary>
	public class ExcelManager : ExcelManagerBase {
		#region フィールド

		private string _sheetName;
		private int _position;

		#endregion

		#region コンストラクタ

		/// <summary>
		/// ファイルパスを指定して、
		/// 新しいオブジェクトのインスタンスを生成します。
		/// </summary>
		/// <param name="path">ファイルパス</param>
		public ExcelManager(string path) : this(path, 1) {
		}

		/// <summary>
		/// ファイルパスとシート名を指定して、
		/// 新しいオブジェクトのインスタンスを生成します。
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <param name="sheetName">参照するシート名</param>
		public ExcelManager(string path, string sheetName) : base(path) {
			if (!this.File.Exists) {
				this.AddSheet(sheetName);
			}

			this.SheetName = sheetName;
		}

		/// <summary>
		/// ファイルパスとシート番号を指定して、
		/// 新しいオブジェクトのインスタンスを生成します。
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <param name="position">参照するシート番号</param>
		public ExcelManager(string path, int position) : base(path) {
			if (!this.File.Exists) {
				this.AddSheet();
				this.Position = 1;
				return;
			}

			this.Position = position;
		}

		/// <summary>
		/// テンプレートファイルを指定して、
		/// 新しいオブジェクトのインスタンスを生成します。
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <param name="template">テンプレートファイル情報</param>
		public ExcelManager(string path, FileInfo template) : base(new FileInfo(path), template) {
			this.Position = 1;
		}

		#endregion

		#region インデクサー

		/// <summary>
		/// セルの文字列を取得します。
		/// </summary>
		/// <param name="Address">セルの位置を表す文字列</param>
		/// <returns>セルの文字列を返します。</returns>
		public string this[string Address] => this.FetchValueFromSheet(sheet => {
			using (var cell = sheet.Cells[Address]) {
				return cell?.Value?.ToString();
			}
		});

		/// <summary>
		/// 行、列を指定して
		/// セルの文字列を取得します。
		/// </summary>
		/// <param name="Row">行</param>
		/// <param name="Col">列</param>
		/// <returns>セルの文字列を返します。</returns>
		public string this[int Row, int Col] => this.FetchValueFromSheet(sheet => {
			using (var cell = sheet.Cells[Row, Col]) {
				return cell?.Value?.ToString();
			}
		});

		#endregion

		#region プロパティ

		/// <summary>
		/// 現在参照中のシート名を取得、設定します。
		/// </summary>
		public string SheetName {
			get => this._sheetName;
			set {
				try {
					this.ReferSheet(value, sheet => this._position = sheet.Index);
					this._sheetName = value;
				} catch (NullReferenceException ex) {
					throw new ArgumentException($"指定された名前のシートは存在しません。:{value}", nameof(value), ex);
				}
			}
		}

		/// <summary>
		/// 現在参照中のシート番号を取得、設定します。
		/// </summary>
		public int Position {
			get => this._position;
			set {
				try {
					this.ReferSheet(value, sheet => this._sheetName = sheet.Name);
					this._position = value;
				} catch (IndexOutOfRangeException ex) {
					throw value < 1
						? new ArgumentException($"シート番号は 1 以上の値をしてしてください。:{value}", nameof(value), ex)
						: new ArgumentException($"指定された番号のシートは存在しません。:{value}", nameof(value), ex);
				}
			}
		}

		/// <summary>
		/// シート数を取得します。
		/// </summary>
		public int SheetCount => this.Fetch(x => x.Workbook.Worksheets.Count);

		/// <summary>
		/// シート名のリストを取得します。
		/// </summary>
		public List<string> SheetNames => this.Fetch(x => x.Workbook.Worksheets.Select(sheet => sheet.Name).ToList());

		#endregion

		#region メソッド

		#region AddSheet

		/// <summary>
		/// ワークシートを追加します。
		/// </summary>
		/// <returns>追加したワークシートのシート番号と名前を返します。</returns>
		public Tuple<int, string> AddSheet() => this.Fetch(x => {
			try {
				var sheet = x.Workbook.Add();
				x.Save();

				return Tuple.Create(sheet.Index, sheet.Name);
			} catch (InvalidOperationException ex) {
				throw new InvalidOperationException($"同名のワークシートが既に存在します。", ex);
			}
		});

		/// <summary>
		/// シート名を指定して、
		/// ワークシートを追加します。
		/// </summary>
		/// <param name="name">シート名</param>
		/// <returns>追加したワークシートのシート番号と名前を返します。</returns>
		public Tuple<int, string> AddSheet(string name) => this.Fetch(x => {
			try {
				var sheet = x.Workbook.Add(name);
				x.Save();

				return Tuple.Create(sheet.Index, sheet.Name);
			} catch (InvalidOperationException ex) {
				throw new ArgumentException($"この名前のワークシートは既に存在します。{nameof(name)}={name}", nameof(name), ex);
			}
		});

		#endregion

		#region ReferSheet

		/// <summary>
		/// シートの内容を参照します。
		/// </summary>
		/// <param name="reference">参照するメソッド</param>
		public void ReferSheet(Action<ExcelWorksheet> reference)
			=> this.ReferSheet(this.Position, reference);

		/// <summary>
		/// シートの内容を参照します。
		/// </summary>
		/// <param name="sheetName">シート名</param>
		/// <param name="reference">参照するメソッド</param>
		public void ReferSheet(string sheetName, Action<ExcelWorksheet> reference)
			=> base.Refer(x => reference?.Invoke(x.Workbook.Worksheets[sheetName]));

		/// <summary>
		/// シートの内容を参照します。
		/// </summary>
		/// <param name="position">シート番号</param>
		/// <param name="reference">参照するメソッド</param>
		public void ReferSheet(int position, Action<ExcelWorksheet> reference)
			=> base.Refer(x => reference?.Invoke(x.Workbook.Worksheets[position]));

		#endregion

		#region FetchDataFromSheet

		/// <summary>
		/// ワークシートから値を取り出します。
		/// </summary>
		/// <typeparam name="TResult">取り出す値の型</typeparam>
		/// <param name="fetch">値を取り出すメソッド</param>
		/// <returns>抽出した値を返します。</returns>
		public TResult FetchValueFromSheet<TResult>(Func<ExcelWorksheet, TResult> fetch)
			=> this.FetchValueFromSheet(this.Position, fetch);

		/// <summary>
		/// ワークシートから値を取り出します。
		/// </summary>
		/// <typeparam name="TResult">取り出す値の型</typeparam>
		/// <param name="sheetName">シート名</param>
		/// <param name="fetch">値を取り出すメソッド</param>
		/// <returns>抽出した値を返します。</returns>
		public TResult FetchValueFromSheet<TResult>(string sheetName, Func<ExcelWorksheet, TResult> fetch)
			=> base.Fetch(x => fetch(x.Workbook.Worksheets[sheetName]));

		/// <summary>
		/// ワークシートから値を取り出します。
		/// </summary>
		/// <typeparam name="TResult">取り出す値の型</typeparam>
		/// <param name="position">シート番号</param>
		/// <param name="fetch">値を取り出すメソッド</param>
		/// <returns>抽出した値を返します。</returns>
		public TResult FetchValueFromSheet<TResult>(int position, Func<ExcelWorksheet, TResult> fetch)
			=> base.Fetch(x => fetch(x.Workbook.Worksheets[position]));

		#endregion

		#region UpdateSheet

		/// <summary>
		/// シートの内容を更新します。
		/// </summary>
		/// <param name="update">更新するメソッド</param>
		public void UpdateSheet(Action<ExcelWorksheet> update)
		=> this.UpdateSheet(this.Position, update);

		/// <summary>
		/// シートの内容を更新します。
		/// </summary>
		/// <param name="sheetName">シート名</param>
		/// <param name="update">更新するメソッド</param>
		public void UpdateSheet(string sheetName, Action<ExcelWorksheet> update) => base.Refer(x => {
			update?.Invoke(x.Workbook.Worksheets[sheetName]);
			if (update != null) {
				x.Save();
			}
		});

		/// <summary>
		/// シートの内容を更新します。
		/// </summary>
		/// <param name="position">シート番号</param>
		/// <param name="update">更新するメソッド</param>
		public void UpdateSheet(int position, Action<ExcelWorksheet> update) => base.Refer(x => {
			update?.Invoke(x.Workbook.Worksheets[position]);
			if (update != null) {
				x.Save();
			}
		});

		#endregion

		#endregion
	}
}
