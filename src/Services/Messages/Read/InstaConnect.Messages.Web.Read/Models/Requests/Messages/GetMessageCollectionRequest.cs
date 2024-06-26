using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Read.Models.Requests.Messages;

public class GetMessageCollectionRequest : CollectionRequest
{
    [FromQuery(Name = "senderName")]
    public string SenderName { get; set; } = string.Empty;

    [FromQuery(Name = "receiverName")]
    public string ReceiverName { get; set; } = string.Empty;
}
