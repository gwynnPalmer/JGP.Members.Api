// ***********************************************************************
// Assembly         : JGP.Members.Core
// Author           : Joshua Gwynn-Palmer
// Created          : 08-28-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 08-28-2022
// ***********************************************************************
// <copyright file="ChangePasswordCommand.cs" company="Joshua Gwynn-Palmer">
//     Joshua Gwynn-Palmer
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Core.Commands
{
    /// <summary>
    ///     Class ChangePasswordCommand.
    /// </summary>
    public class ChangePasswordCommand
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid MemberId { get; set; }

        /// <summary>
        ///     Creates new password.
        /// </summary>
        /// <value>The new password.</value>
        public string NewPassword { get; set; }

        /// <summary>
        ///     Gets or sets the old password.
        /// </summary>
        /// <value>The old password.</value>
        public string OldPassword { get; set; }
    }
}