using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Business.Commands.PostComments.UpdatePost
{
    public class UpdatePostCommentCommand : ICommand
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }
    }
}
