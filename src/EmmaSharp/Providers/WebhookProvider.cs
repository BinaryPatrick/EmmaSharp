using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharp
{
    internal class WebhookProvider : IWebhookProvider
    {
        private readonly IEmmaApiAdapter apiAdapter;

        public WebhookProvider(IEmmaApiAdapter apiAdapter)
        {
            this.apiAdapter = apiAdapter;
        }

        /// <summary>Get a basic listing of all webhooks associated with an account</summary>
        /// <returns>A list of webhooks that belong to the given account.</returns>
        public async Task<IEnumerable<Webhook>> GetWebhooks()
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/webhooks"
            };

            return await apiAdapter.MakeRequest<List<Webhook>>(request);
        }

        /// <summary>Get information for a specific webhook belonging to a specific account</summary>
        /// <param name="webhookId">The ID of the Webhook to return.</param>
        /// <returns>Details for a single webhook</returns>
        public async Task<Webhook> GetWebhookById(string webhookId)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/webhooks/{webhookId}"
            };
            request.AddUrlSegment("webhookId", webhookId);

            return await apiAdapter.MakeRequest<Webhook>(request);
        }

        /// <summary>Get a listing of all event types that are available for webhooks</summary>
        /// <returns>A list of event types and descriptions</returns>
        public async Task<IEnumerable<WebhookEvents>> GetWebhookEvents()
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/webhooks/events"
            };

            return await apiAdapter.MakeRequest<List<WebhookEvents>>(request);
        }

        /// <summary>Create an new webhook</summary>
        /// <param name="webhook">The webhook to be created.</param>
        /// <returns>The ID of the newly created webhook.</returns>@Html.Raw(breadcrumb.Item3)
        public async Task<int> CreateWebhook(CreateWebhook webhook)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/webhooks",
            };
            request.AddJsonBody(webhook);

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <summary>Update an existing webhook</summary>
        /// <param name="webhookId">The ID of the Webhook to update.</param>
        /// <param name="webhook">The webhook parameters to be updated.</param>
        /// <returns>The id of the updated webhook, or False if the update failed.</returns>
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

        /// <summary>Deletes an existing webhook</summary>
        /// <param name="webhookId">The ID of the Webhook to delete.</param>
        /// <returns>True if the webhook deleted successfully.</returns>
        public async Task<bool> DeleteWebhookById(string webhookId)
        {
            RestRequest request = new RestRequest(Method.DELETE)
            {
                Resource = "/{accountId}/webhooks/{webhookId}"
            };
            request.AddUrlSegment("webhookId", webhookId);

            return await apiAdapter.MakeRequest<bool>(request);
        }

        /// <summary>Delete all webhooks registered for an account</summary>
        /// <returns>True if the webhook deleted successfully.</returns>
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
