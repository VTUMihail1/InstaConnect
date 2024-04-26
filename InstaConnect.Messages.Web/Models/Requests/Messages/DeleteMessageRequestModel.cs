using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Models.Requests.PostComment
{
    public class DeleteMessageRequestModel
    {
        [FromRoute]
        public string Id { get; set; }

        [FromRoute]
        public string SenderId { get; set; }
    }
}
