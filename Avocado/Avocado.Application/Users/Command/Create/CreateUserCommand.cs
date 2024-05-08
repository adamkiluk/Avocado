namespace Avocado.Application.Users.Command.Create
{
    using FluentValidation;
    using Avocado.Application.Exceptions;
    using Avocado.Application.Helpers;
    using Avocado.Application.Interfaces;
    using Avocado.Domain.Entity;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand>
        {
            private readonly IUserRepository _userRepository;
            private readonly INotificationService _notificationService;

            public Handler (IUserRepository userRepository, INotificationService notificationService)
            {
                _userRepository = userRepository;
                _notificationService = notificationService;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                new CreateUserCommandValidator().ValidateAndThrow(request);

                var user = await _userRepository.GetUserByNameAsync(request.UserName)
                    ?? throw new EntityNotFoundException();

                if (user != null)
                {
                    throw new UserAlreadyExistsException();
                }

                await _userRepository.AddAsync(new User
                {
                    UserName = request.UserName,
                    Password = PasswordHelper.CreateHash(request.Password),
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                });

                await _userRepository.SaveAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
