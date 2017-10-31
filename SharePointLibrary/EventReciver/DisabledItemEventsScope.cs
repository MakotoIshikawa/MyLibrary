using System;
using Microsoft.SharePoint;

namespace SharePointLibrary.EventReciver
{
    /// <summary>
    /// イベントレシーバーの発生を無効にする using スコープを提供するクラスです。
    /// </summary>
    public class DisabledItemEventsScope : SPItemEventReceiver, IDisposable
    {
        #region フィールド

        private bool _oldValue;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DisabledItemEventsScope()
        {
            this._oldValue = this.EventFiringEnabled;
            this.EventFiringEnabled = false;
        }

        #endregion

        #region IDisposable メンバー

        /// <summary>
        /// アンマネージ リソースの解放およびリセットに関連付けられているアプリケーション定義のタスクを実行します。
        /// </summary>
        public void Dispose()
        {
            this.EventFiringEnabled = _oldValue;
        }

        #endregion
    }
}