using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Models.Requests.Messages;

public class GetMessageByIdRequest
{
    [FromRoute]
    public string Id { get; set; }
}
