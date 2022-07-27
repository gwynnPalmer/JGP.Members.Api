namespace JGP.Members.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/password")]
[ApiController]
[Authorize]
[Produces("application/json")]
public class PasswordController : ControllerBase
{
    private readonly IMemberService _memberService;

    public PasswordController(IMemberService memberService)
    {
        _memberService = memberService;
    }
}