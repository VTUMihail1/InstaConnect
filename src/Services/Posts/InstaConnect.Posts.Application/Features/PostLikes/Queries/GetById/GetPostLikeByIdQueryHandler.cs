using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQuery, PostLikeQueryViewModel>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;

    public GetPostLikeByIdQueryHandler(
        IPostLikeService postLikeService,
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postReadRepository)
    {
        _postLikeService = postLikeService;
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postReadRepository;
    }

    public async Task<PostLikeQueryViewModel> Handle(
        GetPostLikeByIdQuery request,
    CancellationToken cancellationToken)
    {
        var existingPost = await _postReadRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var postLike = await _postLikeService.GetByIdAsync(existingPost, request.Id, cancellationToken);
        var response = _instaConnectMapper.Map<PostLikeQueryViewModel>(postLike);

        return response;
    }
}
