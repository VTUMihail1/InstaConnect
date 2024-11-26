using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Domain.Features.Users.Abstract;
using InstaConnect.Messages.Domain.Features.Users.Models.Entities;
using InstaConnect.Messages.Infrastructure;
using InstaConnect.Messages.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Presentation.FunctionalTests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Utilities;

public abstract class BaseMessageFunctionalTest : BaseSharedFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
{
    private const string API_ROUTE = "api/v1/messages";


    protected IMessageWriteRepository MessageWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var messageRepository = serviceScope.ServiceProvider.GetRequiredService<IMessageWriteRepository>();

            return messageRepository;
        }
    }

    protected IMessageReadRepository MessageReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var messageReadRepository = serviceScope.ServiceProvider.GetRequiredService<IMessageReadRepository>();

            return messageReadRepository;
        }
    }

    protected BaseMessageFunctionalTest(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(
        functionalTestWebAppFactory.CreateClient(),
        functionalTestWebAppFactory.Services.CreateScope(),
        API_ROUTE)
    {
    }

    protected async Task<string> CreateMessageAsync(string senderId, string receiverId, CancellationToken cancellationToken)
    {
        var message = new Message(
            MessageTestUtilities.ValidContent,
            senderId,
            receiverId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var messageWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IMessageWriteRepository>();

        messageWriteRepository.Add(message);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return message.Id;
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            MessageTestUtilities.ValidUserFirstName,
            MessageTestUtilities.ValidUserLastName,
            MessageTestUtilities.ValidUserEmail,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidUserProfileImage);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    public async Task InitializeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    public async Task DisposeAsync()
    {
        await EnsureDatabaseIsEmpty();
    }

    private async Task EnsureDatabaseIsEmpty()
    {
        var dbContext = ServiceScope.ServiceProvider.GetRequiredService<MessagesContext>();

        if (dbContext.Messages.Any())
        {
            await dbContext.Messages.ExecuteDeleteAsync(CancellationToken);
        }

        if (dbContext.Users.Any())
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
