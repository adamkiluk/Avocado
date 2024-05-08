namespace Avocado.Application.Signboards.Query.GetAllCompanySignboards
{
    using FluentValidation;
    using Avocado.Application.Helpers;

    public class GetAllCompanySignboardsValidator : AbstractValidator<GetAllCompanySignboardsQuery>
    {
        public GetAllCompanySignboardsValidator()
        {
            RuleFor(x => x.CompanyId)
                .NotEmpty()
                .Must(GuidValidator.IsGUID);
        }
    }
}
