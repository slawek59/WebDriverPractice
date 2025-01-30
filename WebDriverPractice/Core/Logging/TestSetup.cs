using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;

namespace WebDriverPractice.Core.Logging
{
	[TestClass]
	public static class TestSetup
	{
		[AssemblyInitialize]
		public static void AssemblyInitialize(TestContext context)
		{
			LogManager.Initialize();
			Log.Information("Global test setup started.");
		}

		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{
			Log.Information("Assembly cleanup.");
			LogManager.Close();
		}
	}
}
