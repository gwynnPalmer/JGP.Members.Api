namespace JGP.Members.Core.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    ///     Class AuthenticationRequest.
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>
        ///     Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}