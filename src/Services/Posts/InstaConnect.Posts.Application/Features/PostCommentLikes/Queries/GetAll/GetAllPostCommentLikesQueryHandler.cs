using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

internal class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQuery, PostCommentLikePaginationQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostReadRepository _postReadRepository;
    private readonly IPostCommentLikeService _postCommentLikeService;

    public GetAllPostCommentLikesQueryHandler(
        IApplicationMapper applicationMapper,
        IPostReadRepository postReadRepository,
        IPostCommentLikeService postCommentLikeService)
    {
        _applicationMapper = applicationMapper;
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

        var filteredCollectionQuery = _applicationMapper.Map<PostCommentLikeCollectionReadQuery>(request);

        var postCommentLikes = await _postCommentLikeService.GetAllAsync(
            existingPost, request.PostCommentId, filteredCollectionQuery, cancellationToken);
        var response = _applicationMapper.Map<PostCommentLikePaginationQueryViewModel>(postCommentLikes);

        return response;
    }
}
