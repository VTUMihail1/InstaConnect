using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Web.Models.Requests.Post
{
    public class AddPostCommentRequestModel
    {
        public string UserId { get; set; }

        public string PostId { get; set; }

        public string? PostCommentId { get; set; }

        public string Content { get; set; }
    }
}
