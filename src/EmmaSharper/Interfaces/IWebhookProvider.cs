﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharper
{
    /// <summary>Provides access to webhooks</summary>
    public interface IEmmaWebhookProvider
    {
        /// <summary>Create an new webhook</summary>
        /// <param name="webhook">The webhook to be created.</param>
        /// <returns>The ID of the newly created webhook.</returns>@Html.Raw(breadcrumb.Item3)
        Task<int> CreateWebhook(CreateWebhook webhook);

        /// <summary>Delete all webhooks registered for an account</summary>
        /// <returns>True if the webhook deleted successfully.</returns>
        Task<bool> DeleteAllWebhooks();

        /// <summary>Deletes an existing webhook</summary>
        /// <param name="webhookId">The ID of the Webhook to delete.</param>
        /// <returns>True if the webhook deleted successfully.</returns>
        Task<bool> DeleteWebhookById(string webhookId);

        /// <summary>Get information for a specific webhook belonging to a specific account</summary>
        /// <param name="webhookId">The ID of the Webhook to return.</param>
        /// <returns>Details for a single webhook</returns>
        Task<Webhook> GetWebhookById(string webhookId);

        /// <summary>Get a listing of all event types that are available for webhooks</summary>
        /// <returns>A list of event types and descriptions</returns>
        Task<IEnumerable<WebhookEvents>> GetWebhookEvents();

        /// <summary>Get a basic listing of all webhooks associated with an account</summary>
        /// <returns>A list of webhooks that belong to the given account.</returns>
        Task<IEnumerable<Webhook>> GetWebhooks();

        /// <summary>Update an existing webhook</summary>
        /// <param name="webhookId">The ID of the Webhook to update.</param>
        /// <param name="webhook">The webhook parameters to be updated.</param>
        /// <returns>The id of the updated webhook, or False if the update failed.</returns>
        Task<int> UpdateWebhook(string webhookId, UpdateWebhook webhook);
    }
}