using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharp
{
    /// <summary>
    /// These endpoints allow you to create, edit, and delete searches. You can also retrieve the members matching 
    /// any search created in your account.
    /// </summary>
    internal class SearchProvider : ISearchProvider
    {
        private readonly IEmmaApiAdapter apiAdapter;

        public SearchProvider(IEmmaApiAdapter apiAdapter)
        {
            this.apiAdapter = apiAdapter;
        }

        /// <summary>Get a count of the number of saved searches</summary>
        /// <param name="includeDeleted">Optional flag to include deleted searches.</param>
        /// <returns>An array of searches.</returns>
        /// <remarks></remarks>
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

        /// <summary>Retrieve a list of saved searches</summary>
        /// <param name="includeDeleted">Optional flag to include deleted searches.</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of searches.</returns>
        /// <remarks></remarks>
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

        /// <summary>Get the details for a saved search</summary>
        /// <param name="searchId">Search identifier</param>
        /// <param name="includeDeleted">>Optional flag to include deleted searches.</param>
        /// <returns>A search.</returns>
        /// <remarks>Http404 if the search does not exist.</remarks>
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

        /// <summary>Create a saved search</summary>
        /// <param name="search">A name used to describe this search and a combination of search conditions, as described in the documentation.</param>
        /// <returns>The ID of the new search.</returns>
        /// <remarks>Http400 if the search is invalid.</remarks>
        public async Task<int> CreateSavedSearch(CreateSearch search)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/searches",
            };
            request.AddJsonBody(search);

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <summary>
        /// Update a saved search. No parameters are required, but either the name or criteria parameter must be present for an update to occur.
        /// </summary>
        /// <param name="searchId">Search identifier</param>
        /// <param name="search">A name used to describe this search and/or a combination of search conditions, as described in the documentation.</param>
        /// <returns>True if the update was successful</returns>
        /// <remarks>Http404 if the search does not exist. Http400 if the search criteria is invalid.</remarks>
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

        /// <summary>Delete a saved search. The member records referred to by the search are not affected</summary>
        /// <param name="searchId">Search identifier</param>
        /// <returns>True if the search is deleted.</returns>
        /// <remarks>Http404 if the search does not exist.</remarks>
        public async Task<bool> DeleteSavedSearch(string searchId)
        {
            RestRequest request = new RestRequest(Method.DELETE)
            {
                Resource = "/{accountId}/searches/{searchId}"
            };
            request.AddUrlSegment("searchId", searchId);

            return await apiAdapter.MakeRequest<bool>(request);
        }

        /// <summary>Get a count of the number of members matching the search</summary>
        /// <param name="searchId">Search identifier</param>
        /// <returns>An array of members.</returns>
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

        /// <summary>Get the members matching the search</summary>
        /// <param name="searchId">Search identifier</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of members.</returns>
        /// <remarks>Http404 if the search does not exist.</remarks>
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
