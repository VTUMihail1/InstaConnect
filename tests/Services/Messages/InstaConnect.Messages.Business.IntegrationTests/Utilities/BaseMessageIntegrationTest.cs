using Bogus;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Messages.Data.Models.Entities;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Business.IntegrationTests.Utilities;

public abstract class BaseMessageIntegrationTest : BaseIntegrationTest, IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly int ValidPageSizeValue;
    protected readonly int ValidPageValue;

    protected readonly string ValidId;
    protected readonly string ValidContent;
    protected readonly string ValidReceiverId;
    protected readonly string ValidAddContent;
    protected readonly string ValidReceiverName;
    protected readonly string ValidUpdateContent;
    protected readonly string ValidSortOrderName;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidSortPropertyName;

    protected IServiceScope ServiceScope { get; }

    protected IUserReadRepository UserReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userReadRepository = serviceScope.ServiceProvider.GetRequiredService<IUserReadRepository>();

            return userReadRepository;
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

    protected IInstaConnectSender InstaConnectSender { get; }

    protected BaseMessageIntegrationTest(IntegrationTestWebAppFactory integrationTestWebAppFactory)
    {
        ValidPageSizeValue = (MessageBusinessConfigurations.PAGE_MAX_VALUE + MessageBusinessConfigurations.PAGE_MIN_VALUE) / 2;
        ValidPageValue = (MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE + MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE) / 2;

        ValidId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.ID_MAX_LENGTH + MessageBusinessConfigurations.ID_MIN_LENGTH) / 2);
        ValidContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidAddContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidReceiverId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH) / 2);
        ValidReceiverName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH) / 2);
        ValidUpdateContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidCurrentUserId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH) / 2);
        ValidSortOrderName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH) / 2);
        ValidSortPropertyName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + MessageBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH) / 2);


        ServiceScope = integrationTestWebAppFactory.Services.CreateScope();
        InstaConnectSender = ServiceScope.ServiceProvider.GetRequiredService<IInstaConnectSender>();
    }

    protected async Task<string> CreateMessageAsync(string senderId, string receiverId, CancellationToken cancellationToken)
    {
        var message = new Message(
            MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT, 
            senderId, 
            receiverId);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var messageReadRepository = ServiceScope.ServiceProvider.GetRequiredService<IMessageReadRepository>();

        messageReadRepository.Add(message);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return message.Id;
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            MessageIntegrationTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            MessageIntegrationTestConfigurations.EXISTING_SENDER_LAST_NAME,
            MessageIntegrationTestConfigurations.EXISTING_SENDER_EMAIL,
            MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME,
            MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userReadRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserReadRepository>();

        userReadRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
