namespace Avocado.Application.Users.Command.Edit
{
    using FluentValidation;

    public class EditUserDataCommandValidator : AbstractValidator<EditUserDataCommand>
    {
        public EditUserDataCommandValidator()
        {
            RuleFor(x => x.Model.Token).NotEmpty();

            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.Model.PhoneNumber).NotEmpty().Must(s => s.Length == 9);
        }
    }
}
