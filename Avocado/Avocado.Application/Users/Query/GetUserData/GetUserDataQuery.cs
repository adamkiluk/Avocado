namespace Avocado.Application.Users.Query.GetUserData
{
    using Avocado.Application.Users.Query.GetUserData.DTO;
    using MediatR;

    public class GetUserDataQuery : IRequest<GetUserDTO>
    {
        public string UserToken { get; set; }
    }
}
