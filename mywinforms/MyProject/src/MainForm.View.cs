using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MyProduct
{
    public partial class MainForm : Form
    {
        private MainFormSettings _settings = new MainFormSettings();

        private static Dictionary<Control, int> _col_width;
        private static void AddTextWidth(Control c, int cnt)
        {
            if (_col_width == null) _col_width = new Dictionary<Control, int>();
            if (!_col_width.ContainsKey(c)) _col_width.Add(c, cnt);
        }

        //Text width
        private void SetTextWidth(int dw)
        {
            var em = EmSize(dw);

            //ここにサイズ計算を適用するコンボボックス・テキストボックスを追加します。
            _txt_name.Width = (int)(_txt_name.Width * em);
        }

        internal static void SetWidth(Control c, double a)
        {
            c.Width = (int)(c.Width * a);
        }

        private double EmSize(int dw)
        {
            var v1 = _settings.TextEm;
            if (v1 < 0.1) v1 = 0.1f;
            var v2 = v1 + dw / 100.0;
            if (v2 < 0.1) v2 = 0.1f;
            _settings.TextEm = (float)v2;
            return v2 / v1;
        }

        private int TextWidth(int n)
        {
            var w = 8.5 * (1 + n) * _settings.TextEm;
            return w > 20 ? (int)w : 20;
        }

        //title
        private static string GetTitle(string title = "")
        {
            var s = Application.ExecutablePath;
            s = Path.GetFileNameWithoutExtension(s);
            s += " " + Application.ProductVersion;
            if (title != "") s += " - " + title;
            return s;
        }
    }
}
