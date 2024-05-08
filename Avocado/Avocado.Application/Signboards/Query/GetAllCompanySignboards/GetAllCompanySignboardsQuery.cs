namespace Avocado.Application.Signboards.Query.GetAllCompanySignboards
{
    using MediatR;
    using System;

    public class GetAllCompanySignboardsQuery : IRequest<CompanySignboardModel>
    {
        public Guid CompanyId { get; set; }
    }
}
