using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharp
{
    public interface IWebhookProvider
    {
        Task<int> CreateWebhook(CreateWebhook webhook);
        Task<bool> DeleteAllWebhooks();
        Task<bool> DeleteWebhookById(string webhookId);
        Task<Webhook> GetWebhookById(string webhookId);
        Task<IEnumerable<WebhookEvents>> GetWebhookEvents();
        Task<IEnumerable<Webhook>> GetWebhooks();
        Task<int> UpdateWebhook(string webhookId, UpdateWebhook webhook);
    }
}