using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesApiRequest(
	[UserIdFromClaim] string CurrentUserId,
	[FromRoute] string ParticipantTwoId,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] ChatMessagesSortTerm SortTerm = ChatMessageDefaultValues.SortTerm,
	[FromQuery] int Page = ChatMessageDefaultValues.Page,
	[FromQuery] int PageSize = ChatMessageDefaultValues.PageSize) : ISortableApiRequest<ChatMessagesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
