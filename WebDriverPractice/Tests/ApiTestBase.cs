using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDriverPractice.Core.API;
using WebDriverPractice.Core.Config;

namespace WebDriverPractice.Tests
{
	public abstract class ApiTestBase
	{
		public string ApiBaseURL = null!;
		public ApiClient ApiClient = null!;

		[TestInitialize]
		public void Setup()
		{
			ApiBaseURL = ConfigManager.GetSetting("ApiSettings:ApiURL");
			ApiClient = new ApiClient(ApiBaseURL);
		}
	}
}
