using InstaConnect.PostComments.Application.Features.PostComments.Models;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQueryResponse(
    ICollection<PostCommentQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
