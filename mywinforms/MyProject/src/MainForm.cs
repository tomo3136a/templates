using System;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;

namespace MyProduct
{
    public partial class MainForm : Form
    {
        private ViewModel _data;

        public MainForm()
        {
            _data = ViewModel.Load();
            InitializeComponent();
            InitializeValidation();
            InitializeEvents();

            this.Load += new EventHandler(MainForm_Load);
        }

        //form load
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            //ui settings
            _settings.SettingChanging += new SettingChangingEventHandler(MainForm_SettingChanging);
            _settings.SettingsSaving += new SettingsSavingEventHandler(MainForm_SettingsSaving);

            //binding
            SetBinding();

            //data
            SetData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.Save();
            _data.Save();
        }

        //settings serialization
        private void MainForm_SettingChanging(object sender, SettingChangingEventArgs e)
        {
            _settings.SaveEnable = true;
        }

        private void MainForm_SettingsSaving(object sender, CancelEventArgs e)
        {
            if (_settings.SaveEnable)
            {
                var res = MessageBox.Show(
                    "UI 設定を保存しますか？", "Save Settings", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == res) return;
            }
            e.Cancel = true;
        }

        //base events
        private void OnClose(Object sender, EventArgs args)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //override key press
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //valiidation
            if (keyData == Keys.F1) { ValidateData(); return true; }

            //resize text width
            if (keyData == Keys.F9) { SetTextWidth(-10); return true; }
            if (keyData == Keys.F10) { SetTextWidth(10); return true; }

            //data panel on/off
            if (keyData == Keys.F12) { _settings.DataVisible = !_settings.DataVisible; return true; }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetData()
        {
            //ここに後からのデータ設定を追加します。

        }
    }
}
