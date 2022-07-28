namespace JGP.Members.Services;

using Core.Security;

/// <summary>
///     Interface IAuthenticationService
///     Implements the <see cref="IDisposable" />
/// </summary>
/// <seealso cref="IDisposable" />
public interface IAuthenticationService : IDisposable
{
    /// <summary>
    ///     Authenticate as an asynchronous operation.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A Task&lt;AuthenticationResult&gt; representing the asynchronous operation.</returns>
    Task<AuthenticationResult> AuthenticateAsync(LoginCommand command);
}