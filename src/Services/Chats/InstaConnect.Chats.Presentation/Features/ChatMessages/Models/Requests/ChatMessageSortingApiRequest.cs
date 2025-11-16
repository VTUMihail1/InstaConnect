using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record ChatMessageSortingApiRequest(
    [FromQuery(Name = "sortOrder")] CommonSortOrder Order = CommonSortOrder.ASC,
    [FromQuery(Name = "sortProperty")] ChatMessageSortProperty Property = ChatMessageSortProperty.ByCreatedAt);
