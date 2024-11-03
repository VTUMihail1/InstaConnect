using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Messages.Data.Features.Users.Models.Entities;

public class User : BaseEntity
{
    public User(
        string firstName,
        string lastName,
        string email,
        string userName,
        string? profileImage)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        ProfileImage = profileImage;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string? ProfileImage { get; set; }

    public ICollection<Message> SenderMessages { get; set; } = [];

    public ICollection<Message> ReceiverMessages { get; set; } = [];
}


