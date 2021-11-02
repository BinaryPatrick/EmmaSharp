using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace EmmaSharper
{
    /// <inheritdoc/>
    internal class FieldsProvider : IFieldsProvider
    {
        private readonly IEmmaApiAdapter apiAdapter;

        /// <inheritdoc cref="object.Object"/>
        public FieldsProvider(IEmmaApiAdapter apiAdapter)
        {
            this.apiAdapter = apiAdapter;
        }

        /// <inheritdoc/>
        public async Task<int> ListFieldsCount(bool includeDeleted = false)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/fields"
            };
            request.AddParameter("count", "true");

            if (includeDeleted)
            {
                request.AddParameter("deleted", includeDeleted);
            }

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Field>> ListFields(bool includeDeleted = false, uint? start = null, uint? end = null)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/fields"
            };

            if (includeDeleted)
            {
                request.AddParameter("deleted", includeDeleted);
            }

            return await apiAdapter.MakeRequest<List<Field>>(request, start, end);
        }

        /// <inheritdoc/>
        public async Task<Field> GetField(string fieldId, bool includeDeleted = false)
        {
            RestRequest request = new RestRequest
            {
                Resource = "/{accountId}/fields/{fieldId}"
            };
            request.AddUrlSegment("fieldId", fieldId);

            if (includeDeleted)
            {
                request.AddParameter("deleted", includeDeleted);
            }

            return await apiAdapter.MakeRequest<Field>(request);
        }

        /// <inheritdoc/>
        public async Task<int> CreateField(CreateField field)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/fields",
            };
            request.AddJsonBody(field);

            return await apiAdapter.MakeRequest<int>(request);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteField(string fieldId)
        {
            RestRequest request = new RestRequest(Method.DELETE)
            {
                Resource = "/{accountId}/fields/{fieldId}"
            };
            request.AddUrlSegment("fieldId", fieldId);

            return await apiAdapter.MakeRequest<bool>(request);
        }

        /// <inheritdoc/>
        public async Task<bool> ClearField(string fieldId)
        {
            RestRequest request = new RestRequest(Method.POST)
            {
                Resource = "/{accountId}/fields/{fieldId}/clear"
            };
            request.AddUrlSegment("fieldId", fieldId);

            return await apiAdapter.MakeRequest<bool>(request);
        }

        /// <inheritdoc/>
        public async Task<int> UpdateField(string fieldId, UpdateField field)
        {
            RestRequest request = new RestRequest(Method.PUT)
            {
                Resource = "/{accountId}/fields/{fieldId}"
            };
            request.AddUrlSegment("fieldId", fieldId);
            request.AddJsonBody(field);

            return await apiAdapter.MakeRequest<int>(request);
        }
    }
}
