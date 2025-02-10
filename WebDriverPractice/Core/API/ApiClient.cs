using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebDriverPractice.Core.API
{
	public class ApiClient
	{
		private readonly IRestClient _client;

		public ApiClient(string baseUrl)
		{
			var serializerOptions = new JsonSerializerOptions
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
			};

			_client = new RestClient(
				options: new RestClientOptions(baseUrl),
				configureSerialization: s => s.UseSystemTextJson(serializerOptions)
				);
		}

		public async Task<RestResponse> SendRequestAsync(RestRequest request)
		{
			return await _client.ExecuteAsync(request);
		}

		public async Task<RestResponse<T>> SendRequestAsync<T>(RestRequest request) where T : new()
		{
			return await _client.ExecuteAsync<T>(request);
		}
	}
}
