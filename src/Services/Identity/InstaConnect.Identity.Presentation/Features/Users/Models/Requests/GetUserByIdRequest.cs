using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public class GetUserByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
