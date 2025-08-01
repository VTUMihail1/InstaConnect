namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;

public record GetAllPostCommentsQueryParameters(
    string Id,
    string UserId,
    string UserName,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
