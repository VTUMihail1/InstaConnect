using InstaConnect.Common.Models.Enums;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Presentation.Features.ChatMessages.Models.Requests;

public record ChatMessageSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] ChatMessageSortProperty Property = ChatMessageSortProperty.ByCreatedAt);
