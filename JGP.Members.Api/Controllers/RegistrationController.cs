// ***********************************************************************
// Assembly         : JGP.Members.Api
// Author           : Joshua Gwynn-Palmer
// Created          : 07-27-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-28-2022
// ***********************************************************************
// <copyright file="RegistrationController.cs" company="JGP.Members.Api">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Api.Controllers
{
    using JGP.Core.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Web.Models;

    /// <summary>
    ///     Class RegistrationController.
    ///     Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/registration")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize]
    public class RegistrationController : ControllerBase
    {
        /// <summary>
        ///     The registration service
        /// </summary>
        private readonly IRegistrationService _registrationService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegistrationController" /> class.
        /// </summary>
        /// <param name="registrationService">The registration service.</param>
        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        /// <summary>
        ///     Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionReceipt), StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<IActionResult> Register(MemberRegistrationModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var receipt = await _registrationService.RegisterMemberAsync(model.GetRegistrationCommand());
            return receipt.Outcome == ActionOutcome.Success
                ? Ok(receipt)
                : BadRequest(receipt);
        }
    }
}