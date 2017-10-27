namespace SharePointLibrary.Enums {
	/// <summary>
	/// OnError の種類
	/// </summary>
	public enum OnErrorTyps {
		/// <summary>
		/// 最初のエラーが発生した後、以降のメソッドの実行を中止します。これが既定値です。
		/// </summary>
		Return,

		/// <summary>
		/// エラーが発生した後も、以降のメソッドの実行を続行します。
		/// </summary>
		Continue,
	}
}
