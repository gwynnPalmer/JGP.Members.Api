namespace JGP.Members.Api.Application.Configuration
{
    using JGP.Members.Core.Configuration;

    /// <summary>
    ///     Class AppSettingsConfiguration.
    /// </summary>
    internal static class AppSettingsConfiguration
    {
        /// <summary>
        ///     Configures the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>AppSettings.</returns>
        public static AppSettings Configure(IConfiguration configuration)
        {
            var appSettings = new AppSettings();

            configuration.GetSection(AppSettings.ConfigurationSectionName).Bind(appSettings);

            return appSettings;
        }
    }
}