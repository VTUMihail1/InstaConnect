using System.Security.Claims;
using Bogus;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Web.FunctionalTests.Utilities;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;

public abstract class BaseMessageFunctionalTest : BaseFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>
{
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

    protected string ValidId { get; }

    protected string ValidContent { get; }

    protected string ValidReceiverId { get; }

    protected string ValidAddContent { get; }

    protected string ValidUpdateContent { get; }

    protected string ValidCurrentUserId { get; }

    protected BaseMessageFunctionalTest(FunctionalTestWebAppFactory functionalTestWebAppFactory)
    {
        HttpClient = functionalTestWebAppFactory.CreateClient();
        ServiceScope = functionalTestWebAppFactory.Services.CreateScope();
        ValidJwtConfig = new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, MessageFunctionalTestConfigurations.EXISTING_SENDER_ID },
            { ClaimTypes.Name, MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME }
        };

        ValidId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.ID_MAX_LENGTH + MessageBusinessConfigurations.ID_MIN_LENGTH) / 2);
        ValidContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidReceiverId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH) / 2);
        ValidAddContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidUpdateContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidCurrentUserId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH) / 2);
        ValidCurrentUserId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH) / 2);
    }

    protected async Task<string> CreateMessageAsync(CancellationToken cancellationToken)
    {
        var message = new Message
        {
            SenderId = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            ReceiverId = MessageFunctionalTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
            Content = ValidContent
        };

        var messageRepository = ServiceScope.ServiceProvider.GetRequiredService<IMessageRepository>();
        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        messageRepository.Add(message);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return message.Id;
    }
}
