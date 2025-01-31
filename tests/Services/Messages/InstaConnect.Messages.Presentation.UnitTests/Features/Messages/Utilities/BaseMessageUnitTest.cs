using AutoMapper;
using InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Application.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Models.Users;
using InstaConnect.Shared.Presentation.UnitTests.Utilities;
using NSubstitute;
using MessageCommandProfile = InstaConnect.Messages.Presentation.Features.Messages.Mappings.MessagesCommandProfile;
using MessageQueryProfile = InstaConnect.Messages.Presentation.Features.Messages.Mappings.MessagesQueryProfile;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Utilities;

public abstract class BaseMessageUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseMessageUnitTest()
    {
        CancellationToken = new();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MessageCommandProfile>();
                    cfg.AddProfile<MessageQueryProfile>();
                })));
    }

    public User CreateUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        return user;
    }

    public Message CreateMessage()
    {
        var sender = CreateUser();
        var receiver = CreateUser();
        var message = new Message(MessageTestUtilities.ValidContent, sender, receiver);

        var messageQueryViewModel = new MessageQueryViewModel(
            message.Id,
            message.SenderId,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage,
            message.ReceiverId,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage,
            MessageTestUtilities.ValidContent);

        var messageCommandViewModel = new MessageCommandViewModel(message.Id);
        var messagePaginationCollectionModel = new MessagePaginationQueryViewModel(
            [messageQueryViewModel],
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue,
            MessageTestUtilities.ValidTotalCountValue,
            false,
            false);

        InstaConnectSender
            .SendAsync(Arg.Is<GetAllMessagesQuery>(m =>
                  m.CurrentUserId == sender.Id &&
                  m.ReceiverId == receiver.Id &&
                  m.ReceiverName == UserTestUtilities.ValidName &&
                  m.SortOrder == MessageTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == MessageTestUtilities.ValidSortPropertyName &&
                  m.Page == MessageTestUtilities.ValidPageValue &&
                  m.PageSize == MessageTestUtilities.ValidPageSizeValue), CancellationToken)
            .Returns(messagePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Is<GetMessageByIdQuery>(m => 
                  m.Id == message.Id &&
                  m.CurrentUserId == sender.Id), CancellationToken)
            .Returns(messageQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<AddMessageCommand>(m => 
                  m.CurrentUserId == sender.Id &&
                  m.ReceiverId == receiver.Id &&
                  m.Content == MessageTestUtilities.ValidAddContent), CancellationToken)
            .Returns(messageCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Is<UpdateMessageCommand>(m =>
                  m.Id == message.Id &&
                  m.CurrentUserId == sender.Id &&
                  m.Content == MessageTestUtilities.ValidUpdateContent), CancellationToken)
            .Returns(messageCommandViewModel);

        return message;
    }
}
