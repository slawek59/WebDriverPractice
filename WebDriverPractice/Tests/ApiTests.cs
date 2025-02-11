using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Serilog;
using System.Net;
using WebDriverPractice.Business.Models;
using WebDriverPractice.Core.API;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WebDriverPractice.Tests
{
	[TestClass]
	public class ApiTests : ApiTestBase
	{
		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateGettingTheListOfUsers()
		{
			Log.Information("Send GET request to get the list of users.");
			var request = new RestRequest("/users", Method.Get);
			var response = await ApiClient.SendRequestAsync<List<UserModel>>(request);

			Assert.IsNotNull(response);
			Assert.IsTrue(response.Data.Count > 0, "Users list is empty.");
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Wrong status code.");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUsersResponseHeaders()
		{
			Log.Information("Send GET request to check the response headers.");
			var request = new RestRequest("/users", Method.Get);
			var response = await ApiClient.SendRequestAsync(request);

			Assert.IsNotNull(response);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Wrong status code.");
			Assert.IsTrue(response.Headers.Any(
				h => h.Name == "Content-Type" &&
				h.Value.ToString().Contains("application/json")), "Content-Type header is not provided or is incorrect.");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUsersListContent()
		{
			Log.Information("Sending GET request to verify users content.");
			var request = new RestRequest("/users", Method.Get);
			var response = await ApiClient.SendRequestAsync<List<UserModel>>(request);

			Assert.IsNotNull(response);
			Assert.AreEqual(10, response.Data.Count, "Wrong number of users.");
		}
	}
}
