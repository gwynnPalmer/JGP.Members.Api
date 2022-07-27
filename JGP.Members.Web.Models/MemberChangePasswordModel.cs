namespace JGP.Members.Web.Models;

using System.Text.Json.Serialization;

/// <summary>
///     Class MemberChangePasswordModel.
///     Implements the <see cref="MemberResetPasswordModel" />
/// </summary>
/// <seealso cref="MemberResetPasswordModel" />
public class MemberChangePasswordModel : MemberResetPasswordModel
{
    /// <summary>
    ///     Gets or sets the old password.
    /// </summary>
    /// <value>The old password.</value>
    [JsonPropertyName("oldPassword")]
    public string OldPassword { get; set; }
}