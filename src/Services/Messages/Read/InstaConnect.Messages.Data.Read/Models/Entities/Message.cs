using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Messages.Data.Read.Models.Entities;

public class Message : BaseEntity
{
    public string Content { get; set; }

    public string SenderId { get; set; }

    public User Sender { get; set; }

    public string ReceiverId { get; set; }

    public User Receiver { get; set; }
}
