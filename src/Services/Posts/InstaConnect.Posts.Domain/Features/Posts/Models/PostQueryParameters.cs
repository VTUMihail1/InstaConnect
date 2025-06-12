namespace InstaConnect.Posts.Domain.Features.Posts.Models;

public record PostQueryParameters(
    PostFilter Filter,
    PostSorting Sorting,
    PostPagination Pagination);
