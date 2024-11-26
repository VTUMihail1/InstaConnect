using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public class GetFollowByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
