﻿using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostReadRepository
{
    Task<PaginationList<Post>> GetAllAsync(PostCollectionReadQuery query, CancellationToken cancellationToken);
    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
