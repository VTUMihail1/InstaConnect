using AutoMapper;
using InstaConnect.Messages.Business.Abstract;
using InstaConnect.Messages.Business.Profiles;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Utilities;

public abstract class BaseMessageUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string InvalidId;
    protected readonly string ValidContent;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidReceiverId;
    protected readonly string InvalidUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserFirstName;
    protected readonly string ValidUserEmail;
    protected readonly string ValidUserLastName;
    protected readonly string ValidUserProfileImage;
    protected readonly string ValidMessageReceiverId;
    protected readonly string ValidMessageCurrentUserId;

    protected IMessageSender MessageSender { get; }

    protected IUserReadRepository UserReadRepository { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IMessageReadRepository MessageReadRepository { get; }

    protected IMessageWriteRepository MessageWriteRepository { get; }

    public BaseMessageUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MessagesQueryProfile>();
                    cfg.AddProfile<MessagesCommandProfile>();
                }))),
        new EntityPropertyValidator())
    {
        ValidId = GetAverageString(MessageBusinessConfigurations.ID_MAX_LENGTH, MessageBusinessConfigurations.ID_MIN_LENGTH);
        InvalidId = GetAverageString(MessageBusinessConfigurations.ID_MAX_LENGTH, MessageBusinessConfigurations.ID_MIN_LENGTH);
        ValidContent = GetAverageString(MessageBusinessConfigurations.CONTENT_MAX_LENGTH, MessageBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidReceiverId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
        InvalidUserId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserFirstName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserLastName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserEmail = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidMessageReceiverId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
        ValidMessageCurrentUserId = GetAverageString(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);

        UserReadRepository = Substitute.For<IUserReadRepository>();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        MessageSender = Substitute.For<IMessageSender>();
        MessageReadRepository = Substitute.For<IMessageReadRepository>();
        MessageWriteRepository = Substitute.For<IMessageWriteRepository>();

        MessageWriteRepository.When(x => x.Add(Arg.Is<Message>(m => m.SenderId == ValidCurrentUserId &&
                                                               m.ReceiverId == ValidReceiverId &&
                                                               m.Content == ValidContent)))
                         .Do(ci =>
                              {
                                  var message = ci.Arg<Message>();
                                  message.Id = ValidId;
                              });

        var existingSender = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidCurrentUserId,
        };

        var existingMessageSender = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidMessageCurrentUserId,
        };

        var existingReceiver = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidReceiverId
        };

        var existingMessageReceiver = new User(
            ValidUserFirstName,
            ValidUserLastName,
            ValidUserEmail,
            ValidUserName,
            ValidUserProfileImage)
        {
            Id = ValidMessageReceiverId
        };

        var existingMessage = new Message(
            ValidContent,
            ValidCurrentUserId,
            ValidReceiverId)
        {
            Id = ValidId,
            Sender = existingMessageSender,
            Receiver = existingMessageReceiver
        };

        var existingMessagePaginationList = new PaginationList<Message>(
            [existingMessage],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        MessageReadRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingMessage);

        UserReadRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingSender);

        UserReadRepository.GetByIdAsync(
            ValidReceiverId,
            CancellationToken)
            .Returns(existingReceiver);

        MessageWriteRepository.GetByIdAsync(
            ValidId,
            CancellationToken)
            .Returns(existingMessage);

        UserWriteRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingSender);

        UserWriteRepository.GetByIdAsync(
            ValidReceiverId,
            CancellationToken)
            .Returns(existingReceiver);

        MessageReadRepository
            .GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionReadQuery>(m =>
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingMessagePaginationList);
    }
}
