using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System.Net;
using WebDriverPractice.Business.Models;
using WebDriverPractice.Core.API;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.ClassLevel)]
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
			var request = new ApiRequestBuilder("/users", Method.Get).Build();
			var response = await ApiClient.SendRequestAsync<RestResponse>(request);

			Assert.IsNotNull(response);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"Expected status code 200 OK but got {response.StatusCode}");

			Assert.IsFalse(string.IsNullOrEmpty(response.Content), "Response content is empty.");

			var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);
			
			Assert.IsNotNull(users);

			Assert.IsTrue(users.Count > 0, "User list is empty.");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUsersResponseHeaders()
		{
			Log.Information("Send GET request to check the response headers.");
			var request = new ApiRequestBuilder("/users", Method.Get).Build();
			var response = await ApiClient.SendRequestAsync<RestResponse>(request);

			Assert.IsNotNull(response.Headers);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"Expected status code 200 OK but got {response.StatusCode}");

			var contentTypeHeader = response.Headers.FirstOrDefault(h => h.Name == "Content-Type")?.Value?.ToString();
			Assert.IsNotNull(contentTypeHeader, "Content-Type header is missing.");
			Assert.AreEqual("application/json; charset=utf-8", contentTypeHeader, $"Unexpected Content-Type value: {contentTypeHeader}");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUsersListContent()
		{
			Log.Information("Sending GET request to verify users content.");
			var request = new ApiRequestBuilder("/users", Method.Get).Build();
			var response = await ApiClient.SendRequestAsync<List<UserModel>>(request);

			Assert.IsNotNull(response);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"Expected status code 200 OK but got {response.StatusCode}");

			Assert.IsFalse(string.IsNullOrEmpty(response.Content), "Response content is empty.");

			var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);
			Assert.IsNotNull(users, "Failed to deserialize user list.");
			Assert.AreEqual(10, users.Count, $"Wrong number of users. Found {users.Count}.");

			Assert.AreEqual(users.Count, users.Select(u => u.Id).Distinct().Count(), "Some IDs are duplicated.");

			Assert.IsTrue(users.TrueForAll(u => !string.IsNullOrEmpty(u.Name) && !string.IsNullOrEmpty(u.Username)), "Users Name and Username must not be empty.");
			Assert.IsTrue(users.TrueForAll(u => !string.IsNullOrEmpty(u.Company?.Name)), "Company Name must not be empty.");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUserCreation()
		{
			Log.Information("Sending POST request to varify user creation.");

			var newUser = new UserModel { Name = "Jan Kowalski", Username = "jankowalski777" };

			var request = new ApiRequestBuilder("/users", Method.Post).WithJsonBody(newUser).Build();
			var response = await ApiClient.SendRequestAsync<RestResponse>(request);

			Assert.IsNotNull(response);
			Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, $"Expected status code {HttpStatusCode.Created} but got {response.StatusCode}");

			Assert.IsFalse(string.IsNullOrEmpty(response.Content), "Response content is empty.");

			var createdUser = JsonConvert.DeserializeObject<UserModel>(response.Content);

			Assert.IsNotNull(createdUser);

			Assert.IsTrue(createdUser.Id > 0, "User was not successfully created.");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUserNotificationIfResourceDoesNotExist()
		{
			Log.Information("Sending GET request to varify user not existing.");

			var request = new ApiRequestBuilder("/invalidendpoint", Method.Get).Build();
			var response = await ApiClient.SendRequestAsync<RestResponse>(request);

			Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
		}
	}
}
