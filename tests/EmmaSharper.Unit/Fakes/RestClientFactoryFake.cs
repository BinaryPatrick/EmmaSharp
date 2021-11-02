using Moq;
using RestSharp;

namespace EmmaSharper.Unit.Fakes
{
    public class RestClientFactoryFake : IRestClientFactory
    {
        public Mock<IRestClient> MockRestClient { get; } = new Mock<IRestClient>();

        public IRestClient GetRestClient()
            => MockRestClient.Object;
    }
}
