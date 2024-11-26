using AutoMapper;
using InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Application.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Models.Users;
using InstaConnect.Shared.Presentation.UnitTests.Utilities;
using NSubstitute;
using MessageCommandProfile = InstaConnect.Messages.Presentation.Features.Messages.Mappings.MessagesCommandProfile;
using MessageQueryProfile = InstaConnect.Messages.Presentation.Features.Messages.Mappings.MessagesQueryProfile;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Utilities;

public abstract class BaseMessageUnitTest : BaseSharedUnitTest
{
    public BaseMessageUnitTest() : base(
        Substitute.For<IInstaConnectSender>(),
        Substitute.For<ICurrentUserContext>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MessageCommandProfile>();
                    cfg.AddProfile<MessageQueryProfile>();
                }))))
    {
        var existingMessageQueryViewModel = new MessageQueryViewModel(
            MessageTestUtilities.ValidId,
            MessageTestUtilities.ValidCurrentUserId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidUserProfileImage,
            MessageTestUtilities.ValidReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidUserProfileImage,
            MessageTestUtilities.ValidContent);

        var existingMessageCommandViewModel = new MessageCommandViewModel(MessageTestUtilities.ValidId);
        var existingCurrentUserModel = new CurrentUserModel(MessageTestUtilities.ValidCurrentUserId, MessageTestUtilities.ValidUserName);
        var existingMessagePaginationCollectionModel = new MessagePaginationQueryViewModel(
            [existingMessageQueryViewModel],
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue,
            MessageTestUtilities.ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllMessagesQuery>(), CancellationToken)
            .Returns(existingMessagePaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetMessageByIdQuery>(), CancellationToken)
            .Returns(existingMessageQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<AddMessageCommand>(), CancellationToken)
            .Returns(existingMessageCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<UpdateMessageCommand>(), CancellationToken)
            .Returns(existingMessageCommandViewModel);
    }
}
