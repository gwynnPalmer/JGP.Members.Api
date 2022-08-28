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
    using JGP.Core.Services;
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
    [Route("v{version:apiVersion}/member")]
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
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status400BadRequest)]
        [HttpPost("setpassword")]
        public async Task<IActionResult> ChangePassword([Required] MemberChangePasswordModel model)
        {
            var receipt = await _memberService.ChangePasswordAsync(model.GetChangePasswordCommand());
            return receipt.Outcome == ActionOutcome.Success
                ? Ok(receipt)
                : BadRequest(receipt);
        }

        /// <summary>
        ///     Disables the member.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status400BadRequest)]
        [HttpPost("email/disable/{emailAddress}")]
        public async Task<IActionResult> DisableMember([Required] string emailAddress)
        {
            var receipt = await _memberService.DisableMemberAsync(emailAddress);
            return receipt.Outcome == ActionOutcome.Success
                ? Ok(receipt)
                : BadRequest(receipt);
        }

        /// <summary>
        ///     Disables the member.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status400BadRequest)]
        [HttpPost("id/disable/{memberId:guid}")]
        public async Task<IActionResult> DisableMember([Required] Guid memberId)
        {
            var receipt = await _memberService.DisableMemberAsync(memberId);
            return receipt.Outcome == ActionOutcome.Success
                ? Ok(receipt)
                : BadRequest(receipt);
        }

        /// <summary>
        ///     Enables the member.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status400BadRequest)]
        [HttpPost("email/enable/{emailAddress}")]
        public async Task<IActionResult> EnableMember([Required] string emailAddress)
        {
            var receipt = await _memberService.EnableMemberAsync(emailAddress);
            return receipt.Outcome == ActionOutcome.Success
                ? Ok(receipt)
                : BadRequest(receipt);
        }

        /// <summary>
        ///     Enables the member.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status400BadRequest)]
        [HttpPost("id/enable/{memberId:guid}")]
        public async Task<IActionResult> EnableMember([Required] Guid memberId)
        {
            var receipt = await _memberService.EnableMemberAsync(memberId);
            return receipt.Outcome == ActionOutcome.Success
                ? Ok(receipt)
                : BadRequest(receipt);
        }

        /// <summary>
        ///     Gets the member by email.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(MemberModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("email/{emailAddress}")]
        public async Task<IActionResult> GetMember([Required] string emailAddress)
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{memberId:guid}")]
        public async Task<IActionResult> GetMember([Required] Guid memberId)
        {
            var member = await _memberService.GetMemberAsync(memberId);
            if (member == null)
            {
                return NotFound();
            }

            var model = new MemberModel(member);
            return new OkObjectResult(model);
        }

        /// <summary>
        ///     Update member as an asynchronous operation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task&lt;IActionResult&gt; representing the asynchronous operation.</returns>
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status400BadRequest)]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMemberAsync([Required] MemberModel model)
        {
            var receipt = await _memberService.UpdateMemberAsync(model.GetUpdateCommand());
            return receipt.Outcome == ActionOutcome.Success
                ? Ok(receipt)
                : BadRequest(receipt);
        }
    }
}