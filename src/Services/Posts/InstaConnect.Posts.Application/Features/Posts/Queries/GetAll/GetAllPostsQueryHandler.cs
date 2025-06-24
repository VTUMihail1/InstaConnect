using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, GetAllPostsQueryResponse>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;

    public GetAllPostsQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postRepository;
    }

    public async Task<GetAllPostsQueryResponse> Handle(
        GetAllPostsQuery request,
        CancellationToken cancellationToken)
    {
        var parameters = _instaConnectMapper.Map<GetAllPostsRequest>(request);

        var collection = await _postReadRepository.GetAllAsync(parameters, cancellationToken);
        var response = _instaConnectMapper.Map<GetAllPostsQueryResponse>(collection);

        return response;
    }
}
