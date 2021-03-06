﻿using System;
using System.Windows.Input;

namespace WpfStackLayer
{
    /// <summary>
    /// 指定した CanExecute() と Execute() をリレーするコマンド
    /// </summary>
    public class RelayCommand : ICommand
    {
        #pragma warning disable 0067
        /// <summary>
        /// 実行可能かどうかが変化したタイミングで発生するイベント (使用しないで下さい)
        /// </summary>
        public event EventHandler CanExecuteChanged;
        #pragma warning restore 0067

        Func<object, bool> canExecuteFunc;
        Action<object> executeAction;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="canExecuteFunc">実行可能かどうかを判定するFunc</param>
        /// <param name="executeAction">実行アクション</param>
        public RelayCommand( Func<object, bool> canExecuteFunc, Action<object> executeAction )
        {
            this.canExecuteFunc = canExecuteFunc;
            this.executeAction = executeAction;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="executeAction">実行アクション</param>
        public RelayCommand( Action<object> executeAction ) : this( parameter => true, executeAction )
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="executeAction">実行アクション (パラメータなし)</param>
        public RelayCommand( Action executeAction ) : this( parameter => executeAction() )
        {
        }

        /// <summary>
        /// 実行可能かどうかを判定します
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>true: 実行可能，false: 実行不可能</returns>
        public bool CanExecute( object parameter ) => canExecuteFunc( parameter );

        /// <summary>
        /// コマンドを実行します
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        public void Execute( object parameter ) => executeAction( parameter );
    }
}
