using InstaConnect.Common.Models.Enums;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record ChatByParticipantSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] ChatByParticipantSortProperty Property = ChatByParticipantSortProperty.ByCreatedAt);
