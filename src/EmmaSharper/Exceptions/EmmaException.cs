using System;
using RestSharp;

namespace EmmaSharper
{
    public class EmmaException : Exception
    {
        private readonly string message;

        public IRestResponse Response;

        public EmmaException(IRestResponse response)
        {
            Response = response;
            message = "Unexpected response status " + ((int)response.StatusCode).ToString() + " with body:\n" + response.Content;
        }

        public override string Message => message;
    }
}
