namespace Avocado.Application.Users
{
    using AutoMapper;
    using Avocado.Application.Users.Command.Edit;
    using Avocado.Application.Users.Query.GetUserData.DTO;
    using Avocado.Domain.Entity;

    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            // => GetUserData
            CreateMap<User, UserDTO>(MemberList.Destination);
            CreateMap<Company, CompanyDTO>(MemberList.Destination);

            // => EditUserData
            CreateMap<EditUserDTO, User>(MemberList.Source);
        }
    }
}
