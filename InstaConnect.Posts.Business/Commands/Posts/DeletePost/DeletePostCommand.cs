using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Commands.Posts.DeletePost
{
    public class DeletePostCommand : ICommand
    {
        public string Id { get; set; }
    }
}
