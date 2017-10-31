using System;
using System.Text;
using SharePointLibrary.Enums;

namespace SharePointLibrary.Helper.Primitive
{
    /// <summary>
    /// バッチ処理の文字列を作成する抽象クラスです。
    /// </summary>
    public abstract class BaseBatchData
    {
        #region プロパティ

        /// <summary>
        /// 処理を行うメソッドの文字列を格納します。
        /// </summary>
        protected StringBuilder Methods { get; set; } = new StringBuilder();

        /// <summary>
        /// エラー時の処理タイプ
        /// </summary>
        public OnErrorTyps OnError { get; set; } = OnErrorTyps.Return;

        /// <summary>
        /// リストGUID
        /// </summary>
        public Guid ListGuid { get; protected set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="listGuid">リストGUID</param>
        protected BaseBatchData(Guid listGuid)
        {
            this.ListGuid = listGuid;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// バッチ処理の文字列に変換します。 (オーバーライド)
        /// </summary>
        /// <returns>バッチ処理の文字列を返します。</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(@"<?xml version=""1.0"" encoding=""UTF-8""?>")
            .Append($@"<ows:Batch OnError=""{this.OnError}"">{this.Methods}</ows:Batch>");

            return sb.ToString();
        }

        #endregion
    }
}
