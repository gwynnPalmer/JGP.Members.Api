namespace JGP.Members.Core
{
    using JGP.Members.Core.Commands;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    ///     Class Member.
    /// </summary>
    public class Member
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Member" /> class.
        /// </summary>
        /// <param name="createCommand">The createCommand.</param>
        /// <exception cref="System.ArgumentNullException">command</exception>
        public Member(MemberCreateCommand createCommand)
        {
            _ = createCommand ?? throw new ArgumentNullException(nameof(createCommand));
            Id = Guid.NewGuid();
            IsEnabled = true;
            CreatedOn = DateTimeOffset.UtcNow;
            FailedLoginAttemptCount = 0;
            CultureCode = createCommand.CultureCode;
            EmailAddress = createCommand.EmailAddress;
            FirstName = createCommand.FirstName;
            LastName = createCommand.LastName;
            PasswordHash = createCommand.PasswordHash;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        /// <param name="registrationCommand">The registration command.</param>
        /// <exception cref="System.ArgumentNullException">registrationCommand</exception>
        public Member(MemberRegistrationCommand registrationCommand)
        {
            _ = registrationCommand ?? throw new ArgumentNullException(nameof(registrationCommand));
            Id = Guid.NewGuid();
            IsEnabled = true;
            CreatedOn = DateTimeOffset.UtcNow;
            FailedLoginAttemptCount = 0;
            CultureCode = registrationCommand.CultureCode;
            EmailAddress = registrationCommand.EmailAddress;
            FirstName = registrationCommand.FirstName;
            LastName = registrationCommand.LastName;
            PasswordHash = registrationCommand.PasswordHash;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        protected Member()
        {
            //
        }

        /// <summary>
        ///     Gets or sets the created on.
        /// </summary>
        /// <value>The created on.</value>
        public DateTimeOffset CreatedOn { get; protected set; }

        /// <summary>
        ///     Gets or sets the culture code.
        /// </summary>
        /// <value>The culture code.</value>
        public string CultureCode { get; protected set; }

        /// <summary>
        ///     Gets or sets the date last logged in.
        /// </summary>
        /// <value>The date last logged in.</value>
        public DateTimeOffset? DateLastLoggedIn { get; protected set; }

        /// <summary>
        ///     Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        public string EmailAddress { get; protected set; }

        /// <summary>
        ///     Gets or sets the failed login attempt count.
        /// </summary>
        /// <value>The failed login attempt count.</value>
        public int FailedLoginAttemptCount { get; protected set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; protected set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; protected set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        public bool IsEnabled { get; protected set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; protected set; }

        /// <summary>
        ///     Gets or sets the password hash.
        /// </summary>
        /// <value>The password hash.</value>
        public string PasswordHash { get; protected set; }

        #region DOMAIN METHODS

        /// <summary>
        ///     Sets the password hash.
        /// </summary>
        /// <param name="passwordHash">The password hash.</param>
        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            FailedLoginAttemptCount = 0;
        }

        /// <summary>
        ///     Disables this instance.
        /// </summary>
        public void Disable()
        {
            IsEnabled = false;
        }

        /// <summary>
        ///     Enables this instance.
        /// </summary>
        public void Enable()
        {
            IsEnabled = true;
        }

        /// <summary>
        ///     Registers the failed login.
        /// </summary>
        public void RegisterFailedLogin()
        {
            FailedLoginAttemptCount += 1;
        }

        /// <summary>
        ///     Registers the successful login.
        /// </summary>
        public void RegisterSuccessfulLogin()
        {
            FailedLoginAttemptCount = 0;
            DateLastLoggedIn = DateTimeOffset.UtcNow;
        }

        /// <summary>
        ///     Updates the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <exception cref="System.ArgumentNullException">command</exception>
        public void Update(MemberUpdateCommand command)
        {
            _ = command ?? throw new ArgumentNullException(nameof(command));
            if (command.Id != Id) return;

            CultureCode = command.CultureCode;
            EmailAddress = command.EmailAddress;
            FirstName = command.FirstName;
            LastName = command.LastName;
        }
        #endregion

        #region OVERRIDES & ESSENTIALS

        /// <summary>
        ///     Equalses the specified member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(Member? member)
        {
            if (member is null) return false;
            return Id == member.Id
                   && IsEnabled == member.IsEnabled
                   && CreatedOn == member.CreatedOn
                   && DateLastLoggedIn == member.DateLastLoggedIn
                   && FailedLoginAttemptCount == member.FailedLoginAttemptCount
                   && CultureCode == member.CultureCode
                   && EmailAddress == member.EmailAddress
                   && FirstName == member.FirstName
                   && LastName == member.LastName
                   && PasswordHash == member.PasswordHash;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return obj is Member member
                   && Equals(member);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            return JsonSerializer.Serialize(this, options);
        }

        #endregion
    }
}