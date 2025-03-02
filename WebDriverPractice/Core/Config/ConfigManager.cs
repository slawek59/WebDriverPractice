using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;

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
			string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
			string configFileName = "appsettings.json";
			string configFilePath = Path.Combine(assemblyLocation, configFileName);

			return configFilePath;
		}
	}
}