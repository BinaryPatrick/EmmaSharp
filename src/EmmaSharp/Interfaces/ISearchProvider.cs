using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharp
{
    public interface ISearchProvider
    {
        Task<int> CreateSavedSearch(CreateSearch search);
        Task<bool> DeleteSavedSearch(string searchId);
        Task<IEnumerable<Member>> GetMembersMatchingSearch(string searchId, uint? start = null, uint? end = null);
        Task<int> GetMembersMatchingSearchCount(string searchId);
        Task<Search> GetSearchDetails(string searchId, bool includeDeleted = false);
        Task<List<Search>> GetSearches(bool includeDeleted = false, uint? start = null, uint? end = null);
        Task<int> GetSearchesCount(bool includeDeleted = false);
        Task<bool> UpdateSavedSearch(string searchId, CreateSearch search);
    }
}