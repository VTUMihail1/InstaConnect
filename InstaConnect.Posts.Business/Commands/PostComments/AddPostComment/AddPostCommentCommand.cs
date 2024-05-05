using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPostComment
{
    public class AddPostCommentCommand : ICommand
    {
        public string PostId { get; set; }

        public string PostCommentId { get; set; }

        public string Content { get; set; }
    }
}
