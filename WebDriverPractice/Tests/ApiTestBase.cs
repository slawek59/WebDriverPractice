using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using WebDriverPractice.Core.API;
using WebDriverPractice.Core.Config;

namespace WebDriverPractice.Tests
{
	public abstract class ApiTestBase
	{
		public string ApiBaseURL = null!;
		public UserClient UserClient = null!;
		public TestContext TestContext { get; set; } = null!;

		[TestInitialize]
		public void Setup()
		{
			Log.Information("API Tests initialize.");
			ApiBaseURL = ConfigManager.GetSetting("ApiSettings:ApiURL");
			UserClient = new UserClient(ApiBaseURL);
		}

		[TestCleanup]
		public void Cleanup()
		{
			if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
			{
				Log.Error($"\n!---{TestContext.TestName} FAILED.---!\n");
			}
			else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
			{
				Log.Information($"{TestContext.TestName} PASSED.");
			}
		}
	}
}