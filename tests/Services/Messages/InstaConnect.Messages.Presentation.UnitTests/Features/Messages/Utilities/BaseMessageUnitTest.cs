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
using InstaConnect.Shared.Common.Utilities;
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

    private User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

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
            SharedTestUtilities.GetAverageString(MessageConfigurations.ContentMaxLength, MessageConfigurations.ContentMinLength),
            sender, 
            receiver);

        var messageQueryViewModel = new MessageQueryViewModel(
            message.Id,
            message.SenderId,
            sender.UserName,
            sender.ProfileImage,
            message.ReceiverId,
            receiver.UserName,
            receiver.ProfileImage,
            message.Content);

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
                  m.ReceiverName == receiver.UserName &&
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

    protected Message CreateMessage()
    {
        var sender = CreateUser();
        var receiver = CreateUser();
        var message = CreateMessageUtil(sender, receiver);

        return message;
    }
}
