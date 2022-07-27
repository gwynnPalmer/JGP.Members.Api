namespace JGP.Members.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/member")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
    }
}
