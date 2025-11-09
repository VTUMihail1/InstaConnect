using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record ChatByParticipantSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] ChatByParticipantSortProperty Property = ChatByParticipantSortProperty.ByCreatedAt);
