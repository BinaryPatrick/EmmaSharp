using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharp
{
    public interface ISubscriptionProvider
    {
        Task<Subscription> DeleteSubscription(string subscription_id);
        Task<Subscription> EditSubscrpition(SubscriptionNew subscription, string subscription_id);
        Task<Subscription> GetAccountSubscription(string subscription_id);
        Task<IEnumerable<Subscription>> GetAccountSubscritpions(bool includeDeletedOnly = false, bool includeDeleted = false);
        Task<IEnumerable<SubscriptionMembers>> GetOptOutSubscriptionMembers(string subscription_id, uint start = 0, uint end = 500);
        Task<IEnumerable<SubscriptionMembers>> GetSubscriptionMembers(string subscription_id, uint start = 0, uint end = 500);
        Task<bool> PostBulkImportSubscrpitions(SubscriptionImportBulk importId, string subscription_id);
        Task<bool> PostBulkMemberSubscrpitions(SubscriptionBulk memberIds, string subscription_id);
        Task<Subscription> PostNewSubscription(SubscriptionNew subscription);
    }
}