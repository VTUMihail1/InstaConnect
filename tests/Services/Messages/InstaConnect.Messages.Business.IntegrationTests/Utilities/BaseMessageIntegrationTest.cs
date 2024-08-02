using InstaConnect.Messages.Business.Features.Messages.Utilities;
using InstaConnect.Messages.Data;
using InstaConnect.Messages.Data.Features.Messages.Abstractions;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Messages.Data.Features.Users.Abstract;
using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Business.IntegrationTests.Utilities;

public abstract class BaseMessageIntegrationTest : BaseSharedIntegrationTest, IClassFixture<IntegrationTestWebAppFactory> ,IAsyncLifetime
{
    protected readonly string InvalidId;
    protected readonly string ValidContent;
    protected readonly string ValidAddContent;
    protected readonly string ValidUpdateContent;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidAddUserName;
    protected readonly string ValidUpdateUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;

    protected IUserReadRepository UserReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userReadRepository = serviceScope.ServiceProvider.GetRequiredService<IUserReadRepository>();

            return userReadRepository;
        }
    }

    protected IUserWriteRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

            return userWriteRepository;
        }
    }

    protected IMessageWriteRepository MessageWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var messageWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IMessageWriteRepository>();

            return messageWriteRepository;
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

    protected BaseMessageIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
        : base(integrationTestWebAppFactory.Services.CreateScope())
    {
        InvalidId = GetAverageString(MessageBusinessConfigurations.ID_MAX_LENGTH, MessageBusinessConfigurations.ID_MIN_LENGTH);
        ValidContent = GetAverageString(MessageBusinessConfigurations.CONTENT_MAX_LENGTH, MessageBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidAddContent = GetAverageString(MessageBusinessConfigurations.CONTENT_MAX_LENGTH, MessageBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidUpdateContent = GetAverageString(MessageBusinessConfigurations.CONTENT_MAX_LENGTH, MessageBusinessConfigurations.CONTENT_MIN_LENGTH);
        InvalidUserId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidAddUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUpdateUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
    }

    protected async Task<string> CreateMessageAsync(string senderId, string receiverId, CancellationToken cancellationToken)
    {
        var message = new Message(
            ValidContent,
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
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage);

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
