namespace JGP.Members.Core.Commands;

/// <summary>
///     Class MemberUpdateCommand.
/// </summary>
public class MemberUpdateCommand
{
    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public Guid Id { get; set; }

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
}