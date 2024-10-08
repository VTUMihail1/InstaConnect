﻿using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Follows.Data.Features.Follows.Models.Entities;

public class Follow : BaseEntity
{
    public Follow(string followerId, string followingId)
    {
        FollowerId = followerId;
        FollowingId = followingId;
    }

    public string FollowingId { get; }

    public User? Following { get; set; }

    public string FollowerId { get; }

    public User? Follower { get; set; }
}
