using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Read.Models.Requests.Messages;

public class GetMessageByIdRequest
{
    [FromRoute]
    public string Id { get; set; }
}
