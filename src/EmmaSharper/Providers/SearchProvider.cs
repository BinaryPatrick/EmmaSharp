using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharper
{
    /// <inheritdoc/>
    internal class SearchProvider : ISearchProvider
    {
        private readonly IEmmaApiAdapter apiAdapter;

        public SearchProvider(IEmmaApiAdapter apiAdapter)
        {
            this.apiAdapter = apiAdapter;
        }

        /// <inheritdoc/>
        public async Task<int> GetSearchesCount(bool includeDeleted = false)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/searches"
            };
            request.AddParameter("count", "true");

            if (includeDeleted)
            {
                request.AddParameter("deleted", "true");
            }

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <inheritdoc/>
        public async Task<List<Search>> GetSearches(bool includeDeleted = false, uint? start = null, uint? end = null)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/searches"
            };

            if (includeDeleted)
            {
                request.AddParameter("deleted", "true");
            }

            return await apiAdapter.MakeRequest<List<Search>>(request, start, end);
        }

        /// <inheritdoc/>
        public async Task<Search> GetSearchDetails(string searchId, bool includeDeleted = false)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/searches/{searchId}"
            };
            request.AddUrlSegment("searchId", searchId);

            if (includeDeleted)
            {
                request.AddParameter("deleted", "true");
            }

            return await apiAdapter.MakeRequest<Search>(request);
        }

        /// <inheritdoc/>
        public async Task<int> CreateSavedSearch(CreateSearch search)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/searches",
            };
            request.AddJsonBody(search);

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateSavedSearch(string searchId, CreateSearch search)
        {
            RestRequest request = new RestRequest(Method.PUT)
            {
                Resource = "/{accountId}/searches/{searchId}"
            };
            request.AddUrlSegment("searchId", searchId);
            request.AddJsonBody(search);

            return await apiAdapter.MakeRequest<bool>(request);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteSavedSearch(string searchId)
        {
            RestRequest request = new RestRequest(Method.DELETE)
            {
                Resource = "/{accountId}/searches/{searchId}"
            };
            request.AddUrlSegment("searchId", searchId);

            return await apiAdapter.MakeRequest<bool>(request);
        }

        /// <inheritdoc/>
        public async Task<int> GetMembersMatchingSearchCount(string searchId)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/searches/{searchId}/members"
            };
            request.AddUrlSegment("searchId", searchId);
            request.AddParameter("count", "true");

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Member>> GetMembersMatchingSearch(string searchId, uint? start = null, uint? end = null)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/searches/{searchId}/members"
            };
            request.AddUrlSegment("searchId", searchId);

            return await apiAdapter.MakeRequest<List<Member>>(request, start, end);
        }
    }
}
