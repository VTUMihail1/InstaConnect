﻿using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetFollowById;

public class GetFollowByIdQuery : IQuery<FollowViewModel>
{
    public string Id { get; set; } = string.Empty;
}