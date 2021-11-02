using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharper
{
    /// <inheritdoc/>
    internal class WebhookProvider : IWebhookProvider
    {
        private readonly IEmmaApiAdapter apiAdapter;

        /// <inheritdoc cref="object.Object"/>
        public WebhookProvider(IEmmaApiAdapter apiAdapter)
        {
            this.apiAdapter = apiAdapter;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Webhook>> GetWebhooks()
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/webhooks"
            };

            return await apiAdapter.MakeRequest<List<Webhook>>(request);
        }

        /// <inheritdoc/>
        public async Task<Webhook> GetWebhookById(string webhookId)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/webhooks/{webhookId}"
            };
            request.AddUrlSegment("webhookId", webhookId);

            return await apiAdapter.MakeRequest<Webhook>(request);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WebhookEvents>> GetWebhookEvents()
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/webhooks/events"
            };

            return await apiAdapter.MakeRequest<List<WebhookEvents>>(request);
        }

        /// <inheritdoc/>
        public async Task<int> CreateWebhook(CreateWebhook webhook)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/webhooks",
            };
            request.AddJsonBody(webhook);

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <inheritdoc/>
        public async Task<int> UpdateWebhook(string webhookId, UpdateWebhook webhook)
        {
            RestRequest request = new RestRequest(Method.PUT)
            {
                Resource = "/{accountId}/webhooks/{webhookId}"
            };
            request.AddUrlSegment("webhookId", webhookId);
            request.AddJsonBody(webhook);

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteWebhookById(string webhookId)
        {
            RestRequest request = new RestRequest(Method.DELETE)
            {
                Resource = "/{accountId}/webhooks/{webhookId}"
            };
            request.AddUrlSegment("webhookId", webhookId);

            return await apiAdapter.MakeRequest<bool>(request);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAllWebhooks()
        {
            RestRequest request = new RestRequest(Method.DELETE)
            {
                Resource = "/{accountId}/webhooks"
            };

            return await apiAdapter.MakeRequest<bool>(request);
        }
    }
}
