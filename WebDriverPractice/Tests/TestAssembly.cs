using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using WebDriverPractice.Core.Logging;

namespace WebDriverPractice.Tests
{
	[TestClass]
	public static class TestAssembly
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
