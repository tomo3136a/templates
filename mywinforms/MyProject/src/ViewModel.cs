using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyProduct
{
    [DataContract(Namespace = "")]
    public partial class ViewModel : ViewModelBase
    {
        public static string DefaultFileName = "data.xml";

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _name;

        //ここにデータメンバーを追加する


        public ViewModel() { Reset(); }
    }
}
