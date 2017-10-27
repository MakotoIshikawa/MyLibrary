using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommonFeaturesLibrary;
using ExtensionsLibrary.Extensions;
using ObjectAnalysisProject.Extensions;
using WindowsFormsLibrary.Extensions;
using WindowsFormsLibrary.Forms.Primitives;

namespace WindowsFormsLibrary.Forms.Primitives {
	/// <summary>
	/// ディレクトリ情報をインポートする基底フォーム抽象クラスです。
	/// </summary>
	public abstract partial class FormImportDirectoryBase : FormEditText {
		#region フィールド

		/// <summary>ログ出力</summary>
		private Logger _log = new Logger();

		#endregion

		#region コンストラクタ

		/// <summary>
		/// <see cref="FormImportDirectoryBase"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <remarks>継承クラスのみ呼び出すことができます。</remarks>
		protected FormImportDirectoryBase() : base() {
			this.InitializeComponent();
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// 表示ログ最大行数
		/// </summary>
		public int LogRowLimit { get; protected set; } = 500;

		/// <summary>
		/// 選択中の行コレクションを取得します。
		/// </summary>
		public IEnumerable<DataGridViewRow> SelectedRows
			=> this.gridDirectories.GetSelectedRows();

		/// <summary>
		/// 全ての行コレクションを取得します。
		/// </summary>
		public IEnumerable<DataGridViewRow> Rows
			=> this.gridDirectories.Rows.Cast<DataGridViewRow>();

		/// <summary>
		/// ディレクトリ、又はファイルのパスを取得します。
		/// </summary>
		public string Path {
			get => this.txtFilePath.Text;
			protected set => this.txtFilePath.Text = value;
		}

		#endregion

		#region イベントハンドラ

		/// <summary>
		/// [実行]ボタンのクリックイベントです。
		/// </summary>
		/// <param name="sender">送信元</param>
		/// <param name="e">イベントデータ</param>
		private void buttonRun_Click(object sender, EventArgs e)
			=> this.Run();

		/// <summary>
		/// [参照]ボタンのクリックイベントです。
		/// </summary>
		/// <param name="sender">送信元</param>
		/// <param name="e">イベントデータ</param>
		private void buttonReference_Click(object sender, EventArgs e) {
			var dialog = this.folderDialog;
			var result = dialog.ShowDialog();
			if (result == DialogResult.OK) {
				this.Path = dialog.SelectedPath;
			}
		}

		/// <summary>
		/// ダブルクリックイベント
		/// </summary>
		/// <param name="sender">送信元</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// ダブルクリックされたときに発生します。</remarks>
		private void listBoxMessage_DoubleClick(object sender, EventArgs e) {
			var dialogResult = MessageBox.Show("ログをクリアしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (dialogResult == DialogResult.Yes) {
				this.ClearMessage();
			}
		}

		/// <summary>
		/// [ファイルパス]テキストボックスの変更イベントです。
		/// </summary>
		/// <param name="sender">送信元</param>
		/// <param name="e">イベントデータ</param>
		private void textBoxFilePath_TextChanged(object sender, EventArgs e) {
			if (!(sender is TextBox textBox)) {
				return;
			}

			this.ShowDirectoryInfo(textBox.Text);
		}

		/// <summary>
		/// オブジェクトがコントロールの境界内にドラッグされると発生します。
		/// </summary>
		/// <param name="sender">送信元</param>
		/// <param name="e">イベントデータ</param>
		private void obj_DragEnter(object sender, DragEventArgs e) {
			try {
				if (!e.Data.GetDirectories().Any()) {
					throw new DirectoryNotFoundException();
				}
				e.Effect = DragDropEffects.Copy;
			} catch (Exception) {
			}
		}

		/// <summary>
		/// ドラッグ アンド ドロップ操作が完了したときに発生します。
		/// </summary>
		/// <param name="sender">送信元</param>
		/// <param name="e">イベントデータ</param>
		private void obj_DragDrop(object sender, DragEventArgs e) {
			var directories = e.Data.GetDirectories();
			this.txtFilePath.Text = directories.FirstOrDefault()?.FullName ?? string.Empty;
		}

		#endregion

		#region メソッド

		#region 実行処理

		/// <summary>
		/// 実行処理
		/// </summary>
		public virtual void Run() {
			try {
				base.Enabled = false;
				this.ValidationCheck();
				this.RunCore();
			} catch (ArgumentException ex) {
				this.WriteLineMessage(ex.Message);
			} catch (InvalidOperationException ex) {
				this.WriteLineMessage(ex.Message);
			} catch (ApplicationException ex) {
				this.WriteLineMessage(ex.Message);
			} catch (Exception ex) {
				this.WriteException(ex);
			} finally {
				base.Enabled = true;
			}
		}

		/// <summary>
		/// 実行処理の前に値をバリデーションチェックします。
		/// </summary>
		/// <remarks>
		/// ArgumentException, InvalidOperationException, ApplicationException 何れかの
		/// 例外をスローさせるように記述します。
		/// </remarks>
		protected virtual void ValidationCheck() {
		}

		/// <summary>
		/// 実行処理の中核です。オーバーライドできます。
		/// </summary>
		protected abstract void RunCore();

		#endregion

		#region DataSource 生成

		/// <summary>
		/// ディレクトリ情報から DataGridView に表示する DataSource を生成します。
		/// </summary>
		/// <param name="info">ディレクトリ情報</param>
		/// <returns>生成した DataSource を返します。</returns>
		protected virtual DataTable CreateDataSource(DirectoryInfo info) {
			var dataSource = (
				from d in info.EnumerateDirectories()
				let files = d.GetFileInfos(true)
				let cnt = files.Count()
				where files.Any()
				select new {
					Name = d.Name,
					FullName = d.FullName,
					FileCount = cnt
				}
			).ToDataTable();

			return dataSource;
		}

		#endregion

		#region 一覧表示

		/// <summary>
		/// ディレクトリ情報を表示します。
		/// </summary>
		public void ShowDirectoryInfo()
			=> this.ShowDirectoryInfo(this.txtFilePath.Text);

		/// <summary>
		/// ディレクトリのパスを指定して、
		/// ディレクトリ情報を表示します。
		/// </summary>
		/// <param name="path">ディレクトリパス</param>
		protected virtual void ShowDirectoryInfo(string path) {
			try {
				var directoryInfo = new DirectoryInfo(path);
				this.btnRun.Enabled = directoryInfo.Exists;

				if (directoryInfo.Exists) {
					var dataSource = this.CreateDataSource(directoryInfo);
					this.gridDirectories.DataSource = dataSource;
					this.btnRun.Enabled = dataSource.AnyRows();
				}
			} catch (Exception ex) {
				this.btnRun.Enabled = false;
				this.gridDirectories.DataSource = null;
				this.WriteLineMessage(ex.Message);
			}
		}

		#endregion

		#region メッセージ欄

		/// <summary>
		/// メッセージ欄に書込をします。
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <remarks>
		/// ユーザインターフェイスにメッセージを書き込む
		/// </remarks>
		protected virtual void WriteLineMessage(string message) {
			try {
				if (message.IsEmpty()) {
					return;
				}

				var timeLog = message.GetTimeLog();
				this.listMessage.AddMessage(timeLog, this.LogRowLimit);
				this._log.WriteLog(message);
				if (this.notifyIcon.Visible) {
					this.notifyIcon.ShowBalloonTip(500, "情報", message, ToolTipIcon.Info);
				}
			} catch (Exception ex) {
				this.WriteException(ex);
			}
		}

		/// <summary>
		/// 例外をログに残します。
		/// </summary>
		/// <param name="ex">例外</param>
		protected virtual void WriteException(Exception ex) {
			try {
				this._log.WriteLog(ex.ToString());
			} finally {
				this.ShowMessageBox($"{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			}
		}

		/// <summary>
		/// メッセージ欄をクリアします。
		/// </summary>
		public void ClearMessage()
			=> this.listMessage.Items.Clear();

		#endregion

		#endregion
	}
}
