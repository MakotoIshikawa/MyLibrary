using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureLibrary.Utility {
	/// <summary>
	/// Azure の共通処理を提供するクラスです。
	/// </summary>
	public static partial class AzureUtility {
		#region フィールド

		//private static string _connectionString = "DefaultEndpointsProtocol=https;AccountName=aisrsstorage;AccountKey=NBRW1pwJwovSZ4u9uHpG4z/zynCrskamHGkfOQvFsXehw6H8y/HcQHNaa1OHyo4j/CRt9D+aAK6w2cOK7fr6nA==";
		//private static string _containerName = "luisqa";

		#endregion

		#region メソッド

		#region BLOB 取得

		#region ブロック BLOB

		/// <summary>
		/// ブロック BLOB を取得します。
		/// </summary>
		/// <param name="connectionString">接続文字列</param>
		/// <param name="containerName">コンテナー名</param>
		/// <param name="blobName">BLOB 名</param>
		/// <returns>ブロック BLOB を返します。</returns>
		public static CloudBlockBlob GetBlockBlob(string connectionString, string containerName, string blobName) {
			return GetBlob(connectionString, containerName, (c) => c.GetBlockBlobReference(blobName));
		}

		/// <summary>
		/// ブロック BLOB を取得します。
		/// </summary>
		/// <param name="connectionString">接続文字列</param>
		/// <param name="containerName">コンテナー名</param>
		/// <param name="blobName">BLOB 名</param>
		/// <returns>ブロック BLOB を返します。</returns>
		public static async Task<CloudBlockBlob> GetBlockBlobAsync(string connectionString, string containerName, string blobName) {
			return await GetBlobAsync(connectionString, containerName,
				async (c) => await Task.Run(() => c.GetBlockBlobReference(blobName)));
		}

		#endregion

		#region 追加 BLOB

		/// <summary>
		/// 追加 BLOB を取得します。
		/// </summary>
		/// <param name="connectionString">接続文字列</param>
		/// <param name="containerName">コンテナー名</param>
		/// <param name="blobName">BLOB 名</param>
		/// <returns>追加 BLOB を返します。</returns>
		public static CloudAppendBlob GetAppendBlob(string connectionString, string containerName, string blobName) {
			return GetBlob(connectionString, containerName, (c) => {
				var blob = c.GetAppendBlobReference(blobName);
				if (!blob.Exists()) {
					blob.CreateOrReplace();
				}

				return blob;
			});
		}

		/// <summary>
		/// 追加 BLOB を取得します。
		/// </summary>
		/// <param name="connectionString">接続文字列</param>
		/// <param name="containerName">コンテナー名</param>
		/// <param name="blobName">BLOB 名</param>
		/// <returns>追加 BLOB を返します。</returns>
		public static async Task<CloudAppendBlob> GetAppendBlobAsync(string connectionString, string containerName, string blobName) {
			return await GetBlobAsync(connectionString, containerName, async (c) => {
				var blob = c.GetAppendBlobReference(blobName);
				if (!blob.Exists()) {
					await blob.CreateOrReplaceAsync();
				}

				return blob;
			});
		}

		#endregion

		#region BLOB 取得

		private static TCloudBlob GetBlob<TCloudBlob>(string connectionString, string containerName, Func<CloudBlobContainer, TCloudBlob> func)
			where TCloudBlob : CloudBlob {
			var container = GetContainer(connectionString, containerName);
			container.CreateIfNotExists();

			var blob = func?.Invoke(container);

			return blob;
		}

		private static async Task<TCloudBlob> GetBlobAsync<TCloudBlob>(string connectionString, string containerName, Func<CloudBlobContainer, Task<TCloudBlob>> func)
			where TCloudBlob : CloudBlob {
			var container = GetContainer(connectionString, containerName);
			await container.CreateIfNotExistsAsync();

			var blob = await func?.Invoke(container);

			return blob;
		}

		#endregion

		#endregion

		#region コンテナー取得

		/// <summary>
		/// 接続文字列とコンテナー名を指定して、
		/// Blob コンテナーを取得します。
		/// </summary>
		/// <param name="connectionString">接続文字列</param>
		/// <param name="containerName">コンテナー名</param>
		/// <returns>Blob コンテナーを返します。</returns>
		public static CloudBlobContainer GetContainer(string connectionString, string containerName) {
			var storageAccount = CloudStorageAccount.Parse(connectionString);
			var blobClient = storageAccount.CreateCloudBlobClient();
			var container = blobClient.GetContainerReference(containerName.ToLower());
			return container;
		}

		#endregion

		#endregion
	}
}