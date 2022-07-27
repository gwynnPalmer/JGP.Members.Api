namespace JGP.Members.Api.Controllers;

using JGP.Members.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/authentication")]
[ApiController]
[Authorize]
[Produces("application/json")]
public class AuthenticationController : ControllerBase
{
    private readonly IMemberService _memberService;

    public AuthenticationController(IMemberService memberService)
    {
        _memberService = memberService;
    }
}