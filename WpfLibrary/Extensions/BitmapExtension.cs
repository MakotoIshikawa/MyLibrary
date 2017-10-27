using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace WpfLibrary.Extensions {
	/// <summary>
	/// Bitmap を拡張するメソッドを提供するクラスです。
	/// </summary>
	public static partial class BitmapExtension {
		#region メソッド

		/// <summary>
		/// イメージの形式を指定して、
		/// イメージデータを取得します。
		/// </summary>
		/// <param name="this">Bitmap</param>
		/// <param name="format">保存するイメージの形式を指定する ImageFormat。</param>
		/// <returns>イメージデータを返します。</returns>
		public static BitmapFrame GetImageSource(this Bitmap @this, ImageFormat format) {
			var stream = new MemoryStream();
			@this.Save(stream, format);

			var decoder = new PngBitmapDecoder(stream, BitmapCreateOptions.None, BitmapCacheOption.Default);
			return decoder.Frames.FirstOrDefault();
		}

		#endregion
	}
}
