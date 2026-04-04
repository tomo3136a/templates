using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyProduct
{
    public partial class MainForm : Form
    {
        public void InitializeMenu(MenuStrip menu)
        {
            //menubar control
            var menu_hold = new ToolStripMenuItem("保持(&0)");
            menu.MenuActivate += (_, e) => { this.MainMenuStrip.Visible = true; };
            menu.MenuDeactivate += (_, e) => { this.MainMenuStrip.Visible = menu_hold.Checked; };

            //file menu
            var submenu = new ToolStripMenuItem("ファイル(&F)");
            menu.Items.Add(submenu);
            {
                var item = new ToolStripMenuItem("リセット(&R)");
                item.Click += (e, _) => { _data.Reset(); };
                submenu.DropDownItems.Add(item);

                submenu.DropDownItems.Add(new ToolStripSeparator());

                item = new ToolStripMenuItem("終了(&X)");
                item.Click += OnClose;
                submenu.DropDownItems.Add(item);
            }

            //edit menu
            submenu = new ToolStripMenuItem("編集(&E)");
            submenu.Click += (e, _) =>
            {
                var s = _data.Name;
                var res = InputBox.Prompt(ref s);
                if (res == DialogResult.OK) _data.Name = s;
            };
            menu.Items.Add(submenu);

            //tool menu
            submenu = new ToolStripMenuItem("ツール(&T)");
            menu.Items.Add(submenu);

            //view menu
            submenu = new ToolStripMenuItem("表示(&V)");
            menu.Items.Add(submenu);
            {
                var item = new ToolStripMenuItem("フォント(&F)");
                item.Click += (_, e) =>
                {
                    var dlg = new FontDialog();
                    dlg.Font = this.Font;
                    if (dlg.ShowDialog() == DialogResult.OK)
                        this.Font = dlg.Font;
                };
                submenu.DropDownItems.Add(item);

                submenu.DropDownItems.Add(new ToolStripSeparator());

                item = new ToolStripMenuItem("表示設定オープン");
                item.Click += (_, e) => { MainFormSettings.OpenFile(); };
                submenu.DropDownItems.Add(item);

                item = new ToolStripMenuItem("表示設定削除");
                item.Click += (_, e) => { _settings.RemoveFile(); };
                submenu.DropDownItems.Add(item);

                item = new ToolStripMenuItem("表示設定リセット");
                item.Click += (_, e) => { _settings.Reset(); };
                submenu.DropDownItems.Add(item);

                item = new ToolStripMenuItem("表示設定更新");
                item.Click += (_, e) => { _settings.Upgrade(); };
                submenu.DropDownItems.Add(item);

                item = new ToolStripMenuItem("表示設定再読込");
                item.Click += (_, e) => { _settings.Reload(); };
                submenu.DropDownItems.Add(item);
            }

            //menu off
            menu_hold.Alignment = ToolStripItemAlignment.Right;
            menu_hold.CheckOnClick = true;
            menu_hold.Checked = true;
            menu_hold.Click += (_, e) => { if (menu_hold.Checked) this.MainMenuStrip.Visible = false; };
            menu.Items.Add(menu_hold);
        }
    }
}
