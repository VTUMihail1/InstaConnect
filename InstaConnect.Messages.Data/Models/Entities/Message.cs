using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Messages.Data.Models.Entities;

public class Message : BaseEntity
{
    public string SenderId { get; set; }

    public string ReceiverId { get; set; }

    public string Content { get; set; }
}
