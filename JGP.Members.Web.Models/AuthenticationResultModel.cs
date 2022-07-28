// ***********************************************************************
// Assembly         : JGP.Members.Web.Models
// Author           : Joshua Gwynn-Palmer
// Created          : 07-28-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-28-2022
// ***********************************************************************
// <copyright file="AuthenticationResultModel.cs" company="JGP.Members.Web.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Web.Models
{
    using System.Text.Json.Serialization;
    using Core.Security;

    /// <summary>
    ///     Class AuthenticationResultModel.
    /// </summary>
    public class AuthenticationResultModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationResultModel" /> class.
        /// </summary>
        public AuthenticationResultModel()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationResultModel" /> class.
        /// </summary>
        /// <param name="authenticationResult">The authentication result.</param>
        public AuthenticationResultModel(AuthenticationResult authenticationResult)
        {
            IsAuthenticated = authenticationResult.IsAuthenticated;
            Claims = authenticationResult.Claims
                .Select(claim => new MemberAuthenticationClaimModel(claim))
                .ToList();
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        [JsonPropertyName("isAuthenticated")]
        public bool IsAuthenticated { get; set; }

        /// <summary>
        ///     Gets or sets the claims.
        /// </summary>
        /// <value>The claims.</value>
        [JsonPropertyName("claims")]
        public List<MemberAuthenticationClaimModel> Claims { get; set; } = new();
    }
}