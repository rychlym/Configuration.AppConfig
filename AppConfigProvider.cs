using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Configuration.AppConfig
{
    /// <summary>
    /// The Legacy App.config  provider.
    /// Providing just the simple appSettings, connectionStrings so far.
    /// </summary>
    public class AppConfigProvider : ConfigurationProvider
    {
        public const string DefaultAppSettings = "appSettings";
        public const string DefaultConnectionStrings = "connectionStrings";

        public readonly string AppSettingsSectionPefix;
        public readonly string ConnectionStringsSectionPrefix;


        public AppConfigProvider(
            string appSettingsPresentedAs = DefaultAppSettings,
            string connectionStringsPresentedAs = DefaultConnectionStrings)
        {
            AppSettingsSectionPefix = appSettingsPresentedAs + ":";
            ConnectionStringsSectionPrefix = connectionStringsPresentedAs + ":";
        }

        public override void Load()
        {

            foreach (var settingKey in ConfigurationManager.AppSettings.AllKeys)
            {
                Data.Add(AppSettingsSectionPefix + settingKey, ConfigurationManager.AppSettings[settingKey]);
            }

            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                Data.Add(ConnectionStringsSectionPrefix + connectionString.Name, connectionString.ConnectionString);
            }
        }
    }
}
