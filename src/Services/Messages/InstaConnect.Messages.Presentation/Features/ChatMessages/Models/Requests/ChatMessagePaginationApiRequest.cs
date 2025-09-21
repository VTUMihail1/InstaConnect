namespace InstaConnect.ChatMessages.Presentation.Features.ChatMessages.Models.Requests;

public record ChatMessagePaginationApiRequest(
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20);
