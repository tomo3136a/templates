using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace MyProduct
{
    public partial class MainForm : Form
    {
        public void InitializeValidation()
        {
            //ここにバリデーション登録を追加する
            //_txt_name.Validating += (_, e) => { ValidateData(); };
        }

        public void ValidateData()
        {
            //ここにバリデーションを追加する
            //Alart(_txt_name, _data.IsValidName());
        }

        //ここにコントロールのバリデーションを追加する

        //////////////////////////////////////////////////////////////////////

        //level = 1  warning
        //level = 2  attention
        //level = 3  caution
        //level = 4  alert
        //level = 5  safe
        private void Alart(Control control, bool b = false, int lv = 1, string msg = null)
        {
            var color = SystemColors.Window;
            color = lv == 1 ? Color.Yellow : color;
            color = lv == 2 ? Color.LightYellow : color;
            color = lv == 3 ? Color.Orange : color;
            color = lv == 4 ? Color.Red : color;
            color = lv == 5 ? Color.GreenYellow : color;
            color = b ? SystemColors.Window : color;
            if (control.BackColor != color) control.BackColor = color;
            if (_sts != null) _sts.Text = msg;
        }
    }
}
