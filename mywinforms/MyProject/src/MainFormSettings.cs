using System;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace MyProduct
{
    [SettingsGroupName("mainform.settings")]
    public class MainFormSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("0, 0")]
        public Point FormLocation
        {
            get { return (Point)(this["FormLocation"]); }
            set { this["FormLocation"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("640, 480")]
        public Size FormSize
        {
            get { return (Size)this["FormSize"]; }
            set { this["FormSize"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("1.0")]
        public float TextEm
        {
            get { return (float)this["TextEm"]; }
            set { this["TextEm"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Meiryo UI, 8.25pt")]
        public Font FormFont
        {
            get { return (Font)this["FormFont"]; }
            set { this["FormFont"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("False")]
        public bool MenuVisible
        {
            get { return (bool)this["MenuVisible"]; }
            set { this["MenuVisible"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("False")]
        public bool DataVisible
        {
            get { return (bool)this["DataVisible"]; }
            set { this["DataVisible"] = value; }
        }

        //ここにシリアライズする設定を追加する。

        public bool SaveEnable = false;

        public static string ConfigurationPath()
        {
            var lv = ConfigurationUserLevel.PerUserRoamingAndLocal;
            var cf = ConfigurationManager.OpenExeConfiguration(lv);
            return cf.FilePath;
        }

        public void RemoveFile()
        {
            try
            {
                var lv = ConfigurationUserLevel.PerUserRoamingAndLocal;
                var cf = ConfigurationManager.OpenExeConfiguration(lv);
                var p = cf.FilePath;
                if (File.Exists(p)) File.Delete(p);
                SaveEnable = false;
            }
            catch (Exception) { MessageBox.Show("Error Clear Configuration."); }
        }

        public static void OpenFile()
        {
            try
            {
                var lv = ConfigurationUserLevel.PerUserRoamingAndLocal;
                var cf = ConfigurationManager.OpenExeConfiguration(lv);
                var p = cf.FilePath;
                if (File.Exists(p)) Process.Start("notepad.exe", p);
            }
            catch (Exception) { MessageBox.Show("Error Open Configuration."); }
        }
    }
}
