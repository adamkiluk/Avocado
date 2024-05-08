namespace Avocado.Application.Signboards.Command.Delete
{
    using FluentValidation;
    using Avocado.Application.Helpers;

    public class DeleteSignboardCommandValidator : AbstractValidator<DeleteSignboardCommand>
    {
        public DeleteSignboardCommandValidator()
        {
            RuleFor(x => x.SignboardId)
                .NotEmpty()
                .Must(GuidValidator.IsGUID);
        }
    }
}
