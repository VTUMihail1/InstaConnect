using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Abstractions;
using InstaConnect.Messages.Business.Features.Messages.Mappings;
using InstaConnect.Messages.Business.Features.Messages.Utilities;
using InstaConnect.Messages.Business.Features.Users.Mappings;
using InstaConnect.Messages.Data.Features.Messages.Abstractions;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Messages.Data.Features.Messages.Models.Filters;
using InstaConnect.Messages.Data.Features.Users.Abstract;
using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Features.Messages.Utilities;

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
                    cfg.AddProfile<MessageQueryProfile>();
                    cfg.AddProfile<MessageCommandProfile>();
                    cfg.AddProfile<UserConsumerProfile>();
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
            ValidMessageCurrentUserId,
            ValidMessageReceiverId)
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

        MessageWriteRepository.GetByIdAsync(
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

        UserReadRepository.GetByIdAsync(
            ValidMessageCurrentUserId,
            CancellationToken)
            .Returns(existingMessageSender);

        UserReadRepository.GetByIdAsync(
            ValidMessageReceiverId,
            CancellationToken)
            .Returns(existingMessageReceiver);

        UserWriteRepository.GetByIdAsync(
            ValidCurrentUserId,
            CancellationToken)
            .Returns(existingSender);

        UserWriteRepository.GetByIdAsync(
            ValidReceiverId,
            CancellationToken)
            .Returns(existingReceiver);

        UserWriteRepository.GetByIdAsync(
            ValidMessageCurrentUserId,
            CancellationToken)
            .Returns(existingMessageSender);

        UserWriteRepository.GetByIdAsync(
            ValidMessageReceiverId,
            CancellationToken)
            .Returns(existingMessageReceiver);

        MessageReadRepository
            .GetAllAsync(Arg.Is<MessageCollectionReadQuery>(m =>
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingMessagePaginationList);
    }
}
