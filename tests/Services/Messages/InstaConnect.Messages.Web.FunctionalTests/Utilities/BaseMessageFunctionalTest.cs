using System.Security.Claims;
using Bogus;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Web.FunctionalTests.Utilities;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Web.FunctionalTests.Utilities;

public abstract class BaseMessageFunctionalTest : BaseSharedFunctionalTest, IClassFixture<FunctionalTestWebAppFactory>
{
    private const string API_ROUTE = "api/v1/messages";

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
}
