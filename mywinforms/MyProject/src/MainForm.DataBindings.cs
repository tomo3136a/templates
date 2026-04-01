using System;
using System.Windows.Forms;

namespace MyProduct
{
    public partial class MainForm : Form
    {
        private void SetBinding()
        {
            //form
            this.DataBindings.Add("Location", _settings, "FormLocation", true, DataSourceUpdateMode.OnPropertyChanged);
            this.DataBindings.Add("Size", _settings, "FormSize", true, DataSourceUpdateMode.OnPropertyChanged);
            this.DataBindings.Add("Font", _settings, "FormFont", true, DataSourceUpdateMode.OnPropertyChanged);

            //menu
            _menu_bar.DataBindings.Add("Visible", _settings, "MenuVisible", true, DataSourceUpdateMode.OnPropertyChanged);

            //layout

            //field
            //ここにデータバインディングを追加する

            var dtb = _txt_name.DataBindings.Add("Text", _data, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            dtb.Parse += (_, e) => { };
            dtb.Format += (_, e) => { };
            dtb.BindingComplete += (_, e) => { Alart(_txt_name, _data.IsValidName(), msg: e.ErrorText); };

        }
    }
}
