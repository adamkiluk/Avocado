namespace Avocado.Tests.Signboard.Command
{
    using FluentValidation;
    using Avocado.Application.Interfaces;
    using Avocado.Application.Signboards.Command.Delete;
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
    public class DeleteSignboardCommandTest
    {
        private readonly AvocadoDbContext _context;
        private readonly SignboardRepository _signboardRepository;
        private readonly INotificationService _notificationService;

        public DeleteSignboardCommandTest(ServiceFixture fixture)
        {
            _context = fixture.Context;
            _signboardRepository = new SignboardRepository(fixture.Context);
            _notificationService = fixture.NotificationService;
        }

        [Fact]
        public async Task Delete_Signboard_Should_Delete_Signboard_From_Database()
        {
            var signboardInDatabase = _context.Signboards.FirstAsync().Result;

            var command = new DeleteSignboardCommand
            {
                SignboardId = signboardInDatabase.SignboardId
            };

            var commandHandler = new DeleteSignboardCommand.Handler(_signboardRepository);

            await commandHandler.Handle(command, CancellationToken.None);

            var signboard = _context.Signboards.FirstOrDefaultAsync(x => x.SignboardId == command.SignboardId).Result;

            signboard.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_Signboard_With_Wrong_Data_Should_Throw_Exception()
        {
            var command = new DeleteSignboardCommand
            {
                SignboardId = Guid.Empty,
            };

            var commandHandler = new DeleteSignboardCommand.Handler(_signboardRepository);

            await commandHandler.Handle(command, CancellationToken.None)
                                .ShouldThrowAsync<ValidationException>();
        }
    }
}
