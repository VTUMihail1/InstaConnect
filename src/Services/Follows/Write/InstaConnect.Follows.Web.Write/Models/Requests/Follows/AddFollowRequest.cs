using InstaConnect.Follows.Web.Write.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Write.Models.Requests.Follows;

public class AddFollowRequest
{
    [FromBody]
    public AddFollowBindingModel AddFollowBindingModel { get; set; } = new();
}
