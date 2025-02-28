using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Messages.Common.Tests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Tests.Features.Users.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Domain.Features.Users.Abstractions;
using InstaConnect.Messages.Domain.Features.Users.Models.Entities;
using InstaConnect.Messages.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Application.IntegrationTests.Features.Messages.Utilities;

public abstract class BaseMessageIntegrationTest : IClassFixture<MessagesWebApplicationFactory>, IAsyncLifetime
{
    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

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

    protected BaseMessageIntegrationTest(MessagesWebApplicationFactory integrationTestWebAppFactory)
    {
        ServiceScope = integrationTestWebAppFactory.Services.CreateScope();
        CancellationToken = new CancellationToken();
        InstaConnectSender = ServiceScope.ServiceProvider.GetRequiredService<IInstaConnectSender>();
    }

    private async Task<User> CreateUserUtilAsync(CancellationToken cancellationToken)
    {
        var user = UserTestUtilities.CreateUser();

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(cancellationToken);

        return user;
    }

    private async Task<Message> CreateMessageUtilAsync(
        User sender,
        User receiver,
        CancellationToken cancellationToken)
    {
        var message = MessageTestUtilities.CreateMessage(sender, receiver);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var messageWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IMessageWriteRepository>();

        messageWriteRepository.Add(message);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return message;
    }

    protected async Task<Message> CreateMessageAsync(CancellationToken cancellationToken)
    {
        var sender = await CreateUserAsync(cancellationToken);
        var receiver = await CreateUserAsync(cancellationToken);
        var message = await CreateMessageUtilAsync(sender, receiver, cancellationToken);

        return message;
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

        if (await dbContext.Messages.AnyAsync(CancellationToken))
        {
            await dbContext.Messages.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.Users.AnyAsync(CancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
