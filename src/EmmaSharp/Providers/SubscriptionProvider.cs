using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharp
{
    internal class SubscriptionProvider : ISubscriptionProvider
    {
        private readonly IEmmaApiAdapter apiAdapter;

        public SubscriptionProvider(IEmmaApiAdapter apiAdapter)
        {
            this.apiAdapter = apiAdapter;
        }

        /// <summary>Get a list of all subscriptions in an account</summary>
        /// <returns>A list of subscriptions in an account along with related information, including member count and subscription ID.</returns>
        /// <param name="includeDeletedOnly">true or false. Returns deleted subscriptions only. Optional, defaults to false.</param>
        /// <param name="includeDeleted">true or false. Returns deleted subscriptions along with active. Optional, defaults to false.</param>
        public async Task<IEnumerable<Subscription>> GetAccountSubscritpions(bool includeDeletedOnly = false, bool includeDeleted = false)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/subscriptions"
            };

            if (includeDeletedOnly)
            {
                request.AddParameter("deleted_only", includeDeletedOnly);
            }

            if (includeDeleted)
            {
                request.AddParameter("include_deleted", includeDeleted);
            }

            return await apiAdapter.MakeRequest<List<Subscription>>(request);
        }

        /// <summary>Get detailed information for a specific subscription</summary>
        /// <returns>Information about a subscription.</returns>
        /// <param name="subscription_id">URL segment for the subscription ID to query details on</param>
        public async Task<Subscription> GetAccountSubscription(string subscription_id)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/subscriptions/{subscriptionId}"
            };
            request.AddUrlSegment("subscriptionId", subscription_id);

            return await apiAdapter.MakeRequest<Subscription>(request);
        }

        /// <summary>Get a list of member IDs for members subscribed to a specific subscription</summary>
        /// <returns>A list of member IDs.</returns>
        /// <param name="subscription_id">URL segment for the subscription ID to query details on</param>
        /// <param name="start">Pagination: start page. Defaults to first page (e.g. 0).</param>
        /// <param name="end">Pagination: end page. Defaults to first page (e.g. 500).</param>
        public async Task<IEnumerable<SubscriptionMembers>> GetSubscriptionMembers(string subscription_id, uint start = 0, uint end = 500)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/subscriptions/{subscriptionId}/members"
            };
            request.AddUrlSegment("subscriptionId", subscription_id);

            return await apiAdapter.MakeRequest<List<SubscriptionMembers>>(request, start, end);
        }

        /// <summary>Get a list of member IDs for members who have opted out of a specific subscription</summary>
        /// <returns>A list of member IDs.</returns>
        /// <param name="subscription_id">URL segment for the subscription ID to query details on</param>
        /// <param name="start">Pagination: start page. Defaults to first page (e.g. 0).</param>
        /// <param name="end">Pagination: end page. Defaults to first page (e.g. 500).</param>
        public async Task<IEnumerable<SubscriptionMembers>> GetOptOutSubscriptionMembers(string subscription_id, uint start = 0, uint end = 500)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/subscriptions/{subscriptionId}/optouts"
            };
            request.AddUrlSegment("subscriptionId", subscription_id);

            return await apiAdapter.MakeRequest<List<SubscriptionMembers>>(request, start, end);
        }

        /// <summary>Create a subscription</summary>
        /// <returns> Information about the created subscription, including the subscription ID.</returns>
        /// <param name="subscription">Name and description of the new subscription to create</param>
        public async Task<Subscription> PostNewSubscription(SubscriptionNew subscription)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/subscriptions",
            };
            request.AddJsonBody(subscription);

            return await apiAdapter.MakeRequest<Subscription>(request);
        }

        /// <summary>Bulk subscribe members to a subscription using a list of member IDs</summary>
        /// <returns>True if successful.</returns>
        /// <param name="memberIds">List of memberIDs</param>
        /// <param name="subscription_id">subscription id</param>
        public async Task<bool> PostBulkMemberSubscrpitions(SubscriptionBulk memberIds, string subscription_id)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/subscriptions/{subscriptionId}/members/bulk"
            };

            request.AddUrlSegment("subscriptionId", subscription_id);
            request.AddJsonBody(memberIds);

            return await apiAdapter.MakeRequest<bool>(request);
        }

        /// <summary>Bulk subscribe members to a subscription using the import ID of all members</summary>
        /// <returns>True if successful.</returns>
        /// <param name="importId">import ID to bulk subscribe</param>
        /// <param name="subscription_id">subscription id</param>
        public async Task<bool> PostBulkImportSubscrpitions(SubscriptionImportBulk importId, string subscription_id)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/subscriptions/{subscriptionId}/members/bulk"
            };

            request.AddUrlSegment("subscriptionId", subscription_id);
            request.AddJsonBody(importId);

            return await apiAdapter.MakeRequest<bool>(request);
        }


        /// <summary>Edit a subscription's name or description</summary>
        /// <returns>Information about the updated subscription.Limited to name and description.</returns>
        /// <param name="subscription">Name and description of the subscription text to update. Visible in the Subscription Center.</param>
        /// <param name="subscription_id ">the id to update</param>
        public async Task<Subscription> EditSubscrpition(SubscriptionNew subscription, string subscription_id)
        {
            RestRequest request = new RestRequest(Method.PUT)
            {
                Resource = "/{accountId}/subscriptions/{subscriptionId}"
            };

            request.AddUrlSegment("subscriptionId", subscription_id);
            request.AddJsonBody(subscription);

            return await apiAdapter.MakeRequest<Subscription>(request);
        }

        /// <summary>Delete a subscription</summary>
        /// <returns>Information about the subscription, including the date and time it was deleted.</returns>
        /// <param name="subscription_id ">the id to update</param>
        public async Task<Subscription> DeleteSubscription(string subscription_id)
        {
            RestRequest request = new RestRequest(Method.DELETE)
            {
                Resource = "/{accountId}/subscriptions/{subscriptionId}"
            };
            request.AddUrlSegment("subscriptionId", subscription_id);

            return await apiAdapter.MakeRequest<Subscription>(request);
        }
    }
}
