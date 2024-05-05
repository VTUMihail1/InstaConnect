using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Commands.PostComments.DeletePostComment
{
    public class DeletePostCommentCommand : ICommand
    {
        public string Id { get; set; }
    }
}
