using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentSortingQuery(
    CommonSortOrder Order,
    PostCommentSortProperty Property);
