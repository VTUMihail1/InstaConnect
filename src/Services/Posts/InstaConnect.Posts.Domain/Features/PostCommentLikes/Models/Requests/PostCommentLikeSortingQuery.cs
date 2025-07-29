using InstaConnect.Common.Models.Enums;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeSortingQuery(
    SortOrder Order,
    PostCommentLikeSortProperty Property);
