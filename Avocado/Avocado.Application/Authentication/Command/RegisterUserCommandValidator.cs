namespace Avocado.Application.Authentication.Command
{
    using FluentValidation;

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.RegisterUserModel.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.RegisterUserModel.Name).NotEmpty();
            RuleFor(x => x.RegisterUserModel.UserName).NotEmpty();
            RuleFor(x => x.RegisterUserModel.Password).NotEmpty();
            RuleFor(x => x.RegisterUserModel.Password.Length).GreaterThanOrEqualTo(8);
            RuleFor(x => x.RegisterUserModel.PhoneNumber).NotEmpty().Must(p => p.Length == 9);
        }
    }
}
