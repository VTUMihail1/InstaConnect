using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Abstractions;
using InstaConnect.Messages.Business.Features.Messages.Mappings;
using InstaConnect.Messages.Business.Features.Users.Mappings;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
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
    protected IMessageSender MessageSender { get; }

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
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        MessageSender = Substitute.For<IMessageSender>();
        MessageReadRepository = Substitute.For<IMessageReadRepository>();
        MessageWriteRepository = Substitute.For<IMessageWriteRepository>();

        var existingSender = new User(
            MessageTestUtilities.ValidUserFirstName,
            MessageTestUtilities.ValidUserLastName,
            MessageTestUtilities.ValidUserEmail,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidUserProfileImage)
        {
            Id = MessageTestUtilities.ValidCurrentUserId,
        };

        var existingMessageSender = new User(
            MessageTestUtilities.ValidUserFirstName,
            MessageTestUtilities.ValidUserLastName,
            MessageTestUtilities.ValidUserEmail,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidUserProfileImage)
        {
            Id = MessageTestUtilities.ValidMessageCurrentUserId,
        };

        var existingReceiver = new User(
            MessageTestUtilities.ValidUserFirstName,
            MessageTestUtilities.ValidUserLastName,
            MessageTestUtilities.ValidUserEmail,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidUserProfileImage)
        {
            Id = MessageTestUtilities.ValidReceiverId
        };

        var existingMessageReceiver = new User(
            MessageTestUtilities.ValidUserFirstName,
            MessageTestUtilities.ValidUserLastName,
            MessageTestUtilities.ValidUserEmail,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidUserProfileImage)
        {
            Id = MessageTestUtilities.ValidMessageReceiverId
        };

        var existingMessage = new Message(
            MessageTestUtilities.ValidContent,
            MessageTestUtilities.ValidMessageCurrentUserId,
            MessageTestUtilities.ValidMessageReceiverId)
        {
            Id = MessageTestUtilities.ValidId,
            Sender = existingMessageSender,
            Receiver = existingMessageReceiver
        };

        var existingMessagePaginationList = new PaginationList<Message>(
            [existingMessage],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue);

        MessageReadRepository.GetByIdAsync(
            MessageTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingMessage);

        MessageWriteRepository.GetByIdAsync(
            MessageTestUtilities.ValidId,
            CancellationToken)
            .Returns(existingMessage);

        UserWriteRepository.GetByIdAsync(
            MessageTestUtilities.ValidCurrentUserId,
            CancellationToken)
            .Returns(existingSender);

        UserWriteRepository.GetByIdAsync(
            MessageTestUtilities.ValidReceiverId,
            CancellationToken)
            .Returns(existingReceiver);

        UserWriteRepository.GetByIdAsync(
            MessageTestUtilities.ValidMessageCurrentUserId,
            CancellationToken)
            .Returns(existingMessageSender);

        UserWriteRepository.GetByIdAsync(
            MessageTestUtilities.ValidMessageReceiverId,
            CancellationToken)
            .Returns(existingMessageReceiver);

        MessageReadRepository
            .GetAllAsync(Arg.Is<MessageCollectionReadQuery>(m =>
                                                                        m.CurrentUserId == MessageTestUtilities.ValidMessageCurrentUserId &&
                                                                        m.ReceiverId == MessageTestUtilities.ValidMessageReceiverId &&
                                                                        m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken)
            .Returns(existingMessagePaginationList);
    }
}
