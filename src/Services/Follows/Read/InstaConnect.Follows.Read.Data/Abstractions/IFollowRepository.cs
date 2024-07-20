﻿using InstaConnect.Follows.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Follows.Read.Data.Abstractions;

public interface IFollowRepository : IBaseReadRepository<Follow>
{
    Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken);
}