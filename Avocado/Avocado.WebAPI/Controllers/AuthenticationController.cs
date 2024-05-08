namespace Avocado.Api.Controllers
{
    using Avocado.Application.Authentication.Command;
    using Avocado.Application.Authentication.Model;
    using Avocado.Application.Authentication.Query;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AuthenticationController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserModel model)
        {
            return Ok(await Mediator.Send(new GetValidTokenQuery(model)));
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody]LoginUserModel model)
        {
            return Ok(await Mediator.Send(new GetValidTokenQuery(model)));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserModel model)
        {
            return Ok(await Mediator.Send(new RegisterUserCommand(model)));
        }
    }
}
