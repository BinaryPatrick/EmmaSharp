using RestSharp;

namespace EmmaSharper
{
    public interface IRestClientFactory
    {
        IRestClient GetRestClient();
    }
}