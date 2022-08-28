namespace JGP.Members.Web.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Commands;

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
    [Required]
    [StringLength(12, MinimumLength = 8)]
    [JsonPropertyName("oldPassword")]
    public string OldPassword { get; set; }

    /// <summary>
    ///     Gets the change password command.
    /// </summary>
    /// <returns>ChangePasswordCommand.</returns>
    public ChangePasswordCommand GetChangePasswordCommand()
    {
        return new ChangePasswordCommand()
        {
            MemberId = MemberId,
            NewPassword = NewPassword,
            OldPassword = OldPassword
        };
    }
}