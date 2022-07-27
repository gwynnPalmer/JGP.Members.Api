namespace JGP.Members.Core.Commands;

/// <summary>
///     Class MemberCreateCommand.
/// </summary>
public class MemberCreateCommand
{
    /// <summary>
    ///     Gets or sets the culture code.
    /// </summary>
    /// <value>The culture code.</value>
    public string CultureCode { get; set; }

    /// <summary>
    ///     Gets or sets the email address.
    /// </summary>
    /// <value>The email address.</value>
    public string EmailAddress { get; set; }

    /// <summary>
    ///     Gets or sets the first name.
    /// </summary>
    /// <value>The first name.</value>
    public string FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the last name.
    /// </summary>
    /// <value>The last name.</value>
    public string LastName { get; set; }

    /// <summary>
    ///     Gets or sets the password hash.
    /// </summary>
    /// <value>The password hash.</value>
    public string PasswordHash { get; set; }
}