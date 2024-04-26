using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Models.Requests.Follows
{
    public class GetFollowByIdRequestModel
    {
        [FromRoute]
        public string Id { get; set; }
    }
}
