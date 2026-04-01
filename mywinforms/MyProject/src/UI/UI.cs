using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace MyProduct
{
    public sealed class UI
    {
        public static void TextBox_Hex_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)Keys.Menu == e.KeyValue) return; //ALT
            if ('A' <= e.KeyValue && e.KeyValue <= 'F') return;
            if ('0' <= e.KeyValue && e.KeyValue <= '9') return;
            if ((int)Keys.NumPad0 <= e.KeyValue && e.KeyValue <= (int)Keys.NumPad9) return;
            if ((int)Keys.Back == e.KeyValue || (int)Keys.Delete == e.KeyValue) return;
            if ((int)Keys.Left == e.KeyValue || (int)Keys.Right == e.KeyValue) return;
            if ((int)Keys.F1 <= e.KeyValue && e.KeyValue <= (int)Keys.F24) return;
            e.SuppressKeyPress = true;
        }
    }
}
