using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Features.Messages.Models.Requests;

public class GetMessageByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
