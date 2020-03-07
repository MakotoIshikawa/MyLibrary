using System.Windows.Forms;

namespace WindowsFormsLibrary.Forms.Primitives {
	public abstract partial class FormImportDirectoryBase {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.btnRun = new System.Windows.Forms.Button();
			this.txtFilePath = new System.Windows.Forms.TextBox();
			this.btnReference = new System.Windows.Forms.Button();
			this.gridDirectories = new System.Windows.Forms.DataGridView();
			this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.listMessage = new System.Windows.Forms.ListBox();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gridDirectories)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonRun
			// 
			this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRun.Enabled = false;
			this.btnRun.Location = new System.Drawing.Point(477, 407);
			this.btnRun.Name = "buttonRun";
			this.btnRun.Size = new System.Drawing.Size(75, 23);
			this.btnRun.TabIndex = 0;
			this.btnRun.Text = "実行";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.buttonRun_Click);
			// 
			// textBoxFilePath
			// 
			this.txtFilePath.AllowDrop = true;
			this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilePath.Location = new System.Drawing.Point(14, 12);
			this.txtFilePath.Name = "textBoxFilePath";
			this.txtFilePath.Size = new System.Drawing.Size(493, 19);
			this.txtFilePath.TabIndex = 1;
			this.txtFilePath.TextChanged += new System.EventHandler(this.textBoxFilePath_TextChanged);
			this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.obj_DragDrop);
			this.txtFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.obj_DragEnter);
			// 
			// buttonReference
			// 
			this.btnReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReference.AutoSize = true;
			this.btnReference.Location = new System.Drawing.Point(513, 10);
			this.btnReference.Name = "buttonReference";
			this.btnReference.Size = new System.Drawing.Size(39, 23);
			this.btnReference.TabIndex = 2;
			this.btnReference.Text = "参照";
			this.btnReference.UseVisualStyleBackColor = true;
			this.btnReference.Click += new System.EventHandler(this.buttonReference_Click);
			// 
			// gridDirectories
			// 
			this.gridDirectories.AllowUserToAddRows = false;
			this.gridDirectories.AllowUserToDeleteRows = false;
			this.gridDirectories.AllowUserToOrderColumns = true;
			this.gridDirectories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridDirectories.Location = new System.Drawing.Point(0, 0);
			this.gridDirectories.Name = "gridDirectories";
			this.gridDirectories.ReadOnly = true;
			this.gridDirectories.RowTemplate.Height = 21;
			this.gridDirectories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridDirectories.Size = new System.Drawing.Size(540, 181);
			this.gridDirectories.TabIndex = 11;
			// 
			// folderBrowserDialog
			// 
			this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.folderDialog.SelectedPath = "C:\\work\\AttachmentFiles";
			this.folderDialog.ShowNewFolderButton = false;
			// 
			// splitContainer1
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(12, 39);
			this.splitContainer.Name = "splitContainer1";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.gridDirectories);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.listMessage);
			this.splitContainer.Size = new System.Drawing.Size(540, 362);
			this.splitContainer.SplitterDistance = 181;
			this.splitContainer.TabIndex = 14;
			// 
			// listBoxMessage
			// 
			this.listMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMessage.FormattingEnabled = true;
			this.listMessage.ItemHeight = 12;
			this.listMessage.Location = new System.Drawing.Point(0, 0);
			this.listMessage.Name = "listBoxMessage";
			this.listMessage.Size = new System.Drawing.Size(540, 177);
			this.listMessage.TabIndex = 22;
			this.listMessage.DoubleClick += new System.EventHandler(this.listBoxMessage_DoubleClick);
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.Text = "通知";
			// 
			// FormImport
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 442);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.btnReference);
			this.Controls.Add(this.txtFilePath);
			this.Controls.Add(this.btnRun);
			this.Name = "FormImport";
			this.Text = "ディレクトリ管理";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.obj_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.obj_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.gridDirectories)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		/// <summary />
		protected Button btnRun;
		/// <summary />
		protected TextBox txtFilePath;
		/// <summary />
		protected Button btnReference;
		/// <summary />
		protected DataGridView gridDirectories;
		/// <summary />
		protected FolderBrowserDialog folderDialog;
		/// <summary />
		protected SplitContainer splitContainer;
		/// <summary />
		protected ListBox listMessage;
		/// <summary />
		protected NotifyIcon notifyIcon;
	}
}

