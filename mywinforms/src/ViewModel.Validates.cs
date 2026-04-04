using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace MyProduct
{
    public partial class ViewModel : ViewModelBase
    {
        // ここにバリデーションを追加します
        public bool IsValidName() { return Regex.Match(Name, "^\\d+$").Success; }

        //IDataErrorInfo
        public override string this[string columnName]
        {
            get
            {
                var msg = string.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            msg = "Name in Empty.";
                        }
                        else if (!IsValidName())
                        {
                            msg = "Not Number";
                        }
                        break;
                        //各プロパティの判定して警告文を作成。
                }
                return msg;
            }
        }
    }
}
