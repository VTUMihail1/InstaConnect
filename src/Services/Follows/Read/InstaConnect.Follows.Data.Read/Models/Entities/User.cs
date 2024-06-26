using InstaConnect.Shared.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Read.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public ICollection<Follow> Followers { get; set; } = new List<Follow>();

    public ICollection<Follow> Followings { get; set; } = new List<Follow>();
}


