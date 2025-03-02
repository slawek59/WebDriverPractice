using Serilog;
using Serilog.Events;
using WebDriverPractice.Core.Config;

namespace WebDriverPractice.Core.Logging
{
	public static class LogManager
	{
		private static bool _isInitialized = false;

		public static void Initialize()
		{
			if (_isInitialized) return;

			string logLevelConfig = ConfigManager.GetSetting("Logging:LogLevel:Default");

			string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");

			if (!Directory.Exists(logDirectory))
			{
				Directory.CreateDirectory(logDirectory);
			}

			Directory.CreateDirectory(logDirectory);
			var logFilePath = Path.Combine(logDirectory, $"log_.txt");

			LogEventLevel logLevel = Enum.TryParse(logLevelConfig, true, out LogEventLevel parsedLogLevel) ? parsedLogLevel : LogEventLevel.Information;

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Is(logLevel)
				.WriteTo.Console()
				.WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
				.CreateLogger();

			Log.Information("Logger initialized.");
			_isInitialized = true;
		}

		public static void Close()
		{
			Log.Information("Closing logger and flushing logs.");
			Log.CloseAndFlush();
		}
	}
}
