using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikeSortingQuery(
    SortOrder Order,
    PostLikeSortProperty Property);
