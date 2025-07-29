using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;
public record PostCommentCollection(
    ICollection<PostComment> Data, 
    int Page, 
    int PageSize, 
    int TotalCount, 
    bool HasNextPage, 
    bool HasPreviousPage);
