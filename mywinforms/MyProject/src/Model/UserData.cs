using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyProduct
{
    [DataContract(Namespace = "")]
    public partial class UserData
    {
        [DataMember]
        public string[] Names;

        //データメンバーを追加する。

        //file type accessor

        //アクセッサーを追加する。

        public bool IsSaving { get; set; }
        public const string DafaultFileName = "datasource.xml";

        //////////////////////////////////////////////////////////////////////

        public UserData()
        {
            Names = new string[] { };
            //InitializeSample();
            IsSaving = false;
        }
    }
}
