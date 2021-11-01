using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmmaSharp
{
    public interface IMemberProvider
    {
        Task<IEnumerable<int>> AddMemberToGroups(string memberId, List<int> groupIds);
        Task<MembersAdd> AddNewMembers(AddMembers members);
        Task<MemberAdd> AddOrUpdateSingleMember(AddMember member);
        Task<bool> ChangeMemberStatus(ChangeStatus status);
        Task<bool> CopyMembersIntoStatusGroup(string groupId, CopyStatus status);
        Task<bool> DeleteAllMembers(MemberStatusShort memberStatusId);
        Task<bool> DeleteMember(string memberId);
        Task<bool> DeleteMembers(DeleteMembers members);
        Task<IEnumerable<Import>> GetAllImports(uint? start = null, uint? end = null);
        Task<int> GetAllImportsCount();
        Task<Import> GetImportInformation(string importId);
        Task<Member> GetMember(string memberId, bool includeDeleted = false);
        Task<Member> GetMemberByEmail(string memberEmail, bool includeDeleted = false);
        Task<int> GetMemberCount(bool includeDeleted = false);
        Task<IEnumerable<Group>> GetMemberGroups(string memberId);
        Task<IEnumerable<MailingHistory>> GetMemberMailingHistory(string memberId, uint? start = null, uint? end = null);
        Task<int> GetMemberMailingHistoryCount(string memberId);
        Task<IEnumerable<MemberOptout>> GetMemberOptout(string memberId);
        Task<IEnumerable<ImportMembers>> GetMembersAffectedByImport(string importId, uint? start = null, uint? end = null);
        Task<int> GetMembersAffectedByImportCount(string importId);
        Task<IEnumerable<Member>> ListMembers(bool includeDeleted = false, uint? start = null, uint? end = null);
        Task<MemberSignup> MemberSignup(SignupMember member);
        Task<bool> RemoveMemberFromAllGroups(string memberId);
        Task<IEnumerable<int>> RemoveMemberFromGroups(string memberId, List<int> groupIds);
        Task<bool> RemoveMembersFromGroups(RemoveMemberGroups groups);
        Task<bool> UpdateMemberToOptoutByEmail(string memberEmail);
        Task<bool> UpdateSingleMemberInformation(string memberId, UpdateMember member);
        Task<bool> UpdateStatusOfGroupMembersBasedOnCurrentStatus(MemberStatusShort statusFrom, MemberStatusShort statusTo, string groupId = null);
    }
}