using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Serializers;

namespace EmmaSharp.Adapters
{
    internal class EmmaApiAdapter : IEmmaApiAdapter
    {
        private const int MAX_PAGE_SIZE = 500;

        private readonly IRestClientFactory clientFactory;
        private readonly EmmaOptions options;
        private readonly ILogger logger;

        /// <summary>Emma API request adapter static configuration</summary>
        static EmmaApiAdapter()
        {
            SecurityProtocolType acceptedProtocolTypes = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            SetAcceptedProtocolTypes(acceptedProtocolTypes);
        }

        public EmmaApiAdapter(ILogger<EmmaApiAdapter> logger, IRestClientFactory clientFactory, EmmaOptions options)
        {
            this.clientFactory = clientFactory;
            this.options = options;
            this.logger = logger;
        }

        /// <summary>Execute the Call to the Emma API. All methods return this base method</summary>
        /// <typeparam name="T">The model or type to bind the return response.</typeparam>
        /// <param name="request">The RestRequest request.</param>
        /// <param name="start">If more than 500 results, use these parameters to start/end pages.</param>
        /// <param name="end">If more than 500 results, use these parameters to start/end pages.</param>
        /// <returns>Response data from the API call.</returns>
        public async Task<T> MakeRequest<T>(RestRequest request, uint? start = null, uint? end = null)
        {
            if (start >= 0 || end >= 0)
            {
                start = ValidateStartPage(start, end);
                end = ValidateEndPage(start, end);
                request.AddQueryParameter("start", start.ToString());
                request.AddQueryParameter("end", end.ToString());
            }

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new EmmaJsonSerializer();
            request.AddParameter("accountId", options.AccountId, ParameterType.UrlSegment);

            logger.LogDebug($"Request for {request.Resource} starting");
            IRestClient client = clientFactory.GetRestClient();
            IRestResponse<T> response = await client.ExecuteAsync<T>(request);
            logger.LogDebug($"Request for {request.Resource} complete with {response.StatusCode}");

            if (response.StatusCode >= HttpStatusCode.BadRequest)
            {
                throw new EmmaException(response);
            }

            //T content = JsonConvert.DeserializeObject<T>(response.Content);
            //return content;

            return response.Data;
        }

        private static uint ValidateStartPage(uint? start, uint? end)
        {
            if (start > 0)
            {
                return start.Value;
            }

            if (end > 0 || end - MAX_PAGE_SIZE > 0)
            {
                return end.Value - MAX_PAGE_SIZE;
            }

            return 0;
        }

        private static uint ValidateEndPage(uint? start, uint? end)
        {
            if (end > 0)
            {
                return end.Value;
            }

            if (start > 0)
            {
                return start.Value + MAX_PAGE_SIZE;
            }

            return MAX_PAGE_SIZE;
        }

        /// <summary>Sets accepted security type for Emma API requests</summary>
        /// <param name="acceptedProtocolTypes">Accepted types</param>
        private static void SetAcceptedProtocolTypes(SecurityProtocolType acceptedProtocolTypes)
            => ServicePointManager.SecurityProtocol = acceptedProtocolTypes;
    }
}
