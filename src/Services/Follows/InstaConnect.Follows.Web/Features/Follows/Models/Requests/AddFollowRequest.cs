using InstaConnect.Follows.Web.Features.Follows.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Features.Follows.Models.Requests;

public class AddFollowRequest
{
    [FromBody]
    public AddFollowBindingModel AddFollowBindingModel { get; set; } = new(string.Empty);
}
