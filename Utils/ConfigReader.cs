using Microsoft.Extensions.Configuration;

public static class ConfigReader
{
    private static IConfiguration _config;

    static ConfigReader()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();
    }

    public static string GetConfigValue(string key)
    {
        return _config[key];
    }

    public static string GetBaseUrl()
    {
        return GetConfigValue("baseUrl");
    }
}