using System;
using RestSharp;
using RestSharp.Authenticators;

namespace EmmaSharper.Services
{
    internal class EmmaRestClientFactory : IEmmaRestClientFactory

    {
        private readonly EmmaOptions options;

        public EmmaRestClientFactory(EmmaOptions options)
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
