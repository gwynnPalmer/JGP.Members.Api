
namespace JGP.Members.Core.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    ///     Class AuthenticationResult.
    /// </summary>
    public class AuthenticationResult
    {
        /// <summary>
        ///     Gets or sets the culture code.
        /// </summary>
        /// <value>The culture code.</value>
        [JsonPropertyName("cultureCode")]
        public string CultureCode { get; set; }

        /// <summary>
        ///     Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the member identifier.
        /// </summary>
        /// <value>The member identifier.</value>
        [JsonPropertyName("memberId")]
        public Guid? MemberId { get; set; }

        /// <summary>
        ///     Gets or sets the claims.
        /// </summary>
        /// <value>The claims.</value>
        [JsonPropertyName("claims")]
        public List<MemberAuthenticationClaim> Claims { get; set; } = new();

        /// <summary>
        ///     Creates the failed result.
        /// </summary>
        /// <returns>AuthenticationResult.</returns>
        public static AuthenticationResult CreateFailedResult()
        {
            return new AuthenticationResult
            {
                IsSuccess = false
            };
        }

        /// <summary>
        ///     Creates the success result.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>AuthenticationResult.</returns>
        /// <exception cref="System.ArgumentNullException">member</exception>
        public static AuthenticationResult CreateSuccessResult(Member member)
        {
            _ = member ?? throw new ArgumentNullException(nameof(member));

            return new AuthenticationResult
            {
                IsSuccess = true,
                MemberId = member.Id,
                EmailAddress = member.EmailAddress,
                FirstName = member.FirstName,
                LastName = member.LastName,
                CultureCode = member.CultureCode
            };
        }
    }
}