using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Web.Models.Requests.Follows
{
    public class DeleteFollowRequestModel
    {
        [FromRoute]
        public string Id { get; set; }

        [FromRoute]
        public string FollowerId { get; set; }
    }
}
