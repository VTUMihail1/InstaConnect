using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Messages.Application.Features.Messages.Commands.Add;
using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAll;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetById;
using InstaConnect.Messages.Common.Tests.Features.Messages.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Presentation.Extensions;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Utilities;

public abstract class BaseMessageUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected BaseMessageUnitTest()
    {
        CancellationToken = new();
        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PresentationReference.Assembly))));
    }

    private static User CreateUserUtil()
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

        return user;
    }

    protected static User CreateUser()
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
