using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPost
{
    public class AddPostCommentLikeCommand : ICommand
    {
        public string UserId { get; set; }

        public string PostCommentId { get; set; }
    }
}
