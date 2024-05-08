namespace Avocado.Application.Users.Command.Edit
{
    using AutoMapper;
    using FluentValidation;
    using Avocado.Application.Exceptions;
    using Avocado.Application.Interfaces;
    using Avocado.Domain.Entity;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditUserDataCommand : IRequest
    {
        public EditUserDTO Model { get; set; }

        public EditUserDataCommand(EditUserDTO model)
        {
            Model = model;
        }

        public class Handler : IRequestHandler<EditUserDataCommand>
        {
            private readonly IUserRepository _userRepository;
            private readonly IRepository<User> _repository;
            private readonly INotificationService _notificationService;
            private readonly IJwtService _jwtService;
            private readonly IMapper _mapper;

            public Handler(
                IUserRepository userRepository, 
                INotificationService notificationService, 
                IJwtService jwtService, 
                IRepository<User> repository,
                IMapper mapper)
            {
                _userRepository = userRepository;
                _notificationService = notificationService;
                _jwtService = jwtService;
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(EditUserDataCommand request, CancellationToken cancellationToken)
            {
                new EditUserDataCommandValidator().ValidateAndThrow(request);

                Guid userId = _jwtService.GetUserIdFromToken(request.Model.Token);

                User user = await _userRepository.GetByIdAsync(userId)
                    ?? throw new EntityNotFoundException($"Unable to find user with this Id: {userId}");

                user = _mapper.Map(request.Model, user);

                _repository.Update(user);
                await _userRepository.SaveAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
