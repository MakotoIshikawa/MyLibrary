using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ExtensionsLibrary.Extensions;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureLibrary.Extensions {
	/// <summary>
	/// CloudBlob を拡張するメソッドを提供します。
	/// </summary>
	public static class CloudBlobExtension {
		#region メソッド

		#region ダウンロード

		/// <summary>
		/// ブロック BLOB からデータをダウンロードします。
		/// </summary>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="this">ブロック BLOB</param>
		/// <param name="fetchData">データを抽出するメソッド</param>
		/// <returns>抽出したデータを返します。</returns>
		public static TResult Download<TResult>(this CloudBlockBlob @this, Func<MemoryStream, TResult> fetchData) {
			using (var stream = new MemoryStream()) {
				@this.DownloadToStream(stream);
				stream.Position = 0;
				return fetchData(stream);
			}
		}

		/// <summary>
		/// ブロック BLOB からデータをダウンロードします。
		/// </summary>
		/// <typeparam name="TResult">戻り値の型</typeparam>
		/// <param name="this">ブロック BLOB</param>
		/// <param name="fetchData">データを抽出するメソッド</param>
		/// <returns>抽出したデータを返します。</returns>
		public static async Task<TResult> DownloadAsync<TResult>(this CloudBlockBlob @this, Func<MemoryStream, Task<TResult>> fetchData) {
			using (var stream = new MemoryStream()) {
				await @this.DownloadToStreamAsync(stream);
				stream.Position = 0;
				return await fetchData(stream);
			}
		}

		#endregion

		#region 文字列追加

		/// <summary>
		/// 追加 BLOB にタイムスタンプ付きの文字列を追加します。
		/// </summary>
		/// <param name="this">追加 BLOB</param>
		/// <param name="content">アップロードするテキストを含む文字列</param>
		public static void AppendLine(this CloudAppendBlob @this, string content) {
			var sb = new StringBuilder();
			sb.AppendLine(content.GetTimeLog());

			@this.AppendText(sb.ToString());
		}

		/// <summary>
		/// 追加 BLOB にタイムスタンプ付きの文字列を追加します。(非同期)
		/// </summary>
		/// <param name="this">追加 BLOB</param>
		/// <param name="content">アップロードするテキストを含む文字列</param>
		/// <returns>Task を返します。(非同期)</returns>
		public static async Task AppendLineAsync(this CloudAppendBlob @this, string content) {
			var sb = new StringBuilder();
			sb.AppendLine(content.GetTimeLog());

			await @this.AppendTextAsync(sb.ToString());
		}

		#endregion

		#endregion
	}
}
