using Microsoft.Extensions.Configuration;

namespace Configuration.AppConfig
{
    public static class AppConfigConfigurationExtension
    {
        public static IConfigurationBuilder AddAppConfig(this IConfigurationBuilder builder, 
            string appSettingsPresentedAs = AppConfigProvider.DefaultAppSettings, 
            string connectionStringsPresentedAs = AppConfigProvider.DefaultConnectionStrings)
        {
            var source = new AppConfigConfigurationSource(appSettingsPresentedAs, connectionStringsPresentedAs);
            builder.Add(source);
            return builder;
        }
    }
}
