using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharp
{
    /// <summary>With this endpoint, you can list all of your signup forms</summary>
    internal class SignupFormProvider : ISignupFormProvider
    {
        private readonly IEmmaApiAdapter apiAdapter;

        public SignupFormProvider(IEmmaApiAdapter apiAdapter)
        {
            this.apiAdapter = apiAdapter;
        }

        /// <summary>Gets a list of this account’s signup forms</summary>
        /// <returns>An array of signup forms.</returns>
        public async Task<IEnumerable<SignupForm>> GetSignupForms()
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/signup_forms"
            };

            return await apiAdapter.MakeRequest<List<SignupForm>>(request);
        }
    }
}
