using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeSortingQueryRequest(
    CommonSortOrder Order,
    PostCommentLikeSortProperty Property);
