using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostsFilterQuery(
    Name UserName,
    string Title);
