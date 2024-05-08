namespace Avocado.Application.Signboards.Command.Create
{
    using FluentValidation;
    using Avocado.Application.Helpers;

    public class CreateSignboardCommandValidator : AbstractValidator<CreateSignboardCommand>
    {
        public CreateSignboardCommandValidator()
        {
            RuleFor(x => x.Model.DailyTasks)
                .NotEmpty();

            RuleFor(x => x.Model.MustHave)
                .NotEmpty();
            RuleFor(x => x.Model.NiceToHave)
               .NotEmpty();
        }
    }
}
