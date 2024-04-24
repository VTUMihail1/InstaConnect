using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPost
{
    public class AddPostLikeCommand : ICommand
    {
        public string UserId { get; set; }

        public string PostId { get; set; }
    }
}
