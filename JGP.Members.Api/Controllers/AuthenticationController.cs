// ***********************************************************************
// Assembly         : JGP.Members.Api
// Author           : Joshua Gwynn-Palmer
// Created          : 07-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-28-2022
// ***********************************************************************
// <copyright file="AuthenticationController.cs" company="JGP.Members.Api">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Api.Controllers;

using System.ComponentModel.DataAnnotations;
using Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web.Models;

/// <summary>
///     Class AuthenticationController.
///     Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/authentication")]
[ApiController]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[Authorize]
public class AuthenticationController : ControllerBase
{
    /// <summary>
    ///     The authentication service
    /// </summary>
    private readonly IAuthenticationService _authenticationService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthenticationController" /> class.
    /// </summary>
    /// <param name="authenticationService">The authentication service.</param>
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    /// <summary>
    ///     Authenticates the specified model.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>IActionResult.</returns>
    [ProducesResponseType(typeof(AuthenticationResult), StatusCodes.Status200OK)]
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([Required] LoginModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _authenticationService.AuthenticateAsync(model.GetLoginCommand());

        return new OkObjectResult(result);
    }
}