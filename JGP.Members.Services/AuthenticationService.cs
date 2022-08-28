﻿// ***********************************************************************
// Assembly         : JGP.Members.Services
// Author           : Joshua Gwynn-Palmer
// Created          : 07-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 08-28-2022
// ***********************************************************************
// <copyright file="AuthenticationService.cs" company="JGP.Members.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Services
{
    using System.Security.Claims;
    using Core;
    using Core.Security;
    using Data.EntityFramework;
    using Microsoft.EntityFrameworkCore;
    using Security;

    /// <summary>
    ///     Class AuthenticationService.
    ///     Implements the <see cref="IAuthenticationService" />
    /// </summary>
    /// <seealso cref="IAuthenticationService" />
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        ///     The member context
        /// </summary>
        private readonly IMemberContext _memberContext;

        /// <summary>
        ///     The password service
        /// </summary>
        private readonly IPasswordService _passwordService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationService" /> class.
        /// </summary>
        /// <param name="memberContext">The member context.</param>
        /// <param name="passwordService">The password service.</param>
        public AuthenticationService(IMemberContext memberContext, IPasswordService passwordService)
        {
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
        ///     Authenticate as an asynchronous operation.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A Task&lt;AuthenticationResult&gt; representing the asynchronous operation.</returns>
        public async Task<AuthenticationResult> AuthenticateAsync(LoginCommand command)
        {
            AuthenticationResult authenticationResult;
            var member = await _memberContext.Members.FirstOrDefaultAsync(m => m.EmailAddress == command.EmailAddress);

            if (member is null || !member.IsEnabled)
            {
                return AuthenticationResult.CreateFailedResult();
            }

            var result = _passwordService.Verify(command.Password, member.PasswordHash);

            switch (result.Outcome)
            {
                case VerificationOutcome.Success:
                    member.RegisterSuccessfulLogin();
                    authenticationResult = AuthenticationResult.CreateSuccessResult(member);
                    break;
                case VerificationOutcome.Failure:
                default:
                    member.RegisterFailedLogin();
                    authenticationResult = AuthenticationResult.CreateFailedResult();
                    break;
            }

            AddClaims(authenticationResult, member);
            await _memberContext.SaveChangesAsync();
            return authenticationResult;
        }

        /// <summary>
        ///     Adds the claims.
        /// </summary>
        /// <param name="authenticationResult">The authentication result.</param>
        /// <param name="member">The member.</param>
        private static void AddClaims(AuthenticationResult authenticationResult, Member member)
        {
            authenticationResult.Claims = new List<MemberAuthenticationClaim>
            {
                new(ClaimTypes.Role, "Member"),
                new(ClaimTypes.Name, $"{member.FirstName} {member.LastName}"),
                new(ClaimTypes.Email, member.EmailAddress),
                new(ClaimTypes.GivenName, member.FirstName),
                new(ClaimTypes.Surname, member.LastName),
                new("Id", member.Id.ToString())
            };
        }
    }
}