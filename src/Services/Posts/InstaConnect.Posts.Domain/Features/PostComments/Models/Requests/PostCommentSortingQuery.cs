using InstaConnect.Common.Models.Enums;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

public record PostCommentSortingQuery(
    SortOrder Order,
    PostCommentSortProperty Property);
