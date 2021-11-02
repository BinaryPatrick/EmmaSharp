using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EmmaSharper.Adapters;
using EmmaSharper.Unit.Fakes;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using Xunit;

namespace EmmaSharper.Unit.Tests
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
            options = new EmmaOptions()
            {
                AccountId = "account-id",
                PublicKey = "public-key",
                SecretKey = "secret-key",
            };
        }

        [Fact]
        public async Task MakeRequest_ShouldSucceed()
        {
            // Arrange
            string helloWorld = "Hello World";
            IRestResponse fakeResponse = new RestResponse
            {
                Content = JsonConvert.SerializeObject(helloWorld),
                StatusCode = HttpStatusCode.OK
            };

            IRestRequest executedRequest = null;
            clientFactoryFake.MockRestClient
                .Setup(x => x.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns<IRestRequest, CancellationToken>((request, token) =>
                {
                    executedRequest = request;
                    return Task.FromResult(fakeResponse);
                });

            EmmaApiAdapter adapter = new EmmaApiAdapter(logger, clientFactoryFake, options);
            RestRequest request = new RestRequest("/{accountId}/self", Method.GET);

            // Act
            string response = await adapter.MakeRequest<string>(request);

            // Assert
            response.Should().Be(helloWorld);
            executedRequest.Parameters.Should().HaveCount(1);
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
            IRestResponse fakeResponse = new RestResponse
            {
                StatusCode = status,
            };

            clientFactoryFake.MockRestClient
                .Setup(x => x.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
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
