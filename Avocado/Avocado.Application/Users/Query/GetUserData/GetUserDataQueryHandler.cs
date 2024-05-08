namespace Avocado.Application.Users.Query.GetUserData
{
    using AutoMapper;
    using Avocado.Application.Exceptions;
    using Avocado.Application.Interfaces;
    using Avocado.Application.Users.Query.GetUserData.DTO;
    using Avocado.Domain.Entity;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, GetUserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly INotificationService _notificationService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public GetUserDataQueryHandler(
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            INotificationService notificationService,
            IJwtService jwtService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _notificationService = notificationService;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<GetUserDTO> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {

            Guid userId = _jwtService.GetUserIdFromToken(request.UserToken.ToString());

            User user = await _userRepository.GetByIdAsync(userId)
                ?? throw new EntityNotFoundException($"Unable to find user with this Id: {userId}");

            Company company = await _companyRepository.GetUserCompany(user.CompanyId)
                ?? throw new EntityNotFoundException($"Unable to find user company with this Id: {userId}");
                
            GetUserDTO model = new GetUserDTO();
            model.User = _mapper.Map<UserDTO>(user);
            model.Company = _mapper.Map<CompanyDTO>(company);

            return model;
        }
    }
}