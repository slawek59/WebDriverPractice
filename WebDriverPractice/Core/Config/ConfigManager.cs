using Microsoft.Extensions.Configuration;

namespace WebDriverPractice.Core.Config
{
	public static class ConfigManager
	{
		private static IConfigurationRoot _configuration;

		static ConfigManager()
		{
			var configPath = GetConfigFilePath();

			var builder = new ConfigurationBuilder()
				.SetBasePath(Path.GetDirectoryName(configPath)!)
				.AddJsonFile(configPath, optional: false, reloadOnChange: true);

			_configuration = builder.Build();
		}

		public static string GetSetting(string key)
		{
			return _configuration[key];
		}

		public static bool GetBoolSetting(string key)
		{
			return bool.TryParse(_configuration[key], out var result) && result;
		}

		private static string GetConfigFilePath()
		{
			string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
			string configFileName = "appsettings.json";
			string configFilePath = Path.Combine(basePath, configFileName);

			return configFilePath;
		}
	}
}
