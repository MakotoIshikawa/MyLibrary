using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionsLibrary.Extensions;

namespace CommonFeaturesLibrary {
	/// <summary>
	/// CSV形式のストリームを読み込む CsvReader を実装します。
	/// </summary>
	public class CsvReader : IDisposable {
		#region フィールド

		/// <summary>
		/// CSVを読み込むストリーム
		/// </summary>
		private StreamReader _reader = null;

		/// <summary>
		/// 現在読み込んでいるフィールドがダブルクォートで囲まれたフィールドかどうか
		/// </summary>
		private bool _isQuotedField = false;

		#endregion

		#region コンストラクタ

		/// <summary>
		/// 文字列データを指定して、
		/// <see cref="CsvReader">CsvReader</see> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="data">文字列データ。</param>
		public CsvReader(StringBuilder data)
			: this(new MemoryStream(Encoding.Unicode.GetBytes(data.ToString()))) {
		}

		/// <summary>
		/// ストリームを指定して、
		/// <see cref="CsvReader">CsvReader</see> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="stream">読み込まれるストリーム。</param>
		public CsvReader(Stream stream)
			: this(new StreamReader(stream)) {
		}

		/// <summary>
		/// ファイル情報を指定して、
		/// <see cref="CsvReader">CsvReader</see> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="file">読み込まれる完全なファイルパス。</param>
		public CsvReader(FileInfo file) :
			this(new StreamReader(file.FullName)) {
		}

		/// <summary>
		/// ファイル名、文字エンコーディングを指定して、
		/// <see cref="CsvReader">CsvReader</see> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="path">読み込まれる完全なファイルパス。</param>
		/// <param name="encoding">使用する文字エンコーディング。</param>
		public CsvReader(string path, Encoding encoding)
			: this(new StreamReader(path, encoding)) {
		}

		/// <summary>
		/// StreamReader を指定して、
		/// <see cref="CsvReader">CsvReader</see> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="reader">StreamReader</param>
		protected CsvReader(StreamReader reader) {
			this._reader = reader;
		}

		#endregion

		#region メソッド

		#region 読込

		/// <summary>
		/// すべての文字の現在位置から末尾までを読み込みます。
		/// </summary>
		/// <returns>
		/// ストリームの現在位置から末尾までのストリームの残り部分。
		/// 現在の位置がストリームの末尾である場合は、空の配列が返されます。
		/// </returns>
		public IEnumerable<List<string>> ReadToEnd() {
			List<string> record;
			while ((record = this.ReadRow()) != null) {
				yield return record;
			}
		}

		/// <summary>
		/// すべての文字の現在位置から末尾までを非同期的に読み込みます。
		/// </summary>
		/// <returns>
		/// ストリームの現在位置から末尾までのストリームの残り部分。
		/// 現在の位置がストリームの末尾である場合は、空の配列が返されます。
		/// </returns>
		public Task<List<List<string>>> ReadToEndAsync()
			=> Task.Run(() => this.ReadToEnd().ToList());

		/// <summary>
		/// 現在のストリームから 1 レコード分の文字を読み取り、そのデータを文字配列として返します。
		/// </summary>
		/// <returns>入力ストリームからの次のレコード。入力ストリームの末尾に到達した場合は null。</returns>
		public List<string> ReadRow() {
			var file = this._reader;
			var line = string.Empty;
			var record = new List<string>();
			var field = new StringBuilder();

			while ((line = file.ReadLine()) != null) {
				for (var i = 0; i < line.Length; i++) {
					var item = line[i];

					if (item == ',' && !this._isQuotedField) {
						record.Add(field.ToString());
						field.Clear();
					} else if (item == '"') {
						if (!this._isQuotedField) {
							if (field.Length == 0) {
								this._isQuotedField = true;
								continue;
							}
						} else {
							if (i + 1 >= line.Length) {
								this._isQuotedField = false;
								continue;
							}
						}

						var peek = line[i + 1];

						if (peek == '"') {
							field.Append('"');
							i += 1;
						} else if (peek == ',' && this._isQuotedField) {
							this._isQuotedField = false;
							i += 1;
							record.Add(field.ToString());
							field.Clear();
						}
					} else {
						field.Append(item);
					}
				}

				if (this._isQuotedField) {
					field.Append(Environment.NewLine);
				} else {
					record.Add(field.ToString());

					return record;
				}
			}

			return null;
		}

		/// <summary>
		/// 現在のストリームから非同期的に 1 レコード分の文字を読み取り、そのデータを文字配列として返します。
		/// </summary>
		/// <returns>入力ストリームからの次のレコード。入力ストリームの末尾に到達した場合は null。</returns>
		public Task<List<string>> ReadRowAsync()
			=> Task.Run(() => this.ReadRow());

		#endregion

		#region テーブル変換

		/// <summary>
		/// CSVファイルのデータをデータテーブルに変換します。
		/// </summary>
		/// <param name="tableName">テーブル名</param>
		/// <returns>データテーブルを返します。</returns>
		public DataTable ToDataTable(string tableName) {
			var rows = this.ReadToEnd().ToList();
			var tbl = rows.ToDataTable(tableName);
			return tbl;
		}

		/// <summary>
		/// CSVファイルのデータをデータテーブルに変換します。
		/// </summary>
		/// <param name="tableName">テーブル名</param>
		/// <returns>データテーブルを返します。</returns>
		public async Task<DataTable> ToDataTableAsync(string tableName) {
			var rows = await this.ReadToEndAsync();
			var tbl = await Task.Run(() => rows.ToDataTable(tableName));
			return tbl;
		}

		#endregion

		/// <summary>
		/// CsvReader オブジェクトと、その基になるストリームを閉じ、
		/// リーダーに関連付けられたすべてのシステムリソースを解放します。
		/// </summary>
		public void Close()
			=> this._reader?.Close();

		#region IDisposable

		/// <summary>
		/// この CsvReader オブジェクトによって使用されているすべてのリソースを解放します。
		/// </summary>
		public void Dispose() {
			if (this._reader == null) {
				return;
			}

			this.Close();
			this._reader.Dispose();
			this._reader = null;
		}

		#endregion

		#endregion
	}
}