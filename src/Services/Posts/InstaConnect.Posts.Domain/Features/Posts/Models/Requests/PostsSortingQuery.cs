using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostsSortingQuery(
    CommonSortOrder Order,
    PostsSortTerm Term) : ISortingQuery<PostsSortTerm>;
