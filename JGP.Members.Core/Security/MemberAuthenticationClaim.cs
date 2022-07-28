namespace JGP.Members.Core.Security
{
    using System.Security.Claims;

    /// <summary>
    ///     Class MemberAuthenticationClaim.
    /// </summary>
    public class MemberAuthenticationClaim
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberAuthenticationClaim" /> class.
        /// </summary>
        public MemberAuthenticationClaim()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberAuthenticationClaim" /> class.
        /// </summary>
        /// <param name="claim">The claim.</param>
        public MemberAuthenticationClaim(Claim claim)
        {
            ClaimType = claim.Type;
            ClaimValue = claim.Value;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberAuthenticationClaim" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        public MemberAuthenticationClaim(string type, string value)
        {
            ClaimType = type;
            ClaimValue = value;
        }

        /// <summary>
        ///     Gets or sets the type of the claim.
        /// </summary>
        /// <value>The type of the claim.</value>
        public string ClaimType { get; set; }

        /// <summary>
        ///     Gets or sets the claim value.
        /// </summary>
        /// <value>The claim value.</value>
        public string ClaimValue { get; set; }
    }
}