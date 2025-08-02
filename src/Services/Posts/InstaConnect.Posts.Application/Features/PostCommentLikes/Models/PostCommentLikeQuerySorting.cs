using InstaConnect.Common.Models.Enums;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models;

public record PostCommentLikeQuerySorting(
    SortOrder Order,
    PostCommentLikeSortProperty Property);
