namespace Avocado.Api.Controllers
{
    using Application.Signboards.Command.Create;
    using Application.Signboards.Command.Delete;
    using Application.Signboards.Query.GetAllCompanySignboards;
    using Application.Signboards.Query.GetAllUserSignboards;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class SignboardController : BaseController
    {
        private IHttpContextAccessor _httpContextAccessor { get; set; }

        public SignboardController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateSignboard([FromBody]CreateSignboardModel model)
        {
            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            return Ok(await base.Mediator.Send(new CreateSignboardCommand(model, authorizationHeader )));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteSignboard([FromBody]DeleteSignboardCommand command)
        {
            return Ok(await base.Mediator.Send(command));
        }

        [HttpGet("GetAllUserSignboards/{UserId}")]
        public async Task<ActionResult<SignboardModel>> GetAllUserSignboards(Guid UserId)
        {
            return await base.Mediator.Send(new GetAllUserSignboardsQuery{ UserId = UserId });
        }

        [HttpGet("GetAllCompanySignboards/{CompanyId}")]
        public async Task<ActionResult<CompanySignboardModel>> GetAllCompanySignboards(Guid CompanyId)
        {
            return await base.Mediator.Send(new GetAllCompanySignboardsQuery { CompanyId = CompanyId });
        }

    }
}