namespace Avocado.Application.Signboards.Query.GetAllCompanySignboards
{
    using FluentValidation;
    using Avocado.Application.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllCompanySignboardsQueryHandler : IRequestHandler<GetAllCompanySignboardsQuery, CompanySignboardModel>
    {
        private readonly ISignboardRepository _signboardRepository;
        public GetAllCompanySignboardsQueryHandler(ISignboardRepository signboardRepository)
        {
            _signboardRepository = signboardRepository;
        }

        public async Task<CompanySignboardModel> Handle(GetAllCompanySignboardsQuery request, CancellationToken cancellationToken)
        {
            new GetAllCompanySignboardsValidator().ValidateAndThrow(request);

            return new CompanySignboardModel
            {
                AllCompanySignboards = await _signboardRepository.GetAllCompanySignboardsAsync(request.CompanyId)
            };
        }
    }
}
