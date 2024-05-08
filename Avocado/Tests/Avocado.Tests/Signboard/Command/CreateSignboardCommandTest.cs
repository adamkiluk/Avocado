namespace Avocado.Tests.Signboard.Command
{
    using FluentValidation;
    using Avocado.Application.Exceptions;
    using Avocado.Application.Interfaces;
    using Avocado.Application.Signboards.Command.Create;
    using Avocado.Domain.Enums;
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
    public class CreateSignboardCommandTest
    {
        private readonly AvocadoDbContext _context;
        private readonly SignboardRepository _signboardRepository;
        private readonly INotificationService _notificationService;

        public CreateSignboardCommandTest(ServiceFixture fixture)
        {
            _context = fixture.Context;
            _signboardRepository = new SignboardRepository(fixture.Context);
            _notificationService = fixture.NotificationService;
        }

        //[Fact]
        //public async Task Create_Signboard_Should_Add_Signboard_To_Database()
        //{
        //    var command = new CreateSignboardCommand
        //    {
        //        SignboardId = Guid.Parse("38047d03-6dca-496a-9369-b975069c206d"),
        //        UserId = Guid.Parse("c2590534-0a30-4072-b5f2-0dc00f376504"),
        //        CompanyId = Guid.Parse("33c40b9c-0217-47cd-a420-1cd583dc7265"),
        //        Categories = "none",
        //        CompanyName = "Custom name",
        //        MustHave = ".Net, React, C#",
        //        NiceToHave = "Docker",
        //        SalaryRange = "5000 - 7000 PLN",
        //        Seniority = SingboardSeniorityLevel.Expert
        //    };

        //    var commandHandler = new CreateSignboardCommand.Handler(_signboardRepository, _notificationService);

        //    await commandHandler.Handle(command, CancellationToken.None);

        //    var signboard = await _context.Signboards.FirstOrDefaultAsync(x => x.SignboardId == command.SignboardId);

        //    signboard.ShouldNotBeNull();
        //}

        //[Fact]
        //public async Task Create_Signboard_Witch_Wrong_ID_Should_Throw_Exception()
        //{
        //    var command = new CreateSignboardCommand
        //    {
        //        SignboardId = Guid.Empty,
        //        UserId = Guid.Empty,
        //        CompanyId = Guid.Parse("33c40b9c-0217-47cd-a420-1cd583dc7265"),
        //        Categories = "none",
        //        CompanyName = "Custom name",
        //        MustHave = ".Net, React, C#",
        //        NiceToHave = "Docker",
        //        SalaryRange = "5000 - 7000 PLN",
        //        Seniority = SingboardSeniorityLevel.Expert
        //    };

        //    var commandHandler = new CreateSignboardCommand.Handler(_signboardRepository, _notificationService);

        //    await commandHandler.Handle(command, CancellationToken.None).ShouldThrowAsync<ValidationException>();

        //}

        //[Fact]
        //public async Task Create_Signboard_Witch_Same_Id_As_Existing_One_Should_Throw_Exception()
        //{
        //    var existingSignboard = _context.Signboards.FirstAsync().Result;

        //    var command = new CreateSignboardCommand
        //    {
        //        SignboardId = existingSignboard.SignboardId,
        //        UserId = Guid.Parse("c2590534-0a30-4072-b5f2-0dc00f376504"),
        //        CompanyId = Guid.Parse("33c40b9c-0217-47cd-a420-1cd583dc7265"),
        //        Categories = "none",
        //        CompanyName = "Custom name",
        //        MustHave = ".Net, React, C#",
        //        NiceToHave = "Docker",
        //        SalaryRange = "5000 - 7000 PLN",
        //        Seniority = SingboardSeniorityLevel.Expert
        //    };

        //    var commandHandler = new CreateSignboardCommand.Handler(_signboardRepository, _notificationService);

        //    await commandHandler.Handle(command, CancellationToken.None).ShouldThrowAsync<EntityAlreadyExistException>();

        //}
    }
}
