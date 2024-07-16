using Bogus;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Messages.Read.Data.Models.Entities;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;

public abstract class BaseMessageIntegrationTest : BaseIntegrationTest, IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly int ValidLimitValue;
    protected readonly int ValidOffsetValue;

    protected readonly string ValidId;
    protected readonly string ValidReceiverId;
    protected readonly string ValidReceiverName;
    protected readonly string ValidSortOrderName;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidSortPropertyName;

    protected ITestHarness TestHarness
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var testHarness = serviceScope.ServiceProvider.GetTestHarness();

            return testHarness;
        }
    }

    protected IServiceScope ServiceScope { get; }

    protected IUserRepository UserRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();

            return userRepository;
        }
    }

    protected IMessageRepository MessageRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var messageRepository = serviceScope.ServiceProvider.GetRequiredService<IMessageRepository>();

            return messageRepository;
        }
    }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected BaseMessageIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
    {
        ValidLimitValue = (MessageBusinessConfigurations.LIMIT_MAX_VALUE + MessageBusinessConfigurations.LIMIT_MIN_VALUE) / 2;
        ValidOffsetValue = (MessageBusinessConfigurations.OFFSET_MAX_VALUE + MessageBusinessConfigurations.OFFSET_MIN_VALUE) / 2;

        ValidId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.ID_MAX_LENGTH + MessageBusinessConfigurations.ID_MIN_LENGTH) / 2);
        ValidReceiverId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH) / 2);
        ValidReceiverName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH) / 2);
        ValidCurrentUserId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH) / 2);
        ValidSortOrderName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH) / 2);
        ValidSortPropertyName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + MessageBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH) / 2);

        ServiceScope = integrationTestWebAppFactory.Services.CreateScope();
        InstaConnectSender = ServiceScope.ServiceProvider.GetRequiredService<IInstaConnectSender>();
    }

    protected async Task<string> CreateMessageAsync(string senderId, string receiverId, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT
        };

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var messageRepository = ServiceScope.ServiceProvider.GetRequiredService<IMessageRepository>();

        messageRepository.Add(message);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return message.Id;
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User
        {
            FirstName = MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserRepository>();

        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
