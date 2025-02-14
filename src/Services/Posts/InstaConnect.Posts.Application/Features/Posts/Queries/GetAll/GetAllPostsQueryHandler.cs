using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, PostPaginationQueryViewModel>
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

    public async Task<PostPaginationQueryViewModel> Handle(
        GetAllPostsQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostCollectionReadQuery>(request);

        var posts = await _postReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostPaginationQueryViewModel>(posts);

        return response;
    }
}
