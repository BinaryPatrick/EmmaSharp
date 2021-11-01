using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharp
{
    public interface ISignupFormProvider
    {
        Task<IEnumerable<SignupForm>> GetSignupForms();
    }
}