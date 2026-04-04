using System;
using System.Collections.Generic;

namespace MyProduct
{
    public partial class ViewModel : ViewModelBase
    {
        public void Reset()
        {
            //データメンバの初期値を追加する
            Name = "";

        }

        public void CopyFrom(ViewModel cfg)
        {
            //データメンバの複製を追加する
            Name = cfg.Name;

        }

        public static ViewModel Load(string path = "")
        {
            return ViewModelBase.Load<ViewModel>(path == "" ? DefaultFileName : path);
        }

        public override bool Save(string path = "")
        {
            return base.Save(path == "" ? DefaultFileName : path);
        }
    }
}
