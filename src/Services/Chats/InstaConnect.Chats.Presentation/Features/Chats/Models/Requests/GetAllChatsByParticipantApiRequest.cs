using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Users.Utilities;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record GetAllChatsByParticipantApiRequest(
    [FromRoute] string ParticipantId,
    [FromQuery] string ParticipantName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] ChatByParticipantSortProperty SortTerm = ChatDefaultValues.ByParticipantSortProperty,
    [FromQuery] int Page = ChatDefaultValues.Page,
    [FromQuery] int PageSize = ChatDefaultValues.PageSize) : ISortableApiRequest<ChatByParticipantSortProperty>, IPaginatableApiRequest;
