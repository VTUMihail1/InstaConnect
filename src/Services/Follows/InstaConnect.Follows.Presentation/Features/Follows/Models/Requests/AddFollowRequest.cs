using InstaConnect.Follows.Presentation.Features.Follows.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public class AddFollowRequest
{
    [FromBody]
    public AddFollowBindingModel AddFollowBindingModel { get; set; } = new(string.Empty);
}
