using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using System.ComponentModel.DataAnnotations;

namespace MyProduct
{
    [DataContract(Namespace = "")]
    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            if (PropertyChanged == null) return;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //IDataErrorInfo
        public string Error { get { return string.Empty; } }

        public virtual string this[string columnName] { get { return string.Empty; } }

        //Serialize
        public static T Load<T>(string path)
        {
            if (path != "" && File.Exists(path))
            {
                var ser = new DataContractSerializer(typeof(T));
                var bom = new System.Text.UTF8Encoding(false);
                try
                {
                    using (var sr = new StreamReader(path, bom))
                    using (var xr = XmlReader.Create(sr))
                    {
                        return (T)ser.ReadObject(xr);
                    }
                }
                catch (Exception) { }
            }
            return Activator.CreateInstance<T>();
        }

        public virtual bool Save(string path)
        {
            if (path == "") return true;
            try
            {
                var ser = new DataContractSerializer(this.GetType());
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
