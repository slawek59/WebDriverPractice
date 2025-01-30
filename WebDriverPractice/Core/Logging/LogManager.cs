using Serilog;

namespace WebDriverPractice.Core.Logging
{
	public static class LogManager
	{
		private static bool _isInitialized = false;

		public static void Initialize()
		{
			if (_isInitialized) return;

			var now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
			var logFilePath = Path.Combine(Environment.CurrentDirectory, $"Logs_{now}.txt");

			Log.Logger = new LoggerConfiguration()
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
