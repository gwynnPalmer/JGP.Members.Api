namespace JGP.Members.Services;

using Core;
using Core.Commands;
using JGP.Core.Services;

public interface IMemberService : IDisposable
{
    /// <summary>
    ///     Change password as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <param name="currentPassword">The current password.</param>
    /// <param name="newPassword">The new password.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> ChangePasswordAsync(Guid memberId, string currentPassword, string newPassword);

    /// <summary>
    ///     Change password as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <param name="newPassword">The new password.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> ChangePasswordAsync(string emailAddress, string newPassword);

    /// <summary>
    ///     Disable member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> DisableMemberAsync(Guid memberId);

    /// <summary>
    ///     Disable member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> DisableMemberAsync(string emailAddress);

    /// <summary>
    ///     Enable member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> EnableMemberAsync(Guid memberId);

    /// <summary>
    ///     Enable member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> EnableMemberAsync(string emailAddress);

    /// <summary>
    ///     Get member as an asynchronous operation.
    /// </summary>
    /// <param name="memberId">The member identifier.</param>
    /// <returns>A Task&lt;Member&gt; representing the asynchronous operation.</returns>
    Task<Member?> GetMemberAsync(Guid memberId);

    /// <summary>
    ///     Get member as an asynchronous operation.
    /// </summary>
    /// <param name="emailAddress">The email address.</param>
    /// <returns>A Task&lt;Member&gt; representing the asynchronous operation.</returns>
    Task<Member?> GetMemberAsync(string emailAddress);

    /// <summary>
    ///     Update member as an asynchronous operation.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
    Task<ActionReceipt> UpdateMemberAsync(MemberUpdateCommand command);
}