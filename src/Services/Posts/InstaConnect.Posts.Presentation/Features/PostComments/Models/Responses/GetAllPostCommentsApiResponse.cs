using InstaConnect.PostComments.Application.Features.PostComments.Models;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsApiResponse(
    ICollection<PostCommentApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
