using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record ChatByParticipantSortingApiRequest(
    [FromQuery(Name = "sortOrder")] CommonSortOrder Order = CommonSortOrder.ASC,
    [FromQuery(Name = "sortProperty")] ChatByParticipantSortProperty Property = ChatByParticipantSortProperty.ByCreatedAt);
