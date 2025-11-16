using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentQuerySorting(
    CommonSortOrder Order,
    PostCommentSortProperty Property);
