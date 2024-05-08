namespace Avocado.Application.Users.Query.GetUserData
{
    using FluentValidation;

    public class GetUserDataValidator : AbstractValidator<GetUserDataQuery>
    {
        public GetUserDataValidator()
        {
            RuleFor(x => x.UserToken)
                .NotEmpty();
        }
    }
}
