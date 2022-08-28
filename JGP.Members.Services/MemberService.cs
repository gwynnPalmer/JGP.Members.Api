// ***********************************************************************
// Assembly         : JGP.Members.Services
// Author           : Joshua Gwynn-Palmer
// Created          : 07-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-27-2022
// ***********************************************************************
// <copyright file="MemberService.cs" company="JGP.Members.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Services
{
    using Core;
    using Core.Commands;
    using Data.EntityFramework;
    using JGP.Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Security;

    /// <summary>
    ///     Class MemberService.
    /// </summary>
    public class MemberService : IMemberService
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private readonly ILogger<MemberService> _logger;

        /// <summary>
        ///     The member context
        /// </summary>
        private readonly IMemberContext _memberContext;

        /// <summary>
        ///     The password service
        /// </summary>
        private readonly IPasswordService _passwordService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="memberContext">The member context.</param>
        /// <param name="passwordService">The password service.</param>
        public MemberService(ILogger<MemberService> logger, IMemberContext memberContext,
            IPasswordService passwordService)
        {
            _logger = logger;
            _memberContext = memberContext;
            _passwordService = passwordService;
        }

        #region DISPOSAL

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _memberContext.Dispose();
            _passwordService.Dispose();
        }

        #endregion

        /// <summary>
        ///     Change password as an asynchronous operation.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt> ChangePasswordAsync(Guid memberId, string currentPassword, string newPassword)
        {
            try
            {
                var member = await _memberContext.Members.FirstOrDefaultAsync(m => m.Id == memberId);
                if (member == null) return ActionReceipt.GetNotFoundReceipt();

                var result = _passwordService.Verify(currentPassword, member.PasswordHash);
                if (result.Outcome != VerificationOutcome.Success) return ActionReceipt.GetErrorReceipt("Password verification failed: " + result.Message);

                var newHash = _passwordService.Hash(newPassword);
                member.SetPasswordHash(newHash);

                var affectedTotal = await _memberContext.SaveChangesAsync();
                return ActionReceipt.GetSuccessReceipt(affectedTotal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update password for Member ID: {memberId}", memberId);
                return ActionReceipt.GetErrorReceipt(ex);
            }
        }

        /// <summary>
        ///     Change password as an asynchronous operation.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt> ChangePasswordAsync(string emailAddress, string newPassword)
        {
            try
            {
                var member = await _memberContext.Members.FirstOrDefaultAsync(m => m.EmailAddress == emailAddress);
                if (member == null) return ActionReceipt.GetNotFoundReceipt();

                var newHash = _passwordService.Hash(newPassword);
                member.SetPasswordHash(newHash);

                var affectedTotal = await _memberContext.SaveChangesAsync();
                return ActionReceipt.GetSuccessReceipt(affectedTotal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update password for Email Address: {emailAddress}", emailAddress);
                return ActionReceipt.GetErrorReceipt(ex);
            }
        }

        /// <summary>
        ///     Disable member as an asynchronous operation.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt> DisableMemberAsync(Guid memberId)
        {
            try
            {
                var member = await _memberContext.Members.FirstOrDefaultAsync(m => m.Id == memberId);
                if (member == null) return ActionReceipt.GetNotFoundReceipt();

                member.Disable();
                var affectedTotal = await _memberContext.SaveChangesAsync();
                return ActionReceipt.GetSuccessReceipt(affectedTotal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to disable member for Member ID: {memberId}", memberId);
                return ActionReceipt.GetErrorReceipt(ex);
            }
        }

        /// <summary>
        ///     Disable member as an asynchronous operation.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt> DisableMemberAsync(string emailAddress)
        {
            try
            {
                var member = await _memberContext.Members.FirstOrDefaultAsync(m => m.EmailAddress == emailAddress);
                if (member == null) return ActionReceipt.GetNotFoundReceipt();

                member.Disable();
                var affectedTotal = await _memberContext.SaveChangesAsync();
                return ActionReceipt.GetSuccessReceipt(affectedTotal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to disable member for Email Address: {emailAddress}", emailAddress);
                return ActionReceipt.GetErrorReceipt(ex);
            }
        }

        /// <summary>
        ///     Enable member as an asynchronous operation.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt> EnableMemberAsync(Guid memberId)
        {
            try
            {
                var member = await _memberContext.Members.FirstOrDefaultAsync(m => m.Id == memberId);
                if (member == null) return ActionReceipt.GetNotFoundReceipt();

                member.Enable();
                var affectedTotal = await _memberContext.SaveChangesAsync();
                return ActionReceipt.GetSuccessReceipt(affectedTotal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to enable member for Member ID: {memberId}", memberId);
                return ActionReceipt.GetErrorReceipt(ex);
            }
        }

        /// <summary>
        ///     Enable member as an asynchronous operation.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt> EnableMemberAsync(string emailAddress)
        {
            try
            {
                var member = await _memberContext.Members.FirstOrDefaultAsync(m => m.EmailAddress == emailAddress);
                if (member == null) return ActionReceipt.GetNotFoundReceipt();

                member.Enable();
                var affectedTotal = await _memberContext.SaveChangesAsync();
                return ActionReceipt.GetSuccessReceipt(affectedTotal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to enable member for Email Address: {emailAddress}", emailAddress);
                return ActionReceipt.GetErrorReceipt(ex);
            }
        }

        /// <summary>
        ///     Get member as an asynchronous operation.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>A Task&lt;Member&gt; representing the asynchronous operation.</returns>
        public async Task<Member?> GetMemberAsync(Guid memberId)
        {
            try
            {
                return await _memberContext.Members
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == memberId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get member for Member ID: {memberId}", memberId);
                return null;
            }
        }

        /// <summary>
        ///     Get member as an asynchronous operation.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>A Task&lt;Member&gt; representing the asynchronous operation.</returns>
        public async Task<Member?> GetMemberAsync(string emailAddress)
        {
            try
            {
                return await _memberContext.Members
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.EmailAddress == emailAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get member for Email Address: {emailAddress}", emailAddress);
                return null;
            }
        }

        /// <summary>
        ///     Update member as an asynchronous operation.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt> UpdateMemberAsync(MemberUpdateCommand command)
        {
            try
            {
                var member = await _memberContext.Members.FirstOrDefaultAsync(m => m.Id == command.Id);
                if (member == null) return ActionReceipt.GetNotFoundReceipt();

                member.Update(command);
                var affectedTotal = await _memberContext.SaveChangesAsync();
                return ActionReceipt.GetSuccessReceipt(affectedTotal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update member for Member ID: {command.Id}", command.Id);
                return ActionReceipt.GetErrorReceipt(ex);
            }
        }
    }
}