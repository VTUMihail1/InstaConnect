using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQueryRequest, PostLikePaginationQueryViewModel>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IPostReadRepository _postReadRepository;
    private readonly IApplicationMapper _applicationMapper;

    public GetAllPostLikesQueryHandler(
        IPostLikeService postLikeService,
        IPostReadRepository postReadRepository,
        IApplicationMapper applicationMapper)
    {
        _postLikeService = postLikeService;
        _postReadRepository = postReadRepository;
        _applicationMapper = applicationMapper;
    }

    public async Task<PostLikePaginationQueryViewModel> Handle(
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postReadRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var filteredCollectionQuery = _applicationMapper.Map<PostLikeCollectionReadQuery>(request);

        var postLikes = await _postLikeService.GetAllAsync(existingPost, filteredCollectionQuery, cancellationToken);
        var response = _applicationMapper.Map<PostLikePaginationQueryViewModel>(postLikes);

        return response;
    }
}
