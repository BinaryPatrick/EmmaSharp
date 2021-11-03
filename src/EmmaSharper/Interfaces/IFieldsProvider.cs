﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharper
{
    /// <summary>
    /// Provides access to custom fields in your account. Of particular interest is the <see cref="ClearField(string)"/>
    /// method which lets you clear out all the data in a single field /// for all members in your account. This makes 
    /// it easy to re-initialize a dataset if you’re looking to correct an import error or syncing issue
    /// </summary>
    public interface IEmmaFieldsProvider
    {
        /// <summary>Gets number of fields for paging</summary>
        /// <param name="includeDeleted">Accepts True. Optional flag to include deleted fields</param>
        /// <returns>An array of fields.</returns>
        Task<int> ListFieldsCount(bool includeDeleted = false);

        /// <summary>
        /// Gets a list of this account's defined fields. Be sure to get a count of fields before accessing this method, 
        /// so you're aware of paging requirements
        /// </summary>
        /// <param name="includeDeleted">Accepts True. Optional flag to include deleted fields</param>
        /// <param name="start">Start paging record at.</param>
        /// <param name="end">End paging record at.</param>
        /// <returns>An array of fields.</returns>
        Task<IEnumerable<Field>> ListFields(bool includeDeleted = false, uint? start = null, uint? end = null);

        /// <summary>Gets the detailed information about a particular field</summary>
        /// <param name="fieldId">The Field Id of the field to retrieve.</param>
        /// <param name="includeDeleted">Accepts True. Optionally show a field even if it has been deleted.</param>
        /// <returns>A field.</returns>
        /// <remarks>Http404 if the field does not exist.</remarks>
        Task<Field> GetField(string fieldId, bool includeDeleted = false);

        /// <summary>Create a new field. There must not already be a field with this name</summary>
        /// <param name="field">The Field to be created.</param>
        /// <returns>A reference (Field ID as int) to the new field.</returns>
        Task<int> CreateField(CreateField field);

        /// <summary>Updates an existing field</summary>
        /// <param name="fieldId">The Field Id of the field to update.</param>
        /// <param name="field">The Field to be updated.</param>
        /// <returns>A reference (Field ID as int) to the updated field.</returns>
        Task<int> UpdateField(string fieldId, UpdateField field);

        /// <summary>Clear the member data for the specified field</summary>
        /// <param name="fieldId">The Field Id of the field to clear.</param>
        /// <returns>True if all of the member field data is deleted</returns>
        Task<bool> ClearField(string fieldId);

        /// <summary>Deletes a field</summary>
        /// <param name="fieldId">The Field Id of the field to delete.</param>
        /// <returns>True if the field is deleted, False otherwise.</returns>
        Task<bool> DeleteField(string fieldId);
    }
}