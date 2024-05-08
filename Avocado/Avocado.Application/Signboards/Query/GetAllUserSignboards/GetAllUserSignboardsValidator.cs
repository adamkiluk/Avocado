namespace Avocado.Application.Signboards.Query.GetAllUserSignboards
{
    using FluentValidation;
    using Avocado.Application.Helpers;

    public class GetAllUserSignboardsValidator : AbstractValidator<GetAllUserSignboardsQuery>
    {
        public GetAllUserSignboardsValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .Must(GuidValidator.IsGUID);
        }
    }
}
