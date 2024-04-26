using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Messages.Business.Commands.PostComments.UpdatePostComment
{
    public class UpdateMessageCommand : ICommand
    {
        public string Id { get; set; }

        public string SenderId { get; set; }

        public string Content { get; set; }
    }
}
