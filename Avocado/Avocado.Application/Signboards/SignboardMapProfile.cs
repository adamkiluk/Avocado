namespace Avocado.Application.Signboards
{
    using AutoMapper;
    using Avocado.Application.Signboards.Command.Create;
    using Avocado.Domain.Entity;

    public class SignboardMapProfile : Profile
    {
        public SignboardMapProfile()
        {
            // => CreateSignboard
            CreateMap<CreateSignboardModel, Signboard>(MemberList.Source);
        }
    }
}