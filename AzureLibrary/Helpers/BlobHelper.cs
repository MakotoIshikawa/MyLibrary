using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using AzureLibrary.Extensions;
using AzureLibrary.Utility;
using CommonFeaturesLibrary;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureLibrary.Helpers {
	/// <summary>
	/// BLOB ストレージへのアクセスを補助するクラスです。
	/// </summary>
	public class BlobHelper {
		#region フィールド

		#endregion

		#region コンストラクタ

		/// <param name="connectionString">接続文字列</param>
		/// <param name="containerName">コンテナー名</param>
		/// <param name="blobName">BLOB 名</param>
		public BlobHelper(string connectionString, string containerName, string blobName) {
			this.ConnectionString = connectionString;
			this.ContainerName = containerName;
			this.BlobName = blobName;
		}

		#endregion

		#region プロパティ

		/// <summary>
		/// 接続文字列
		/// </summary>
		public string ConnectionString { get; set; }

		/// <summary>
		/// コンテナー名
		/// </summary>
		public string ContainerName { get; set; }

		/// <summary>
		/// BLOB 名
		/// </summary>
		public string BlobName { get; set; }

		#endregion

		#region メソッド

		#region ダウンロード

		/// <summary>
		/// ブロック BLOB からデータをダウンロードします。
		/// </summary>
		/// <returns>データテーブルを返します。</returns>
		public DataTable DownloadDataTable() {
			return this.Download(s => s.GetCsvTable(this.BlobName));
		}

		/// <summary>
		/// ブロック BLOB からデータをダウンロードします。
		/// </summary>
		/// <returns>データテーブルを返します。</returns>
		public async Task<DataTable> DownloadDataTableAsync() {
			return await DownloadAsync(s => s.GetCsvTableAsync(this.BlobName));
		}

		/// <summary>
		/// 接続文字列とコンテナー名、BLOB 名を指定して、
		/// ブロック BLOB からデータをダウンロードします。
		/// </summary>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="fetchData">データを抽出するメソッド</param>
		/// <returns>抽出したデータを返します。</returns>
		public TResult Download<TResult>(Func<MemoryStream, TResult> fetchData) {
			if (fetchData == null) {
				return default(TResult);
			}

			var blockBlob = this.GetBlockBlob();

			return blockBlob.Download(fetchData);
		}

		/// <summary>
		/// 接続文字列とコンテナー名、BLOB 名を指定して、
		/// ブロック BLOB からデータをダウンロードします。
		/// </summary>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="fetchData">データを抽出するメソッド</param>
		/// <returns>抽出したデータを返します。</returns>
		public async Task<TResult> DownloadAsync<TResult>(Func<MemoryStream, Task<TResult>> fetchData) {
			if (fetchData == null) {
				return default(TResult);
			}

			var blockBlob = this.GetBlockBlob();

			return await blockBlob.DownloadAsync(fetchData);
		}

		#endregion

		#region ログ

		#region ログ出力

		/// <summary>
		/// 追加 BLOB にタイムスタンプ付きの文字列を追加します。
		/// </summary>
		/// <param name="content">アップロードするテキストを含む文字列</param>
		public void OutputLog(string content) {
			var appendBlob = GetAppendBlob();
			appendBlob.AppendLine(content);
		}

		/// <summary>
		/// 追加 BLOB にタイムスタンプ付きの文字列を追加します。
		/// </summary>
		/// <param name="content">アップロードするテキストを含む文字列</param>
		/// <returns>Task を返します。(非同期)</returns>
		public async Task OutputLogAsync(string content) {
			var appendBlob = await GetAppendBlobAsync();
			await appendBlob.AppendLineAsync(content);
		}

		#endregion

		#region ログテキスト取得

		/// <summary>
		/// 指定した BLOB からテキストを取得します。
		/// </summary>
		/// <returns>BLOB から取得したテキストを返します。</returns>
		public string GetLogText() {
			var appendBlob = this.GetAppendBlob();
			return appendBlob.DownloadText();
		}

		/// <summary>
		/// 指定した BLOB からテキストを取得します。
		/// </summary>
		/// <returns>BLOB から取得したテキストを返します。</returns>
		public async Task<string> GetLogTextAsync() {
			var appendBlob = await this.GetAppendBlobAsync();
			return await appendBlob.DownloadTextAsync();
		}

		#endregion

		#endregion

		#region BLOB 取得

		#region ブロック BLOB

		/// <summary>
		/// ブロック BLOB を取得します。
		/// </summary>
		/// <returns>ブロック BLOB を返します。</returns>
		public CloudBlockBlob GetBlockBlob() {
			return AzureUtility.GetBlockBlob(this.ConnectionString, this.ContainerName, this.BlobName);
		}

		/// <summary>
		/// ブロック BLOB を取得します。
		/// </summary>
		/// <returns>ブロック BLOB を返します。</returns>
		public async Task<CloudBlockBlob> GetBlockBlobAsync() {
			return await AzureUtility.GetBlockBlobAsync(this.ConnectionString, this.ContainerName, this.BlobName);
		}

		#endregion

		#region 追加 BLOB

		/// <summary>
		/// 追加 BLOB を取得します。
		/// </summary>
		/// <returns>追加 BLOB を返します。</returns>
		public CloudAppendBlob GetAppendBlob() {
			return AzureUtility.GetAppendBlob(this.ConnectionString, this.ContainerName, this.BlobName);
		}

		/// <summary>
		/// 追加 BLOB を取得します。
		/// </summary>
		/// <returns>追加 BLOB を返します。</returns>
		public async Task<CloudAppendBlob> GetAppendBlobAsync() {
			return await AzureUtility.GetAppendBlobAsync(this.ConnectionString, this.ContainerName, this.BlobName);
		}

		#endregion

		#endregion

		#region コンテナー取得

		/// <summary>
		/// 接続文字列とコンテナー名を指定して、
		/// Blob コンテナーを取得します。
		/// </summary>
		/// <returns>Blob コンテナーを返します。</returns>
		public CloudBlobContainer GetContainer() {
			return AzureUtility.GetContainer(this.ConnectionString, this.ContainerName);
		}

		#endregion

		#endregion
	}
}
