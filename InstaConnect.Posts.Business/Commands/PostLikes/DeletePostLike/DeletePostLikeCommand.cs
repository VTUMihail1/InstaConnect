using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Commands.PostComments.DeletePost
{
    public class DeletePostLikeCommand : ICommand
    {
        public string Id { get; set; }

        public string UserId { get; set; }
    }
}
