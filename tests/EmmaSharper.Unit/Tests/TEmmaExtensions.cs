using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EmmaSharper.Unit.Tests
{
    public class TEmmaExtensions
    {
        [Theory]
        [InlineData(typeof(EmmaOptions))]
        [InlineData(typeof(IEmmaRestClientFactory))]
        [InlineData(typeof(IEmmaApiAdapter))]
        [InlineData(typeof(IEmmaAutomationProvider))]
        [InlineData(typeof(IEmmaFieldsProvider))]
        [InlineData(typeof(IEmmaGroupProvider))]
        [InlineData(typeof(IEmmaMailingProvider))]
        [InlineData(typeof(IEmmaMemberProvider))]
        [InlineData(typeof(IEmmaResponseProvider))]
        [InlineData(typeof(IEmmaSearchProvider))]
        [InlineData(typeof(IEmmaSignupFormProvider))]
        [InlineData(typeof(IEmmaSubscriptionProvider))]
        [InlineData(typeof(IEmmaWebhookProvider))]
        public void AddEmmaApiProviders_WithAction_Should_Succeed(Type type)
        {
            // Arrange
            ServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddEmmaApiProviders(options =>
            {
                options.BaseUrl = "base-url";
                options.AccountId = "account-id";
                options.PublicKey = "public-key";
                options.SecretKey = "secret-key";
            });

            ServiceProvider provider = services.BuildServiceProvider();

            // Act
            object result = provider.GetRequiredService(type);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void AddEmmaApiProviders_WithConfiguration_Should_Succeed()
        {
            // Arrange
            IReadOnlyDictionary<string, string> values = new Dictionary<string, string>()
            {
                { "BaseUrl", "base-url" },
                { "AccountId", "account-id" },
                { "PublicKey", "public-key" },
                { "SecretKey", "secret-key" },
            };

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();

            ServiceCollection services = new ServiceCollection();
            services.AddEmmaApiProviders(configuration);
            ServiceProvider provider = services.BuildServiceProvider();

            // Act
            EmmaOptions options = provider.GetRequiredService<EmmaOptions>();

            // Assert
            options.BaseUrl.Should().Be("base-url");
            options.AccountId.Should().Be("account-id");
            options.PublicKey.Should().Be("public-key");
            options.SecretKey.Should().Be("secret-key");
        }
    }
}
