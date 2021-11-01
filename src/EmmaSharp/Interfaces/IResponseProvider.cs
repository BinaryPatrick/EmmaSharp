using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharp
{
    public interface IResponseProvider
    {
        Task<IEnumerable<ResponseClicks>> GetMailingClicks(string mailingId, string memberId = null, string linkId = null, uint? start = null, uint? end = null);
        Task<int> GetMailingClicksCount(string mailingId);
        Task<ResponseCustomerShare> GetMailingCustomerShare(string shareId);
        Task<IEnumerable<ResponseCustomerShareClicks>> GetMailingCustomerShareClicks(string mailingId);
        Task<IEnumerable<ResponseCustomerShare>> GetMailingCustomerShares(string mailingId);
        Task<IEnumerable<ResponseDeliveries>> GetMailingDelieveries(string mailingId, DeliveryType result = DeliveryType.All, uint? start = null, uint? end = null);
        Task<int> GetMailingDelieveriesCount(string mailingId, DeliveryType result = DeliveryType.All);
        Task<IEnumerable<ResponseForwards>> GetMailingForwards(string mailingId);
        Task<IEnumerable<ResponseGeneric>> GetMailingInProgress(string mailingId, uint? start = null, uint? end = null);
        Task<int> GetMailingInProgressCount(string mailingId);
        Task<IEnumerable<Link>> GetMailingLinks(string mailingId);
        Task<IEnumerable<ResponseGeneric>> GetMailingOpens(string mailingId, uint? start = null, uint? end = null);
        Task<int> GetMailingOpensCount(string mailingId);
        Task<IEnumerable<ResponseGeneric>> GetMailingOptouts(string mailingId, uint? start = null, uint? end = null);
        Task<int> GetMailingOptoutsCount(string mailingId);
        Task<Response> GetMailingResponse(string mailingId);
        Task<IEnumerable<ResponseGeneric>> GetMailingSends(string mailingId, uint? start = null, uint? end = null);
        Task<int> GetMailingSendsCount(string mailingId);
        Task<IEnumerable<ResponseShares>> GetMailingShares(string mailingId);
        Task<IEnumerable<ResponseSharesOverview>> GetMailingSharesOverview(string mailingId);
        Task<IEnumerable<ResponseSignups>> GetMailingSignups(string mailingId);
        Task<IEnumerable<ResponseSummary>> GetResponseSummary(DateRange? range = null, bool includeArchived = false);
        Task<IEnumerable<ResponseSummary>> GetResponseSummary(DateTime? date, bool includeArchived = false);
    }
}