namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record ChatPaginationApiRequest(
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20);
