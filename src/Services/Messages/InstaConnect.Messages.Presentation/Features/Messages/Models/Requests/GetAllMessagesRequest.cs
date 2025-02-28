using System.Security.Claims;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public record GetAllMessagesRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId = "",
    [FromQuery(Name = "receiverId")] string ReceiverId = "",
    [FromQuery(Name = "receiverName")] string ReceiverName = "",
    [FromQuery(Name = "sortOrder")] SortOrder SortOrder = SortOrder.ASC,
    [FromQuery(Name = "sortPropertyName")] string SortPropertyName = "CreatedAt",
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20
);
