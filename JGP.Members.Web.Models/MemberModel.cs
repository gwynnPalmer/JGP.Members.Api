namespace JGP.Members.Web.Models
{
    using Core;
    using Core.Commands;

    /// <summary>
    ///     Class MemberModel.
    /// </summary>
    public class MemberModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberModel" /> class.
        /// </summary>
        public MemberModel()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberModel" /> class.
        /// </summary>
        /// <param name="member">The member.</param>
        public MemberModel(Member member)
        {
            CreatedOn = member.CreatedOn;
            CultureCode = member.CultureCode;
            DateLastLoggedIn = member.DateLastLoggedIn;
            EmailAddress = member.EmailAddress;
            FirstName = member.FirstName;
            Id = member.Id;
            IsEnabled = member.IsEnabled;
            LastName = member.LastName;
        }

        /// <summary>
        ///     Gets or sets the created on.
        /// </summary>
        /// <value>The created on.</value>
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        ///     Gets or sets the culture code.
        /// </summary>
        /// <value>The culture code.</value>
        public string CultureCode { get; set; }

        /// <summary>
        ///     Gets or sets the date last logged in.
        /// </summary>
        /// <value>The date last logged in.</value>
        public DateTimeOffset? DateLastLoggedIn { get; set; }

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
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        public bool IsEnabled { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets the create command.
        /// </summary>
        /// <returns>MemberCreateCommand.</returns>
        public MemberCreateCommand GetCreateCommand()
        {
            return new MemberCreateCommand
            {
                CultureCode = CultureCode,
                EmailAddress = EmailAddress,
                FirstName = FirstName,
                LastName = LastName
                //Password?
            };
        }

        /// <summary>
        ///     Gets the update command.
        /// </summary>
        /// <returns>MemberUpdateCommand.</returns>
        public MemberUpdateCommand GetUpdateCommand()
        {
            return new MemberUpdateCommand
            {
                Id = Id,
                CultureCode = CultureCode,
                EmailAddress = EmailAddress,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}