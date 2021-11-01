using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharp
{
    public interface IEmmaApiAdapter
    {
        Task<T> MakeRequest<T>(RestRequest request, uint? start = null, uint? end = null);
    }
}