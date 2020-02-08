using Microsoft.Extensions.Configuration;

namespace Configuration.AppConfig
{
    public class AppConfigConfigurationSource : IConfigurationSource
    {
        public readonly string AppSettingsPresentedAs;
        public readonly string ConnectionStringsPresentedAs;

        public AppConfigConfigurationSource(
            string appSettingsPresentedAs = AppConfigProvider.DefaultAppSettings,
            string connectionStringsPresentedAs = AppConfigProvider.DefaultConnectionStrings)
        {
            AppSettingsPresentedAs = appSettingsPresentedAs;
            ConnectionStringsPresentedAs = connectionStringsPresentedAs;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new AppConfigProvider(AppSettingsPresentedAs, ConnectionStringsPresentedAs);
        }
    }
}
