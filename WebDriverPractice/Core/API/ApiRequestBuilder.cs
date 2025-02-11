using RestSharp;

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
			_request.AddHeader(key, value);
			return this;
		}

		public ApiRequestBuilder WithJsonBody(object body)
		{
			_request.AddJsonBody(body);
			return this;
		}

		public ApiRequestBuilder WithQueryParams(Dictionary<string, string> queryParams)
		{
			foreach (var param in queryParams)
			{
				_request.AddQueryParameter(param.Key, param.Value);
			}

			return this;
		}

		public RestRequest Build()
		{
			return _request;
		}
	}
}
