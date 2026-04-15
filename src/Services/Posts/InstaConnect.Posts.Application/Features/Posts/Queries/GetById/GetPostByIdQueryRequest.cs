using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public record GetPostByIdQueryRequest(string Id, string CurrentUserId) : IQueryRequest<GetPostByIdQueryResponse>, ICurrentUserableQueryRequest;
