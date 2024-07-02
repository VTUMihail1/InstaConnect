using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Messages.Data.Read.Models.Entities;

public class Message : BaseEntity
{
    public string Content { get; set; } = string.Empty;

    public string SenderId { get; set; } = string.Empty;

    public User Sender { get; set; } = new();

    public string ReceiverId { get; set; } = string.Empty;

    public User Receiver { get; set; } = new();
}
