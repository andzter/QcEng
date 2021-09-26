using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace QC.Lib
{
    public static class Settings
    {

        public static string Theme
        {
            get
            {
                return GetSetting(Constant.THEME_NAME);
                //Properties.Settings.Default.Theme;
            }
            set
            {
                SetSetting(Constant.THEME_NAME, value);
                //Properties.Settings.Default.Theme = value;
                //Properties.Settings.Default.Save();
            }
        }

        public static string GetSetting(string key)
        {

            string value = string.Empty;
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[key] != null)
                    value = config.AppSettings.Settings[key].Value;

                if (string.IsNullOrEmpty(value))
                {
                    value = System.Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
                }
            }
            catch
            {
                return string.Empty;
            }
            return value;
        }

        public static void SetSetting(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings[key] == null)
                    config.AppSettings.Settings.Add(key, value);
                else
                    config.AppSettings.Settings[key].Value = value;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch
            {
                return;
            }
        }
    }


}
