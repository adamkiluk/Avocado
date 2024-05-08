namespace Avocado.Tests.Signboard.Query
{
    using FluentValidation;
    using Avocado.Application.Interfaces;
    using Avocado.Application.Signboards.Query.GetAllUserSignboards;
    using Avocado.Persistence;
    using Avocado.Persistence.Repository;
    using Avocado.Tests.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Shouldly;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("ServicesTestCollection")]
    public class GetAllUserSingboardsTest
    {
        private readonly AvocadoDbContext _context;
        private readonly SignboardRepository _signboardRepository;
        private readonly INotificationService _notificationService;

        public GetAllUserSingboardsTest(ServiceFixture fixture)
        {
            _context = fixture.Context;
            _signboardRepository = new SignboardRepository(fixture.Context);
            _notificationService = fixture.NotificationService;
        }

        [Fact]
        public async Task Querry_Should_Return_User_Singboards()
        {
            var user = _context.Signboards.FirstAsync().Result;

            var command = new GetAllUserSignboardsQuery
            {
                UserId = user.UserId
            };

            var commandHandler = new GetAllUserSignboardsQueryHandler(_signboardRepository);

            var userSignboards = await commandHandler.Handle(command, CancellationToken.None);

            userSignboards.ShouldNotBeNull();
            userSignboards.ShouldBeOfType<SignboardModel>();
        }

        [Fact]
        public async Task Querry_With_Wrong_Id_Should_Throw_Exception()
        {

            var command = new GetAllUserSignboardsQuery
            {
                UserId = Guid.Empty
            };

            var commandHandler = new GetAllUserSignboardsQueryHandler(_signboardRepository);

            await commandHandler.Handle(command, CancellationToken.None).ShouldThrowAsync<ValidationException>(); ;
        }
    }
}
