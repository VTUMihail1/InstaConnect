﻿using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;
public interface IFollowWriteRepository
{
    void Add(Follow follow);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(Follow follow);
    Task<Follow?> GetByFollowerIdAndFollowingIdAsync(string followerId, string followingId, CancellationToken cancellationToken);
    Task<Follow?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
