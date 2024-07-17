using System.Security.Claims;
using Bogus;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Web.FunctionalTests.Utilities;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;

public abstract class BaseMessageFunctionalTest : BaseFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>
{
    protected readonly int ValidPageValue;
    protected readonly int ValidPageSizeValue;

    protected readonly string ValidId;
    protected readonly string ValidReceiverId;
    protected readonly string ValidReceiverName;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidSortPropertyName;

    protected HttpClient HttpClient { get; }

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

    protected IMessageRepository MessageRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var messageRepository = serviceScope.ServiceProvider.GetRequiredService<IMessageRepository>();

            return messageRepository;
        }
    }

    protected Dictionary<string, object> ValidJwtConfig { get; set; }

    protected BaseMessageFunctionalTest(FunctionalTestWebAppFactory functionalTestWebAppFactory)
    {
        ValidPageValue = (MessageBusinessConfigurations.PAGE_MAX_VALUE + MessageBusinessConfigurations.PAGE_MIN_VALUE) / 2;
        ValidPageSizeValue = (MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE + MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE) / 2;

        ValidId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.ID_MAX_LENGTH + MessageBusinessConfigurations.ID_MIN_LENGTH) / 2);
        ValidReceiverId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH) / 2);
        ValidReceiverName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH) / 2);
        ValidCurrentUserId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH) / 2);
        ValidSortPropertyName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + MessageBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH) / 2);

        HttpClient = functionalTestWebAppFactory.CreateClient();
        ServiceScope = functionalTestWebAppFactory.Services.CreateScope();
        ValidJwtConfig = new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, MessageFunctionalTestConfigurations.EXISTING_SENDER_ID },
            { ClaimTypes.Name, MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME }
        };
    }

    protected async Task<string> CreateMessageAsync(string senderId, string receiverId, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT
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
            FirstName = MessageFunctionalTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageFunctionalTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageFunctionalTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageFunctionalTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserRepository>();

        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
