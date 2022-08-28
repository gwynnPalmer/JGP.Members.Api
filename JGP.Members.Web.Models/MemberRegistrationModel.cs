// ***********************************************************************
// Assembly         : JGP.Members.Web.Models
// Author           : Joshua Gwynn-Palmer
// Created          : 07-27-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-27-2022
// ***********************************************************************
// <copyright file="MemberRegistrationModel.cs" company="JGP.Members.Web.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Core.Commands;

    /// <summary>
    ///     Class MemberRegistrationModel.
    /// </summary>
    public class MemberRegistrationModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        ///     Gets or sets the culture code.
        /// </summary>
        /// <value>The culture code.</value>
        [Required]
        [StringLength(10)]
        [JsonPropertyName("cultureCode")]
        public string CultureCode { get; set; }

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
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        [StringLength(12, MinimumLength = 8)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Passwords do not match")]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required]
        [StringLength(12, MinimumLength = 8)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        [JsonPropertyName("confirmPassword")]
        public string ConfirmPassword { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        ///     Gets the registration command.
        /// </summary>
        /// <returns>RegistrationCommand.</returns>
        public RegistrationCommand GetRegistrationCommand()
        {
            return new RegistrationCommand
            {
                CultureCode = CultureCode,
                EmailAddress = EmailAddress,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password
            };
        }
    }
}