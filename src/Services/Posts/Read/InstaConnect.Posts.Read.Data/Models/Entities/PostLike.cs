﻿using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Read.Data.Models.Entities;

public class PostLike : BaseEntity
{
    public string PostId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public Post Post { get; set; } = new();

    public User User { get; set; } = new();
}