using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentQuerySorting(
    SortOrder Order,
    PostCommentSortProperty Property);
