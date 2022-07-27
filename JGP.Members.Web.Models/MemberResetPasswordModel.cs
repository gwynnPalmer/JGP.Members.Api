namespace JGP.Members.Web.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    ///     Class MemberResetPasswordModel.
    /// </summary>
    public class MemberResetPasswordModel
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the new password.
        /// </summary>
        /// <value>The new password.</value>
        [JsonPropertyName("newPassword")]
        public string NewPassword { get; set; }
    }
}