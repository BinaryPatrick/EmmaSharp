using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EmmaSharp.Adapters;
using EmmaSharp.Unit.Fakes;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using Xunit;

namespace EmmaSharp.Unit.Tests
{
    public class TEmmaApiAdapter
    {
        private readonly RestClientFactoryFake clientFactoryFake;
        private readonly ILogger<EmmaApiAdapter> logger;
        private readonly EmmaOptions options;

        public TEmmaApiAdapter()
        {
            ServiceProvider services = TestingExtensions.GetBaseServices().BuildServiceProvider();
            logger = services.GetRequiredService<ILogger<EmmaApiAdapter>>();
            clientFactoryFake = new RestClientFactoryFake();
            options = new EmmaOptions();
        }

        [Fact]
        public async Task MakeRequest_ShouldSucceed()
        {
            // Arrange
            string helloWorld = "Hello World";
            IRestResponse<string> fakeResponse = new RestResponse<string>
            {
                Content = JsonConvert.SerializeObject(helloWorld),
                StatusCode = HttpStatusCode.OK
            };

            clientFactoryFake.MockRestClient
                .Setup(x => x.ExecuteAsync<string>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(fakeResponse));

            EmmaApiAdapter adapter = new EmmaApiAdapter(logger, clientFactoryFake, options);
            RestRequest request = new RestRequest("https://google.com", Method.GET);

            // Act
            string response = await adapter.MakeRequest<string>(request);

            // Assert
            response.Should().Be(helloWorld);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.ServiceUnavailable)]
        public async Task MakeRequest_ShouldThrowException(HttpStatusCode status)
        {
            // Arrange
            IRestResponse<string> fakeResponse = new RestResponse<string>
            {
                StatusCode = status,
            };

            clientFactoryFake.MockRestClient
                .Setup(x => x.ExecuteAsync<string>(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(fakeResponse));

            EmmaApiAdapter adapter = new EmmaApiAdapter(logger, clientFactoryFake, options);
            RestRequest request = new RestRequest("https://google.com", Method.GET);
            EmmaException exception = null;

            // Act
            try
            {
                string response = await adapter.MakeRequest<string>(request);
            }
            catch (EmmaException ex)
            {
                exception = ex;
            }

            // Assert
            exception.Should().NotBeNull();
        }
    }
}
