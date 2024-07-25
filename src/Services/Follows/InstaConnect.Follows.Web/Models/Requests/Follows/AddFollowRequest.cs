using InstaConnect.Follows.Write.Web.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Write.Web.Models.Requests.Follows;

public class AddFollowRequest
{
    [FromBody]
    public AddFollowBindingModel AddFollowBindingModel { get; set; } = new(string.Empty);
}
