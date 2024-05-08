namespace Avocado.Application.Authentication.Query
{
    using Avocado.Application.Authentication.Model;
    using Avocado.Application.Exceptions;
    using Avocado.Application.Helpers;
    using Avocado.Application.Interfaces;
    using MediatR;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetValidTokenQuery : IRequest<JwtTokenModel>
    {
        public LoginUserModel Login { get; set; }

        public GetValidTokenQuery(LoginUserModel login)
        {
            Login = login;
        }

        public class Handler : IRequestHandler<GetValidTokenQuery, JwtTokenModel>
        {
            private IUserRepository usersRepository;
            private IJwtService jwt;

            public Handler(IUserRepository usersRepository, IJwtService jwt)
            {
                this.usersRepository = usersRepository;
                this.jwt = jwt;
            }

            public async Task<JwtTokenModel> Handle(GetValidTokenQuery request, CancellationToken cancellationToken)
            {
                var user = await usersRepository.FirstOrDefaultAsync(x => x.Email.Equals(request.Login.Email))
                    ?? throw new EntityNotFoundException(request.Login.Email);

                if (!PasswordHelper.ValidatePassword(request.Login.Password, user.Password))
                {
                    throw new ValidationException("Invalid login or password");
                }

                return jwt.GenerateJwtToken(user.Email, user.UserId, false);
            }
        }
    }
}
