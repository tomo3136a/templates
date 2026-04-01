using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace MyProduct
{
    public class InputBox
    {
        public class Option
        {
            public string Value = "";
            public string[] Values = new string[] { };
            public string Title = "";
            public string Message = "";
            public int Width = 300;
        }
        public static DialogResult Prompt(ref string value, Option opt)
        {
            var dlg = new Form() { Width = opt.Width, Height = 150, Text = opt.Title, };
            dlg.MaximizeBox = false;
            dlg.MinimizeBox = false;
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlg.StartPosition = FormStartPosition.CenterScreen;

            var w = dlg.ClientSize.Width;
            var lbl = new Label() { Left = 10, Top = 20, Text = opt.Message };
            var txt = new TextBox() { Left = 10, Top = 50, Width = w - 20, Text = value };
            var ok = new Button() { Text = "OK", Left = opt.Width / 2 - 100, Top = 80, DialogResult = DialogResult.OK };
            var cancel = new Button() { Text = "Cancel", Left = opt.Width / 2, Top = 80, DialogResult = DialogResult.Cancel };

            ok.Click += (_, e) => { dlg.Close(); };
            cancel.Click += (_, e) => { txt.Text = string.Empty; dlg.Close(); };

            dlg.Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
            dlg.AcceptButton = ok;
            dlg.CancelButton = cancel;
            var res = dlg.ShowDialog();
            if (res == DialogResult.OK) value = txt.Text;
            return res;
        }

        public static DialogResult Prompt(ref string value,
            string title = "", string message = "", int width = 300)
        {
            return Prompt(ref value, new Option()
            {
                Value = value,
                Title = title,
                Message = message,
                Width = width,
            });
        }

        public static DialogResult Select(ref string value, string title = "", string message = "", string[] values = null, int width = 300)
        {
            var dlg = new Form() { Width = width, Height = 150, Text = title, };
            dlg.MaximizeBox = false;
            dlg.MinimizeBox = false;
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlg.StartPosition = FormStartPosition.CenterScreen;

            var w = dlg.ClientSize.Width;
            var lbl = new Label() { Left = 10, Top = 20, Text = message };
            var cbx = new ComboBox() { Left = 10, Top = 50, Width = w - 20, Text = value };
            var ok = new Button() { Text = "OK", Left = width / 2 - 100, Top = 80, DialogResult = DialogResult.OK };
            var cancel = new Button() { Text = "Cancel", Left = width / 2, Top = 80, DialogResult = DialogResult.Cancel };

            ok.Click += (_, e) => { dlg.Close(); };
            cancel.Click += (_, e) => { cbx.Text = string.Empty; dlg.Close(); };

            dlg.Controls.AddRange(new Control[] { lbl, cbx, ok, cancel });
            dlg.AcceptButton = ok;
            dlg.CancelButton = cancel;
            var res = dlg.ShowDialog();
            if (res == DialogResult.OK) value = cbx.Text;
            return res;
        }

        public InputBox() { }
    }
}
