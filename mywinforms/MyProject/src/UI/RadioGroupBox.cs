using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace MyProduct
{
    public class RadioGroupBox : GroupBox
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText
        {
            get { return _selectedText; }
            set
            {
                if (_selectedText == value) return;
                _selectedText = value;
                if (SelectedTextChanged == null) return;
                SelectedTextChanged(this, new EventArgs());
            }
        }
        private string _selectedText;
        public event EventHandler SelectedTextChanged;

        public RadioGroupBox() : base()
        {
            _selectedText = "";
            SelectedTextChanged += (sender, args) =>
            {
                foreach (var c in Controls)
                {
                    var rb = c as RadioButton;
                    if (rb == null) continue;
                    if (rb.Text == SelectedText)
                        if (!rb.Checked) rb.Checked = true;
                }
            };
        }

        public void AddItems(string[] ss)
        {
            var y = 20;
            foreach (var c in Controls)
            {
                var rb = c as RadioButton;
                var y1 = rb.Location.Y + rb.Height;
                if (y1 > y) y = y1;
            }
            foreach (var s in ss)
            {
                var rb = new RadioButton();
                rb.Text = s;
                rb.Location = new Point(10, y);
                rb.CheckedChanged += (sender, args) =>
                {
                    var c = sender as RadioButton;
                    if (c == null) return;
                    if (!c.Checked) return;
                    if (SelectedText == c.Text) return;
                    SelectedText = c.Text;
                };
                Controls.Add(rb);
                y += rb.Height;
            }
        }
    }
}
