using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

internal class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQuery, PostCommentLikePaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;
    private readonly IPostCommentLikeService _postCommentLikeService;

    public GetAllPostCommentLikesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postReadRepository,
        IPostCommentLikeService postCommentLikeService)
    {
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postReadRepository;
        _postCommentLikeService = postCommentLikeService;
    }

    public async Task<PostCommentLikePaginationQueryViewModel> Handle(
        GetAllPostCommentLikesQuery request,
        CancellationToken cancellationToken)
    {
        var existingPost = await _postReadRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var filteredCollectionQuery = _instaConnectMapper.Map<PostCommentLikeCollectionReadQuery>(request);

        var postCommentLikes = await _postCommentLikeService.GetAllAsync(
            existingPost, request.PostCommentId, filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<PostCommentLikePaginationQueryViewModel>(postCommentLikes);

        return response;
    }
}
