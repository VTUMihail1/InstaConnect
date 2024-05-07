using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Models.Requests.PostComment;

public class GetMessageCollectionRequestModel : CollectionRequestModel
{
    [FromQuery(Name = "senderId")]
    public string SenderId { get; set; } = string.Empty;

    [FromQuery(Name = "receiverId")]
    public string ReceiverId { get; set; } = string.Empty;
}
