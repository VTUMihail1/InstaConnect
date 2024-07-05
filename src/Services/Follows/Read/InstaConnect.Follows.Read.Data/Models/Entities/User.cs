﻿using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Follows.Read.Data.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string? ProfileImage { get; set; } = string.Empty;

    public ICollection<Follow> Followers { get; set; } = [];

    public ICollection<Follow> Followings { get; set; } = [];
}


