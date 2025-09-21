using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
public record FollowCollection(
    ICollection<Follow> Data, 
    int Page, 
    int PageSize, 
    int TotalCount, 
    bool HasNextPage, 
    bool HasPreviousPage);
