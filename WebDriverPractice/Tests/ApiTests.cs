using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			var users = await UserClient.GetAllUsersAsync();

			Assert.IsTrue(users.All(u => u.id >= 0), "Some users have invalid ID.");
			Assert.IsTrue(users.All(u => !string.IsNullOrEmpty(u.name)), "Some users have invalid Name.");
			Assert.IsTrue(users.All(u => !string.IsNullOrEmpty(u.username)), "Some users have invalid Username.");
			Assert.IsTrue(users.All(u => !string.IsNullOrEmpty(u.email)), "Some users have invalid Email.");
			Assert.IsTrue(users.All(u => u.address is not null), "Some users have invalid Address.");
			Assert.IsTrue(users.All(u => !string.IsNullOrEmpty(u.phone)), "Some users have invalid Phone.");
			Assert.IsTrue(users.All(u => !string.IsNullOrEmpty(u.website)), "Some users have invalid Website.");
			Assert.IsTrue(users.All(u => u.company is not null), "Some users have invalid Company.");
			Assert.IsInstanceOfType(users, typeof(List<UserModel>), "Response body is not a list of users.");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUsersResponseHeaders()
		{
			Log.Information("Send GET request to check the response headers.");
			var contentHeader = await UserClient.GetResponseHeaders();

			Assert.AreEqual(contentHeader, "application/json; charset=utf-8");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUsersListContent()
		{
			Log.Information("Sending GET request to verify users content.");
			var users = await UserClient.GetAllUsersAsync();

			Assert.AreEqual(10, users.Count, "Number of users do not match.");
			Assert.AreEqual(10, users.Select(u => u.id).Distinct().Count(), "Some IDs are duplicated.");
			Assert.IsTrue(users.All(u => !string.IsNullOrEmpty(u.name)), "Some users have invalid Name.");
			Assert.IsTrue(users.All(u => !string.IsNullOrEmpty(u.username)), "Some users have invalid Username.");
			Assert.IsTrue(users.All(u => u.company is not null), "Some users have invalid Company.");
			Assert.IsTrue(users.All(u => u.company.name is not null), "Some users have invalid Company Name.");
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUserCreation()
		{
			Log.Information("Sending POST request to varify user creation.");
			var newUser = new UserModel { name = "Jan Kowalski", username = "jankowalski777" };

			var users = await UserClient.GetAllUsersAsync();
			var existingIDs = users.Select(u => u.id);

			var createdUser = await UserClient.CreateUserAsync(newUser);

			Assert.IsFalse(existingIDs.Contains(createdUser.id));
		}

		[TestMethod]
		[TestCategory("API")]
		public async Task ValidateUserNotificationIfResourceDoesNotExist()
		{
			Log.Information("Sending GET request to varify user not existing.");
			var statusCode = await UserClient.GetResourceNotExisting();

			Assert.AreEqual(HttpStatusCode.NotFound, statusCode);
		}
	}
}