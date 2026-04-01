using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace MyProduct
{
    public class PathSelectButton : Button
    {
        public readonly List<Control> LinkItems = new List<Control>();
        public int LinkIndex = 0;
        public string Path = "";

        public event EventHandler PathChanged;
        public event EventHandler FileTypeChanged;

        public PathSelectDialog Selector = new PathSelectDialog();

        public enum Mode { OPEN = 1, SAVE = 2, FOLDER = 4, MULTI = 8 }
        public Mode ShowMode = Mode.OPEN;

        public PathSelectButton()
        {
            Text = "選択";
            Path = "";
            Click += new EventHandler(OnSelect);
        }

        public void Add(Control tb)
        {
            LinkItems.Add(tb);
        }

        //events
        public void OnSelect(Object sender, EventArgs args)
        {
            if (LinkIndex < 0) LinkIndex = 0;
            if (LinkIndex < LinkItems.Count)
                Selector.Path = LinkItems[LinkIndex].Text;

            if ((ShowMode & Mode.OPEN) != 0)
                Selector.ShowMode = PathSelectDialog.Mode.OPEN;
            else if ((ShowMode & Mode.SAVE) != 0)
                Selector.ShowMode = PathSelectDialog.Mode.SAVE;
            else if ((ShowMode & Mode.FOLDER) != 0)
                Selector.ShowMode = PathSelectDialog.Mode.FOLDER;
            else return;

            if (Selector.ShowDialog() != DialogResult.OK) return;

            Path = Selector.FullPath();
            foreach (var c in LinkItems)
            {
                var tb = c as TextBox;
                if (tb != null) tb.Text = Path;
            }
            if (PathChanged != null)
                PathChanged(this, new EventArgs());
            if (FileTypeChanged != null)
                FileTypeChanged(this, new EventArgs());

            return;
        }
    }
}
