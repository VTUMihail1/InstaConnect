using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
public record PostLikeCollection(
    ICollection<PostLike> Data, 
    int Page, 
    int PageSize, 
    int TotalCount, 
    bool HasNextPage, 
    bool HasPreviousPage);
