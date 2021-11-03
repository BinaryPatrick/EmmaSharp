using RestSharp;

namespace EmmaSharper
{
    public interface IEmmaRestClientFactory
    {
        IRestClient GetRestClient();
    }
}