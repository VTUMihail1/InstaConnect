using InstaConnect.Shared.Presentation.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public class GetAllMessagesRequest : CollectionReadRequest
{
    [FromQuery(Name = "receiverId")]
    public string ReceiverId { get; set; } = string.Empty;

    [FromQuery(Name = "receiverName")]
    public string ReceiverName { get; set; } = string.Empty;
}
