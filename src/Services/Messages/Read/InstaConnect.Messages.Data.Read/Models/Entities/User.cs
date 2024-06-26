using InstaConnect.Shared.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data.Read.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public ICollection<Message> SenderMessages { get; set; } = new List<Message>();

    public ICollection<Message> ReceiverMessages { get; set; } = new List<Message>();
}


