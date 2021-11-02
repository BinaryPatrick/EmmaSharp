using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharper
{
    /// <summary>Provides access to automation APIs</summary>
    public interface IAutomationProvider
    {
        /// <summary>Gets detailed information about a single workflow</summary>
        /// <param name="workflowId">The ID of the Workflow to return.</param>
        /// <returns>A single workflow if one exists</returns> 
        Task<Workflow> GetWorkflowById(string workflowId);

        /// <summary>Gets a count of this account’s automation workflows.</summary>
        /// <returns>A count of automation workflows in the given account.</returns>
        Task<WorkflowCount> GetWorkflowCounts();

        /// <summary>Gets a list of this account’s automation workflows.</summary>
        /// <returns>A list of automation workflows in the given account.</returns>
        Task<IEnumerable<Workflow>> GetWorkflows();
    }
}