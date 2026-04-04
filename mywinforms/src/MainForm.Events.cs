using System;
using System.Windows.Forms;

namespace MyProduct
{
    public partial class MainForm : Form
    {
        private void InitializeEvents()
        {
            //ここにコントロールのイベント登録を追加します。
        }

        //user events: 
        //ここにコントロールのイベントを追加します。

        void OnButton1()
        {
            var s = _data.Name;
            _data.Name = (s.Length > 0) ? s.Substring(1) : "a";
        }
        void OnButton2()
        {
            _data.Name += "9";
        }
    }
}
