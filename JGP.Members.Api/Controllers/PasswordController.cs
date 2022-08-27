// ***********************************************************************
// Assembly         : JGP.Members.Api
// Author           : Joshua Gwynn-Palmer
// Created          : 07-26-2022
//
// Last Modified By : Joshua Gwynn-Palmer
// Last Modified On : 07-26-2022
// ***********************************************************************
// <copyright file="PasswordController.cs" company="JGP.Members.Api">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace JGP.Members.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security;

/// <summary>
///     Class PasswordController.
///     Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiVersion("1")]
[Route("v{version:apiVersion}/password")]
[ApiController]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[Authorize]
public class PasswordController : ControllerBase
{
    /// <summary>
    ///     The password service
    /// </summary>
    private readonly IPasswordService _passwordService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PasswordController" /> class.
    /// </summary>
    /// <param name="passwordService">The password service.</param>
    public PasswordController(IPasswordService passwordService)
    {
        _passwordService = passwordService;
    }

    /// <summary>
    ///     Hashes the specified password.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>IActionResult.</returns>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [HttpGet("hash/{password}")]
    public IActionResult Hash(string password)
    {
        var result = _passwordService.Hash(password);
        return Ok(result);
    }

    /// <summary>
    ///     Verifies the specified hash.
    /// </summary>
    /// <param name="hash">The hash.</param>
    /// <param name="password">The password.</param>
    /// <returns>IActionResult.</returns>
    [ProducesResponseType(typeof(VerificationResult), StatusCodes.Status200OK)]
    [HttpGet("verify/{hash}/{password}")]
    public IActionResult Verify(string hash, string password)
    {
        var result = _passwordService.Verify(password, hash);
        return Ok(result);
    }
}