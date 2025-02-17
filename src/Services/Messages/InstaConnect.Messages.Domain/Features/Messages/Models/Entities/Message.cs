using InstaConnect.Messages.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Messages.Domain.Features.Messages.Models.Entities;

public class Message : BaseEntity
{
    public Message(string content, string senderId, string receiverId)
    {
        Content = content;
        SenderId = senderId;
        ReceiverId = receiverId;
    }

    public Message(string content, User sender, User receiver)
    {
        Content = content;
        SenderId = sender.Id;
        ReceiverId = receiver.Id;
        Sender = sender;
        Receiver = receiver;
    }

    public string Content { get; set; }

    public string SenderId { get; }

    public User? Sender { get; }

    public string ReceiverId { get; }

    public User? Receiver { get; }
}
