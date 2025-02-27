using AutoMapper;

using InstaConnect.Messages.Application.Extensions;
using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;
using InstaConnect.Messages.Domain.Features.Users.Abstractions;
using InstaConnect.Messages.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Helpers;
using InstaConnect.Shared.Domain.Models.Pagination;

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
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength),
            SharedTestUtilities.GetMaxDate(),
            SharedTestUtilities.GetMaxDate());

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
        var message = new Message(
            SharedTestUtilities.GetAverageString(MessageConfigurations.IdMaxLength, MessageConfigurations.IdMinLength),
            SharedTestUtilities.GetAverageString(MessageConfigurations.ContentMaxLength, MessageConfigurations.ContentMinLength),
            sender,
            receiver,
            SharedTestUtilities.GetMaxDate(),
            SharedTestUtilities.GetMaxDate());

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

        var message = new Message(
            SharedTestUtilities.GetAverageString(MessageConfigurations.IdMaxLength, MessageConfigurations.IdMinLength),
            SharedTestUtilities.GetAverageString(MessageConfigurations.ContentMaxLength, MessageConfigurations.ContentMinLength),
            sender,
            receiver,
            SharedTestUtilities.GetMaxDate(),
            SharedTestUtilities.GetMaxDate());

        MessageFactory.Get(sender.Id, receiver.Id, MessageTestUtilities.ValidAddContent)
            .Returns(message);

        return message;
    }
}
