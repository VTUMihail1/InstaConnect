using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeSortingQuery(
    CommonSortOrder Order,
    PostCommentLikeSortProperty Property);
