using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Web.Profiles;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Messages.Web.UnitTests.Utilities;

public abstract class BaseMessageUnitTest : BaseUnitTest
{
    protected readonly int ValidLimitValue;
    protected readonly int ValidOffsetValue;

    protected readonly string ValidId;
    protected readonly string AddContent;
    protected readonly string UpdateContent;
    protected readonly string ValidReceiverId;
    protected readonly string ValidReceiverName;
    protected readonly string ValidSortOrderName;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidSortPropertyName;

    protected IInstaConnectSender InstaConnectSender { get; }

    protected ICurrentUserContext CurrentUserContext { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseMessageUnitTest()
    {
        ValidLimitValue = (MessageBusinessConfigurations.PAGE_MAX_VALUE + MessageBusinessConfigurations.PAGE_MIN_VALUE) / 2;
        ValidOffsetValue = (MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE + MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE) / 2;

        ValidId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.ID_MAX_LENGTH + MessageBusinessConfigurations.ID_MIN_LENGTH) / 2);
        AddContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        UpdateContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidReceiverId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH) / 2);
        ValidReceiverName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH) / 2);
        ValidCurrentUserId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH) / 2);
        ValidSortOrderName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH) / 2);
        ValidSortPropertyName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + MessageBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH) / 2);

        var existingMessage = new MessageReadViewModel()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            SenderName = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_NAME,
            SenderProfileImage = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_PROFILE_IMAGE,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
            ReceiverName = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_NAME,
            ReceiverProfileImage = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_PROFILE_IMAGE,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        CurrentUserContext = Substitute.For<ICurrentUserContext>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                cfg.AddProfile(new MessagesWebProfile()))));

        CurrentUserContext.GetCurrentUser().Returns(new CurrentUserModel
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
        });

        InstaConnectSender.SendAsync(Arg.Any<GetAllFilteredMessagesQuery>(), CancellationToken).Returns(new MessagePaginationCollectionModel()
        {
            Items = [existingMessage],
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
            TotalCount = MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE,
        });

        InstaConnectSender.SendAsync(Arg.Any<GetMessageByIdQuery>(), CancellationToken).Returns(existingMessage);

        InstaConnectSender.SendAsync(Arg.Any<AddMessageCommand>(), CancellationToken).Returns(new MessageWriteViewModel
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        });

        InstaConnectSender.SendAsync(Arg.Any<UpdateMessageCommand>(), CancellationToken).Returns(new MessageWriteViewModel
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        });
    }
}
