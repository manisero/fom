using System.Configuration;
using System.Runtime.CompilerServices;
using DataSource.DataAccess;

namespace ClientAPI
{
    public class SettingsProvider : IDataAccessSettingsProvider
    {
        public string DataSourceAddress
        {
            get { return GetStringSetting(); }
        }

        protected string GetStringSetting([CallerMemberName] string key = null)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}