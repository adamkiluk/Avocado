namespace Avocado.Api.Controllers
{
    using System.Threading.Tasks;
    using Avocado.Application.Users.Command.Edit;
    using Avocado.Application.Users.Query.GetUserData;
    using Avocado.Application.Users.Query.GetUserData.DTO;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : BaseController
    {
        private IHttpContextAccessor _httpContextAccessor { get; set; }

        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("/api/Account/EditUser")]
        public async Task<IActionResult> EditUser([FromBody]EditUserDTO model)
        {
            return Ok(await Mediator.Send(new EditUserDataCommand(model)));
        }

        [HttpGet("/api/Account/GetUser")]
        public async Task<ActionResult<GetUserDTO>> GetUser()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            return await base.Mediator.Send(new GetUserDataQuery { UserToken = authorizationHeader });
        }
    }
}