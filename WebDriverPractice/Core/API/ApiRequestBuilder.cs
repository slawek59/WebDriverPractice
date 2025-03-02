using RestSharp;
using Serilog;

namespace WebDriverPractice.Core.API
{
	public class ApiRequestBuilder
	{
		private readonly RestRequest _request;

		public ApiRequestBuilder(string endpoint, Method method)
		{
			_request = new RestRequest(endpoint, method);
		}

		public ApiRequestBuilder WithHeader(string key, string value)
		{
			Log.Information("Build request with header.");
			_request.AddHeader(key, value);
			return this;
		}

		public ApiRequestBuilder WithJsonBody(object body)
		{
			Log.Information("Build request with JSON body.");
			_request.AddJsonBody(body);
			return this;
		}

		public ApiRequestBuilder WithQueryParams(Dictionary<string, string> queryParams)
		{
			Log.Information("Build request with Query Params.");
			foreach (var param in queryParams)
			{
				_request.AddQueryParameter(param.Key, param.Value);
			}

			return this;
		}

		public RestRequest Build()
		{
			Log.Information("Build request.");
			return _request;
		}
	}
}