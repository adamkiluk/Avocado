namespace Avocado.Application.Signboards.Query.GetAllUserSignboards
{
    using MediatR;
    using System;

    public class GetAllUserSignboardsQuery : IRequest<SignboardModel>
    {
        public Guid UserId { get; set; }
    }
}
