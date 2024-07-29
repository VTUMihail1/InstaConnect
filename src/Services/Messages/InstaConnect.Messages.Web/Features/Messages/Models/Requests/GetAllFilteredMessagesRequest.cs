using InstaConnect.Shared.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Features.Messages.Models.Requests;

public class GetAllFilteredMessagesRequest : CollectionReadRequest
{
    [FromQuery(Name = "receiverId")]
    public string ReceiverId { get; set; } = string.Empty;

    [FromQuery(Name = "receiverName")]
    public string ReceiverName { get; set; } = string.Empty;
}
