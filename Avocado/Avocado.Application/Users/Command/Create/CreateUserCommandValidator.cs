namespace Avocado.Application.Users.Command.Create
{
    using FluentValidation;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName.Length).GreaterThanOrEqualTo(4);

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password.Length).GreaterThanOrEqualTo(6);

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty().Must(s => s.Length >= 9);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
