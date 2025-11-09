using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeQuerySorting(
    SortOrder Order,
    PostCommentLikeSortProperty Property);
