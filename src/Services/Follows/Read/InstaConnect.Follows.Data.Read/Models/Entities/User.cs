using InstaConnect.Shared.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Read.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public ICollection<Follow> Followers { get; set; } = new List<Follow>();

    public ICollection<Follow> Followings { get; set; } = new List<Follow>();
}


