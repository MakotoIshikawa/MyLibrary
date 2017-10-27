using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Dictionary を拡張するメソッドを提供します。
	/// </summary>
	public static class DictionaryExtension {
		#region メソッド

		#region GetValueOrDefault

		/// <summary>
		/// 値を取得します。存在しないKeyの場合は default 値を返します。
		/// </summary>
		/// <param name="this">マップ</param>
		/// <param name="key">キー</param>
		/// <returns>値を返します。</returns>
		public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key)
			=> @this.GetValueOrDefault(key, default(TValue));

		/// <summary>
		/// 値を取得します。存在しないKeyの場合は default 値を返します。
		/// </summary>
		/// <param name="this">マップ</param>
		/// <param name="key">キー</param>
		/// <param name="defaultValue">default 値</param>
		/// <returns>値を返します。</returns>
		public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue defaultValue)
			=> @this.ContainsKey(key) ? @this[key] : defaultValue;

		#endregion

		/// <summary>
		/// キーと値を入れ替えたディクショナリーを生成します。
		/// </summary>
		/// <param name="this">IDictionary インターフェイスを実装したクラス</param>
		/// <returns>キーと値を入れ替えたディクショナリーを返します。</returns>
		public static Dictionary<TValue, TKey> Swap<TKey, TValue>(this IDictionary<TKey, TValue> @this)
			=> @this.ToDictionary(kv => kv.Value, kv => kv.Key);

		#endregion
	}
}