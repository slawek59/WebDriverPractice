using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;

namespace WebDriverPractice.Core.Config
{
	public static class ConfigManager
	{
		private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
		   .SetBasePath(GetConfigDirectory())
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
		
		private static string GetConfigDirectory()
		{
			Log.Information("Getting configuration file path.");

			string? assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			if (string.IsNullOrEmpty(assemblyLocation))
			{
				throw new Exception("Could not determine the assembly location.");
			}

			return assemblyLocation;
		}
	}
}
