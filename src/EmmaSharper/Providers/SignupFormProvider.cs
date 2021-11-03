using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharper
{
    /// <inheritdoc/>
    internal class SignupFormProvider : IEmmaSignupFormProvider
    {
        private readonly IEmmaApiAdapter apiAdapter;

        /// <inheritdoc cref="object.Object"/>
        public SignupFormProvider(IEmmaApiAdapter apiAdapter)
        {
            this.apiAdapter = apiAdapter;
        }


        /// <inheritdoc/>
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
