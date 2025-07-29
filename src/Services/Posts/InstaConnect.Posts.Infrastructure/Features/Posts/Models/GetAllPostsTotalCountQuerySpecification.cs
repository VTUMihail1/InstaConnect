using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetAllPostsTotalCountQuerySpecification(
    string Sql,
    GetAllPostsTotalCountQueryParameters Parameters);
