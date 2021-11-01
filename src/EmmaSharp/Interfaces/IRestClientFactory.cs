using RestSharp;

namespace EmmaSharp
{
    public interface IRestClientFactory
    {
        IRestClient GetRestClient();
    }
}