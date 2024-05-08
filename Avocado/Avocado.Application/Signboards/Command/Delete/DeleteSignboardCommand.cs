namespace Avocado.Application.Signboards.Command.Delete
{
    using FluentValidation;
    using Avocado.Application.Exceptions;
    using Avocado.Application.Interfaces;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteSignboardCommand : IRequest
    {
        public Guid SignboardId { get; set; }

        public class Handler : IRequestHandler<DeleteSignboardCommand>
        {
            private readonly ISignboardRepository _signboardRepository;

            public Handler(ISignboardRepository signboardRepository)
            {
                _signboardRepository = signboardRepository;
            }

            public async Task<Unit> Handle(DeleteSignboardCommand request, CancellationToken cancellationToken)
            {
                new DeleteSignboardCommandValidator().ValidateAndThrow(request);

                var signboard = await _signboardRepository.FirstOrDefaultAsync(x => x.SignboardId == request.SignboardId)
                    ?? throw new EntityNotFoundException();

                _signboardRepository.Delete(signboard);

                await _signboardRepository.SaveAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
