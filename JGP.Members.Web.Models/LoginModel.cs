// ***********************************************************************
// Assembly         : JGP.Members.Web.Models
// Author           : Joshua Gwynn-Palmer
// Created          : 07-28-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-28-2022
// ***********************************************************************
// <copyright file="LoginModel.cs" company="JGP.Members.Web.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Core.Security;

    /// <summary>
    ///     Class LoginModel.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        ///     Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value><c>true</c> if [remember me]; otherwise, <c>false</c>.</value>
        [JsonPropertyName("rememberMe")]
        public bool RememberMe { get; set; }

        /// <summary>
        ///     Gets or sets the return URL.
        /// </summary>
        /// <value>The return URL.</value>
        [JsonPropertyName("returnUrl")]
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     Gets the login command.
        /// </summary>
        /// <returns>LoginCommand.</returns>
        public LoginCommand GetLoginCommand()
        {
            return new LoginCommand
            {
                EmailAddress = EmailAddress,
                Password = Password,
                RememberMe = RememberMe
            };
        }
    }
}