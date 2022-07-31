// ***********************************************************************
// Assembly         : JGP.Members.Web.Proxy
// Author           : Joshua Gwynn-Palmer
// Created          : 07-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-31-2022
// ***********************************************************************
// <copyright file="IdentityApiHelper.cs" company="JGP.Members.Web.Proxy">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Web.Proxy
{
    using System.Net;
    using System.Net.Http.Json;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Api.KeyManagement.Authentication;
    using JGP.Core.Services;
    using JGP.Core.Services.Extensions.Web;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Security;

    /// <summary>
    ///     Class IdentityApiHelper.
    /// </summary>
    public class IdentityApiHelper : IIdentityApiHelper
    {
        /// <summary>
        ///     The authentication path
        /// </summary>
        private const string AuthenticationPath = "v1/authentication";

        /// <summary>
        ///     The member path
        /// </summary>
        private const string MemberPath = "v1/member";

        /// <summary>
        ///     The password path
        /// </summary>
        private const string PasswordPath = "v1/password";

        /// <summary>
        ///     The registration path
        /// </summary>
        private const string RegistrationPath = "v1/registration";

        /// <summary>
        ///     The service name
        /// </summary>
        private const string ServiceName = "Members";

        /// <summary>
        ///     The json options
        /// </summary>
        private static readonly JsonSerializerOptions? JsonOptions;

        /// <summary>
        ///     The HTTP client
        /// </summary>
        private static HttpClient? _httpClient;

        /// <summary>
        ///     The logger
        /// </summary>
        private readonly ILogger<IdentityApiHelper> _logger;

        /// <summary>
        ///     Initializes static members of the <see cref="IdentityApiHelper" /> class.
        /// </summary>
        static IdentityApiHelper()
        {
            JsonOptions = new JsonSerializerOptions();
            JsonOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            JsonOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            JsonOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            JsonOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="IdentityApiHelper" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="apiOptions">The API options.</param>
        /// <exception cref="System.InvalidOperationException">No endpoint found for service {ServiceName}</exception>
        public IdentityApiHelper(ILogger<IdentityApiHelper> logger, IOptions<ApiConfiguration> apiOptions)
        {
            _logger = logger;

            if (_httpClient != null) return;

            var config = apiOptions.Value;
            var endpoint = config.Services.FirstOrDefault(service => service.ServiceName == ServiceName);
            if (endpoint == null)
            {
                throw new InvalidOperationException($"No endpoint found for service {ServiceName}");
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(endpoint.Url!)
            };
            _httpClient.DefaultRequestHeaders.Add(ApiKeyConstants.ApiKeyHeaderName, endpoint.ApiKey);
        }

        #region AUTHENTICATION

        /// <summary>
        ///     Authenticate as an asynchronous operation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task&lt;AuthenticationResultModel&gt; representing the asynchronous operation.</returns>
        public async Task<AuthenticationResultModel?> AuthenticateAsync(LoginModel model)
        {
            var response = await SendPostMessageAsync(model, $"{AuthenticationPath}/authenticate");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<AuthenticationResultModel>(JsonOptions);
        }

        #endregion

        #region REGISTRATION

        /// <summary>
        ///     Register member as an asynchronous operation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt?> RegisterMemberAsync(MemberRegistrationModel model)
        {
            var response = await SendPostMessageAsync(model, $"{RegistrationPath}/register");
            return await response.ToActionReceiptAsync();
        }

        #endregion

        #region MEMBERS

        /// <summary>
        ///     Change password as an asynchronous operation.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt?> ChangePasswordAsync(string emailAddress, string password)
        {
            var response =
                await SendPostMessageAsync(null, $"{MemberPath}/setpassword/{emailAddress}?password={password}");
            return await response.ToActionReceiptAsync();
        }

        /// <summary>
        ///     Disable member as an asynchronous operation.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt?> DisableMemberAsync(string emailAddress)
        {
            var response = await SendPostMessageAsync(null, $"{MemberPath}/email/disable/{emailAddress}");
            return await response.ToActionReceiptAsync();
        }

        /// <summary>
        ///     Disable member as an asynchronous operation.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt?> DisableMemberAsync(Guid memberId)
        {
            var response = await SendPostMessageAsync(null, $"{MemberPath}/id/disable/{memberId}");
            return await response.ToActionReceiptAsync();
        }

        /// <summary>
        ///     Enable member as an asynchronous operation.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt?> EnableMemberAsync(string emailAddress)
        {
            var response = await SendPostMessageAsync(null, $"{MemberPath}/email/enable/{emailAddress}");
            return await response.ToActionReceiptAsync();
        }

        /// <summary>
        ///     Enable member as an asynchronous operation.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>A Task&lt;ActionReceipt&gt; representing the asynchronous operation.</returns>
        public async Task<ActionReceipt?> EnableMemberAsync(Guid memberId)
        {
            var response = await SendPostMessageAsync(null, $"{MemberPath}/id/enable/{memberId}");
            return await response.ToActionReceiptAsync();
        }

        /// <summary>
        ///     Get member as an asynchronous operation.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>A Task&lt;MemberModel&gt; representing the asynchronous operation.</returns>
        public async Task<MemberModel?> GetMemberAsync(string emailAddress)
        {
            var response = await SendGetMessageAsync($"{MemberPath}/email/{emailAddress}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<MemberModel>(JsonOptions);
        }

        /// <summary>
        ///     Get member as an asynchronous operation.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>A Task&lt;MemberModel&gt; representing the asynchronous operation.</returns>
        public async Task<MemberModel?> GetMemberAsync(Guid memberId)
        {
            var response = await SendGetMessageAsync($"{MemberPath}/id/{memberId}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<MemberModel>(JsonOptions);
        }

        #endregion

        #region PASSWORDS

        /// <summary>
        ///     Hash password as an asynchronous operation.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>A Task&lt;System.String&gt; representing the asynchronous operation.</returns>
        public async Task<string?> HashPasswordAsync(string password)
        {
            var response = await SendGetMessageAsync($"{PasswordPath}/hash/{password}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        ///     Verify password as an asynchronous operation.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="password">The password.</param>
        /// <returns>A Task&lt;VerificationResult&gt; representing the asynchronous operation.</returns>
        public async Task<VerificationResult?> VerifyPasswordAsync(string hashedPassword, string password)
        {
            var response = await SendGetMessageAsync($"{PasswordPath}/verify/{hashedPassword}/{password}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<VerificationResult>(JsonOptions);
        }

        #endregion

        #region HELPER METHODS

        /// <summary>
        ///     send delete message as an asynchronous operation.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        private async Task<HttpResponseMessage> SendDeleteMessageAsync(string route)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, route);
                return await _httpClient!.SendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not fulfill DELETE request at route: {route}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        ///     send get message as an asynchronous operation.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        private async Task<HttpResponseMessage> SendGetMessageAsync(string route)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, route);
                return await _httpClient!.SendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not fulfill GET request at route: {route}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        ///     send post message as an asynchronous operation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="route">The route.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        private async Task<HttpResponseMessage> SendPostMessageAsync(object model, string route)
        {
            try
            {
                var json = JsonSerializer.Serialize(model);
                var request = new HttpRequestMessage(HttpMethod.Post, route)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/Json")
                };
                return await _httpClient!.SendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not fulfill POST request at route: {route}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        ///     send put message as an asynchronous operation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="route">The route.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        private async Task<HttpResponseMessage> SendPutMessageAsync(object model, string route)
        {
            try
            {
                var json = JsonSerializer.Serialize(model);
                var request = new HttpRequestMessage(HttpMethod.Put, route)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/Json")
                };
                return await _httpClient!.SendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not fulfill PUT request at route: {route}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
        #endregion
    }
}