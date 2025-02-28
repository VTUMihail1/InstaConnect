using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Helpers;
using InstaConnect.Messages.Application.Extensions;
using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;
using InstaConnect.Messages.Domain.Features.Users.Abstractions;
using InstaConnect.Messages.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;

public abstract class BaseMessageUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IMessageSender MessageSender { get; }

    protected IMessageFactory MessageFactory { get; }

    protected IMessageService MessageService { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IMessageReadRepository MessageReadRepository { get; }

    protected IMessageWriteRepository MessageWriteRepository { get; }

    protected BaseMessageUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(ApplicationReference.Assembly))));
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = new EntityPropertyValidator();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        MessageSender = Substitute.For<IMessageSender>();
        MessageFactory = Substitute.For<IMessageFactory>();
        MessageService = Substitute.For<IMessageService>();
        MessageReadRepository = Substitute.For<IMessageReadRepository>();
        MessageWriteRepository = Substitute.For<IMessageWriteRepository>();


    }

    private User CreateUserUtil()
    {
        var user = UserTestUtilities.CreateUser();

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }

    private Message CreateMessageUtil(User sender, User receiver)
    {
        var message = MessageTestUtilities.CreateMessage(sender, receiver);

        var messagePaginationList = new PaginationList<Message>(
            [message],
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue,
            MessageTestUtilities.ValidTotalCountValue);

        MessageReadRepository.GetByIdAsync(
            message.Id,
            CancellationToken)
            .Returns(message);

        MessageWriteRepository.GetByIdAsync(
            message.Id,
            CancellationToken)
            .Returns(message);

        MessageService
            .When(x => x.Update(message, MessageTestUtilities.ValidUpdateContent))
            .Do(call =>
            {
                var updatedMessage = call.Arg<Message>();
                updatedMessage.Update(MessageTestUtilities.ValidUpdateContent, MessageTestUtilities.ValidUpdateUpdatedAtUtc);
            });

        MessageReadRepository
            .GetAllAsync(Arg.Is<MessageCollectionReadQuery>(m =>
                                                                        m.CurrentUserId == sender.Id &&
                                                                        m.ReceiverId == receiver.Id &&
                                                                        m.ReceiverName == receiver.UserName &&
                                                                        m.Page == MessageTestUtilities.ValidPageValue &&
                                                                        m.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == MessageTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == MessageTestUtilities.ValidSortPropertyName), CancellationToken)
            .Returns(messagePaginationList);

        return message;
    }

    protected Message CreateMessage()
    {
        var sender = CreateUser();
        var receiver = CreateUser();
        var message = CreateMessageUtil(sender, receiver);

        return message;
    }

    public Message CreateMessageFactory()
    {
        var sender = CreateUser();
        var receiver = CreateUser();

        var message = MessageTestUtilities.CreateMessage(sender, receiver);

        MessageFactory.Get(sender.Id, receiver.Id, MessageTestUtilities.ValidAddContent)
            .Returns(message);

        return message;
    }
}
