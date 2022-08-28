namespace JGP.Members.Web.Models
{
    using System.ComponentModel.DataAnnotations;
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
        [Required]
        [JsonPropertyName("id")]
        public Guid MemberId { get; set; }

        /// <summary>
        ///     Gets or sets the new password.
        /// </summary>
        /// <value>The new password.</value>
        [Required]
        [StringLength(12, MinimumLength = 8)]
        [JsonPropertyName("newPassword")]
        public string NewPassword { get; set; }
    }
}