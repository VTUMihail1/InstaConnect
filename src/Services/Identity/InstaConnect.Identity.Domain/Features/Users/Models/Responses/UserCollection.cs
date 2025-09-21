using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Entities;
using System.Collections.Generic;

namespace InstaConnect.Users.Domain.Features.Users.Models.Responses;
public record UserCollection(
    ICollection<User> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
