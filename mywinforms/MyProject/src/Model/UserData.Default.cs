using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace MyProduct
{
    public partial class UserData
    {
        public void Build(string mode = "")
        {

        }

        public static UserData Load(string path = "")
        {
            if (path == "") path = UserData.DafaultFileName;
            if (!File.Exists(path))
            {
                var data = new UserData();
                data.Build();
                return data;
            }

            var ts = new Type[] { typeof(UserData), typeof(ViewModel) };
            DataContractSerializer ser =
                new DataContractSerializer(typeof(UserData), ts);
            var bom = new System.Text.UTF8Encoding(false);
            using (var sr = new StreamReader(path, bom))
            using (var xr = XmlReader.Create(sr))
            {
                return (UserData)ser.ReadObject(xr);
            }
        }

        public bool Save(string path = "")
        {
            if (!IsSaving) return true;
            try
            {
                if (path == "") path = UserData.DafaultFileName;

                var ts = new Type[] { typeof(UserData), typeof(ViewModel) };
                DataContractSerializer ser =
                    new DataContractSerializer(typeof(UserData), ts);
                var xws = new XmlWriterSettings();
                xws.Encoding = new System.Text.UTF8Encoding(false);
                xws.Indent = true;
                using (var sw = XmlWriter.Create(path, xws))
                {
                    ser.WriteObject(sw, this);
                }
            }
            catch (Exception) { return false; }
            return true;
        }
    }
}
