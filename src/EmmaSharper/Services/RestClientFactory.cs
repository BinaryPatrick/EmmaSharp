using System;
using RestSharp;
using RestSharp.Authenticators;

namespace EmmaSharper.Services
{
    internal class RestClientFactory : IRestClientFactory
    {
        private readonly EmmaOptions options;

        public RestClientFactory(EmmaOptions options)
        {
            this.options = options;
        }

        public IRestClient GetRestClient()
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri(options.BaseUrl),
                Authenticator = new HttpBasicAuthenticator(options.PublicKey, options.SecretKey)
            };

            return client;
        }
    }
}
