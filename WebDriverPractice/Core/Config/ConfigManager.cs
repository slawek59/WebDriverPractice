using Microsoft.Extensions.Configuration;
using Serilog;

namespace WebDriverPractice.Core.Config
{
	public static class ConfigManager
	{
		private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
		   .SetBasePath(Directory.GetCurrentDirectory())
		   .AddJsonFile(GetConfigFilePath(), optional: false, reloadOnChange: true)
		   .Build();

		public static string GetSetting(string key)
		{
			return _configuration[key] ?? string.Empty;
		}

		public static bool GetBoolSetting(string key)
		{
			return bool.TryParse(_configuration[key], out var result) && result;
		}

		private static string GetConfigFilePath()
		{
			Log.Information("Getting File Path.");
			string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
			string configFileName = "appsettings.json";
			string configFilePath = Path.Combine(basePath, configFileName);

			return configFilePath;
		}
	}
}
