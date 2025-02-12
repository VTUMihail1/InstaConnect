using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Abstract;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQuery, PostLikePaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostLikeReadRepository _postLikeReadRepository;

    public GetAllPostLikesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostLikeReadRepository postLikeRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postLikeReadRepository = postLikeRepository;
    }

    public async Task<PostLikePaginationQueryViewModel> Handle(
        GetAllPostLikesQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<PostLikeCollectionReadQuery>(request);

        var postLikes = await _postLikeReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostLikePaginationQueryViewModel>(postLikes);

        return response;
    }
}
