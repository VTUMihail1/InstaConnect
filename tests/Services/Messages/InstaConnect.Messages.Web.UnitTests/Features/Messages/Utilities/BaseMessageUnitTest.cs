using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Business.Features.Messages.Utilities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;
using MessageCommandProfile = InstaConnect.Messages.Web.Features.Messages.Mappings.MessagesCommandProfile;
using MessageQueryProfile = InstaConnect.Messages.Web.Features.Messages.Mappings.MessagesQueryProfile;

namespace InstaConnect.Messages.Web.UnitTests.Features.Messages.Utilities;

public abstract class BaseMessageUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string ValidContent;
    protected readonly string ValidReceiverId;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidUserName;
    protected readonly string ValidUserProfileImage;

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
        ValidId = GetAverageString(MessageBusinessConfigurations.ID_MAX_LENGTH, MessageBusinessConfigurations.ID_MIN_LENGTH);
        ValidContent = GetAverageString(MessageBusinessConfigurations.CONTENT_MAX_LENGTH, MessageBusinessConfigurations.CONTENT_MIN_LENGTH);
        ValidReceiverId = GetAverageString(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH);
        ValidCurrentUserId = GetAverageString(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH, MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH);
        ValidUserName = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);
        ValidUserProfileImage = GetAverageString(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH, MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH);

        var existingMessageQueryViewModel = new MessageQueryViewModel(
            ValidId,
            ValidCurrentUserId,
            ValidUserName,
            ValidUserProfileImage,
            ValidReceiverId,
            ValidUserName,
            ValidUserProfileImage,
            ValidContent);

        var existingMessageCommandViewModel = new MessageCommandViewModel(ValidId);
        var existingCurrentUserModel = new CurrentUserModel(ValidCurrentUserId, ValidUserName);
        var existingMessagePaginationCollectionModel = new MessagePaginationQueryViewModel(
            [existingMessageQueryViewModel],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllFilteredMessagesQuery>(), CancellationToken)
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
