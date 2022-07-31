// ***********************************************************************
// Assembly         : JGP.Members.Api
// Author           : Joshua Gwynn-Palmer
// Created          : 07-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-28-2022
// ***********************************************************************
// <copyright file="MemberController.cs" company="JGP.Members.Api">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Api.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using JGP.Core.Services.Extensions.Web;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Web.Models;

    /// <summary>
    ///     Class MemberController.
    ///     Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/member")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize]
    public class MemberController : ControllerBase
    {
        /// <summary>
        ///     The member service
        /// </summary>
        private readonly IMemberService _memberService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MemberController" /> class.
        /// </summary>
        /// <param name="memberService">The member service.</param>
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        /// <summary>
        ///     Changes the password.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("setpassword/{emailAddress}")]
        public async Task<IActionResult> ChangePassword([Required] string emailAddress, [Required] string password)
        {
            var receipt = await _memberService.ChangePasswordAsync(emailAddress, password);
            return receipt.ToActionResult();
        }

        /// <summary>
        ///     Disables the member.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(MemberModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("email/disable/{emailAddress}")]
        public async Task<IActionResult> DisableMember([Required] string emailAddress)
        {
            var receipt = await _memberService.DisableMemberAsync(emailAddress);
            return receipt.ToActionResult();
        }

        /// <summary>
        ///     Disables the member.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(MemberModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("id/disable/{memberId:guid}")]
        public async Task<IActionResult> DisableMember([Required] Guid memberId)
        {
            var receipt = await _memberService.DisableMemberAsync(memberId);
            return receipt.ToActionResult();
        }

        /// <summary>
        ///     Enables the member.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(MemberModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("email/enable/{emailAddress}")]
        public async Task<IActionResult> EnableMember([Required] string emailAddress)
        {
            var receipt = await _memberService.EnableMemberAsync(emailAddress);
            return receipt.ToActionResult();
        }

        /// <summary>
        ///     Enables the member.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(MemberModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("id/enable/{memberId:guid}")]
        public async Task<IActionResult> EnableMember([Required] Guid memberId)
        {
            var receipt = await _memberService.EnableMemberAsync(memberId);
            return receipt.ToActionResult();
        }

        /// <summary>
        ///     Gets the member by email.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(MemberModel), StatusCodes.Status200OK)]
        [HttpGet("email/{emailAddress}")]
        public async Task<IActionResult> GetMember(string emailAddress)
        {
            var member = await _memberService.GetMemberAsync(emailAddress);
            if (member == null)
            {
                return NotFound();
            }

            var model = new MemberModel(member);
            return new OkObjectResult(model);
        }

        /// <summary>
        ///     Gets the member by identifier.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(MemberModel), StatusCodes.Status200OK)]
        [HttpGet("id/{memberId:guid}")]
        public async Task<IActionResult> GetMember(Guid memberId)
        {
            var member = await _memberService.GetMemberAsync(memberId);
            if (member == null)
            {
                return NotFound();
            }

            var model = new MemberModel(member);
            return new OkObjectResult(model);
        }
    }
}