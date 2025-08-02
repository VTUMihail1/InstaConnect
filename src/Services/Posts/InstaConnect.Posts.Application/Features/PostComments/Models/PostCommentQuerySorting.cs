using InstaConnect.Common.Models.Enums;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Models;

public record PostCommentQuerySorting(
    SortOrder Order,
    PostCommentSortProperty Property);
