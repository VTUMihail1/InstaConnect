using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Follows.Business.Commands.Follows.AddFollow
{
    public class AddFollowCommand : ICommand
    {
        public string FollowerId { get; set; }

        public string FollowingId { get; set; }
    }
}
