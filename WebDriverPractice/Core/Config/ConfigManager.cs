using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;

namespace WebDriverPractice.Core.Config
{
	public static class ConfigManager
	{
		//private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
		//   .SetBasePath(Directory.GetCurrentDirectory())
		//   .AddJsonFile(GetConfigFilePath(), optional: false, reloadOnChange: true)
		//   .Build();

		private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
		   .SetBasePath(GetConfigDirectory()) // Dynamically locate the bin folder
		   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		   .Build();


		public static string GetSetting(string key)
		{
			return _configuration[key] ?? string.Empty;
		}

		public static bool GetBoolSetting(string key)
		{
			return bool.TryParse(_configuration[key], out var result) && result;
		}

		//private static string GetConfigFilePath()
		//{
		//	Log.Information("Getting File Path.");
		//	string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
		//	string configFileName = "appsettings.json";
		//	string configFilePath = Path.Combine(basePath, configFileName);

		//	return configFilePath;
		//}

		private static string GetConfigDirectory()
		{
			Log.Information("Getting configuration file path.");

			// Get the executing assembly's directory (inside bin/debug or bin/release)
			string? assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			if (string.IsNullOrEmpty(assemblyLocation))
			{
				throw new Exception("Could not determine the assembly location.");
			}

			return assemblyLocation;
		}
	}
}
