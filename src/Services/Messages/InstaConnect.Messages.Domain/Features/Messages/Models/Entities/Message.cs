using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Messages.Data.Features.Messages.Models.Entities;

public class Message : BaseEntity
{
    public Message(string content, string senderId, string receiverId)
    {
        Content = content;
        SenderId = senderId;
        ReceiverId = receiverId;
    }

    public string Content { get; set; }

    public string SenderId { get; }

    public User? Sender { get; set; }

    public string ReceiverId { get; }

    public User? Receiver { get; set; }
}
