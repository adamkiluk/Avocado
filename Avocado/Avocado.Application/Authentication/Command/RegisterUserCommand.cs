namespace Avocado.Application.Authentication.Command
{
    using FluentValidation;
    using Avocado.Application.Authentication.Model;
    using Avocado.Application.Exceptions;
    using Avocado.Application.Helpers;
    using Avocado.Application.Interfaces;
    using Avocado.Domain.Entity;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterUserCommand : IRequest
    {
        public RegisterUserModel RegisterUserModel { get; set; }

        public RegisterUserCommand(RegisterUserModel registerUserModel)
        {
            this.RegisterUserModel = registerUserModel;
        }

        public class Handler : IRequestHandler<RegisterUserCommand>
        {
            private readonly IUserRepository userRepository;

            public Handler(IUserRepository userRepository)
            {
                this.userRepository = userRepository;
            }

            public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                new RegisterUserCommandValidator().ValidateAndThrow(request);

                var userEmail = await userRepository.GetUserByEmailAsync(request.RegisterUserModel.Email);
                if (userEmail != null)
                {
                    throw new UserAlreadyExistsException(nameof(RegisterUserCommand));
                }

                var userUserName = await userRepository.GetUserByNameAsync(request.RegisterUserModel.UserName);
                if (userUserName != null)
                {
                    throw new EntityAlreadyExistException(nameof(RegisterUserCommand));
                }

                await userRepository.AddAsync(new User
                {
                    UserName = request.RegisterUserModel.UserName,
                    Password = PasswordHelper.CreateHash(request.RegisterUserModel.Password),
                    Name = request.RegisterUserModel.Name,
                    Email = request.RegisterUserModel.Email,
                    PhoneNumber = request.RegisterUserModel.PhoneNumber,
                });

                await userRepository.SaveAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
