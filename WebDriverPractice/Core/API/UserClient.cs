using RestSharp;
using System.Net;
using WebDriverPractice.Business.Models;
using Serilog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebDriverPractice.Core.API
{
	public class UserClient : ApiClient
	{
		public UserClient(string baseUrl) : base(baseUrl)
		{
		}

		public async Task<List<UserModel>> GetAllUsersAsync()
		{
			Log.Information("Run GetAllUsersAsync method.");
			var request = new ApiRequestBuilder("/users", Method.Get).Build();
			var response = await SendRequestAsync<List<UserModel>>(request);

			return ValidateResponse(response);
		}

		public async Task<string> GetResponseHeaders()
		{
			Log.Information("Run GetResponseHeaders method.");
			var request = new ApiRequestBuilder("/users", Method.Get).Build();
			var response = await SendRequestAsync(request);

			var contentHeader = response.GetContentHeaderValue("content-type");

			if (contentHeader is null)
			{
				throw new Exception("Missing content-type headers.");
			}

			return contentHeader;
		}

		public async Task<UserModel> CreateUserAsync(UserModel user)
		{
			Log.Information("Run CreateUserAsync method.");
			var request = new ApiRequestBuilder("/users", Method.Post).WithJsonBody(user).Build();
			var response = await SendRequestAsync<UserModel>(request);

			if (response.StatusCode != HttpStatusCode.Created)
			{
				throw new Exception($"Expected status code 201 Created. Got {response.StatusCode}");
			}

			return ValidateResponse(response);
		}

		public async Task<HttpStatusCode> GetResourceNotExisting()
		{
			Log.Information("Run GetResourceNotExisting method.");
			var request = new ApiRequestBuilder("/invalidendpoint", Method.Get).Build();
			var response = await SendRequestAsync(request);

			return response.StatusCode;
		}

		private static T ValidateResponse<T>(RestResponse<T> response)
		{
			Log.Information("Run ValidateResponse method.");
			if (!response.IsSuccessful)
			{
				throw new Exception($"API request failed with status code {response.StatusCode}");
			}

			if (response.Data is null)
			{
				throw new Exception("Response content is empty.");
			}

			return response.Data;
		}
	}
}