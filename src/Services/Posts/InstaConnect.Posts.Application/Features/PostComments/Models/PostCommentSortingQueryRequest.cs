using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentSortingQueryRequest(
    CommonSortOrder Order,
    PostCommentSortProperty Property);
