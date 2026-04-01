using System;
using System.Windows.Forms;
using System.Drawing;
using MyProduct;

namespace MyProduct
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        FlowLayoutPanel _pnl_root = new FlowLayoutPanel();
        MenuStrip _menu_bar = new MenuStrip();
        Label _sts = new Label();

        TextBox _txt_name = new TextBox();
        Button _btn1 = new Button();
        Button _btn2 = new Button();

        //ここにコントロールを追加します

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            //-:cnd:noEmit
#if NET6_0_OR_GREATER
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
#else
            this.AutoScaleDimensions = new System.Drawing.Size(96, 96);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
#endif
            //+:cnd:noEmit
            this.SuspendLayout();

            this.Text = GetTitle();
            this.AutoSize = true;

            //panel
            _pnl_root.Dock = DockStyle.Fill;
            _pnl_root.AutoSize = true;
            this.Controls.Add(_pnl_root);

            //menu
            this.MainMenuStrip = _menu_bar;
            InitializeMenu(_menu_bar);
            this.Controls.Add(_menu_bar);

            _sts.Dock = DockStyle.Fill;
            _sts.AutoSize = true;
            _pnl_root.Controls.Add(_sts);
            _pnl_root.SetFlowBreak(_sts, true);

            ///////////////////////////////////////////////////////////////////////////////

            //ここにコントロール設定を追加する

            _txt_name.Dock = DockStyle.Fill;
            _txt_name.Width = TextWidth(20);
            _pnl_root.Controls.Add(_txt_name);
            _pnl_root.SetFlowBreak(_txt_name, true);

            _btn1.Text = "←";
            _btn1.AutoSize = true;
            _btn1.Click += (_, e) => { OnButton1(); };
            _pnl_root.Controls.Add(_btn1);

            _btn2.Text = "+9";
            _btn2.AutoSize = true;
            _btn2.Click += (_, e) => { OnButton2(); };
            _pnl_root.Controls.Add(_btn2);

            ///////////////////////////////////////////////////////////////////////////////

            //close button
            var btn_close = new Button();
            btn_close.Text = "閉じる";
            btn_close.AutoSize = true;
            btn_close.Click += OnClose;
            _pnl_root.Controls.Add(btn_close);

            this.CancelButton = btn_close;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
