using InstaConnect.Shared.Presentation.Binders.FromClaim;
using System.Security.Claims;
using InstaConnect.Shared.Presentation.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public class GetAllMessagesRequest : CollectionReadRequest
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public string CurrentUserId { get; set; } = string.Empty;

    [FromQuery(Name = "receiverId")]
    public string ReceiverId { get; set; } = string.Empty;

    [FromQuery(Name = "receiverName")]
    public string ReceiverName { get; set; } = string.Empty;
}
