namespace Avocado.Application.Signboards.Query.GetAllUserSignboards
{
    using FluentValidation;
    using Avocado.Application.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllUserSignboardsQueryHandler : IRequestHandler<GetAllUserSignboardsQuery, SignboardModel>
    {
        private readonly ISignboardRepository _signboardRepository;

        public GetAllUserSignboardsQueryHandler(ISignboardRepository signboardRepository)
        {
            _signboardRepository = signboardRepository;
        }

        public async Task<SignboardModel> Handle(GetAllUserSignboardsQuery request, CancellationToken cancellationToken)
        {
            new GetAllUserSignboardsValidator().ValidateAndThrow(request);

            return new SignboardModel
            {
                AllSignboards = await _signboardRepository.GetAllUserSignboardsAsync(request.UserId)
            };
        }
    }
}
