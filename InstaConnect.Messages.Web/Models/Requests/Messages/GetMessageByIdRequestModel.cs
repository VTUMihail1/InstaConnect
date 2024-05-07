using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Models.Requests.PostComment;

public class GetMessageByIdRequestModel
{
    [FromRoute]
    public string Id { get; set; }
}
