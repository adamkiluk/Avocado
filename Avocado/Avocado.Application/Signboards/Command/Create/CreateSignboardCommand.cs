namespace Avocado.Application.Signboards.Command.Create
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using Avocado.Application.Interfaces;
    using Avocado.Application.Exceptions;
    using AutoMapper;
    using System;
    using Avocado.Domain.Entity;

    public class CreateSignboardCommand : IRequest
    {

        public CreateSignboardModel Model { get; set; }
        public string Token { get; set; }

        public CreateSignboardCommand(CreateSignboardModel model, string token)
        {
            Model = model;
            Token = token;
        }
        public class Handler : IRequestHandler<CreateSignboardCommand>
        {
            private readonly ISignboardRepository _signboardRepository;
            private readonly IUserRepository _userRepository;
            private readonly INotificationService _notificationService;
            private readonly IMapper _mapper;
            private readonly IJwtService _jwtService;

            public Handler(
                ISignboardRepository signboardRepository,
                IUserRepository userRepository, 
                INotificationService notificationService,
                IMapper mapper,
                IJwtService jwtService)
            {
                _signboardRepository = signboardRepository;
                _userRepository = userRepository;
                _notificationService = notificationService;
                _mapper = mapper;
                _jwtService = jwtService;
            }

            public async Task<Unit> Handle(CreateSignboardCommand request, CancellationToken cancellationToken)
            {
                new CreateSignboardCommandValidator().ValidateAndThrow(request);

                var signboard = await _signboardRepository.GetByIdAsync(request.Model.SignboardId);

                if (signboard != null)
                {
                    throw new EntityAlreadyExistException();
                }
                Guid userId = _jwtService.GetUserIdFromToken(request.Token);

                User user = await _userRepository.GetByIdAsync(userId)
                    ?? throw new EntityNotFoundException($"Unable to find user with this Id: {userId}");

                request.Model.UserId = userId;
                request.Model.CompanyId = user.CompanyId ?? Guid.NewGuid();

                signboard = _mapper.Map(request.Model, signboard);

                await _signboardRepository.AddAsync(signboard);
                await _signboardRepository.SaveAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
