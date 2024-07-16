using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Read.Web.Models.Requests.Messages;

public class GetAllFilteredMessagesRequest : CollectionRequest
{
    public GetAllFilteredMessagesRequest()
    {
        Offset = MessageBusinessConfigurations.OFFSET_MIN_VALUE;
        Limit = MessageBusinessConfigurations.LIMIT_MAX_VALUE;
    }

    [FromQuery(Name = "receiverId")]
    public string ReceiverId { get; set; } = string.Empty;

    [FromQuery(Name = "receiverName")]
    public string ReceiverName { get; set; } = string.Empty;
}
