using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQuery, PostLikePaginationQueryViewModel>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IPostReadRepository _postReadRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public GetAllPostLikesQueryHandler(
        IPostLikeService postLikeService,
        IPostReadRepository postReadRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _postLikeService = postLikeService;
        _postReadRepository = postReadRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task<PostLikePaginationQueryViewModel> Handle(
        GetAllPostLikesQuery request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postReadRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var filteredCollectionQuery = _instaConnectMapper.Map<PostLikeCollectionReadQuery>(request);

        var postLikes = await _postLikeService.GetAllAsync(existingPost, filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostLikePaginationQueryViewModel>(postLikes);

        return response;
    }
}
