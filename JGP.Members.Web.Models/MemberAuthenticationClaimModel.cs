// ***********************************************************************
// Assembly         : JGP.Members.Web.Models
// Author           : Joshua Gwynn-Palmer
// Created          : 07-28-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-28-2022
// ***********************************************************************
// <copyright file="MemberAuthenticationClaimModel.cs" company="JGP.Members.Web.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Web.Models
{
    using System.Text.Json.Serialization;
    using Core.Security;

    /// <summary>
    ///     Class MemberAuthenticationClaimModel.
    /// </summary>
    public class MemberAuthenticationClaimModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberAuthenticationClaimModel" /> class.
        /// </summary>
        public MemberAuthenticationClaimModel()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberAuthenticationClaimModel" /> class.
        /// </summary>
        /// <param name="claim">The claim.</param>
        public MemberAuthenticationClaimModel(MemberAuthenticationClaim claim)
        {
            ClaimType = claim.ClaimType;
            ClaimValue = claim.ClaimValue;
        }

        /// <summary>
        ///     Gets or sets the type of the claim.
        /// </summary>
        /// <value>The type of the claim.</value>
        [JsonPropertyName("claimType")]
        public string? ClaimType { get; set; }

        /// <summary>
        ///     Gets or sets the claim value.
        /// </summary>
        /// <value>The claim value.</value>
        [JsonPropertyName("claimValue")]
        public string? ClaimValue { get; set; }
    }
}