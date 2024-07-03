using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Messages.Read.Data.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public ICollection<Message> SenderMessages { get; set; } = new List<Message>();

    public ICollection<Message> ReceiverMessages { get; set; } = new List<Message>();
}


