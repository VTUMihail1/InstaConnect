using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQuery, PostLikeQueryViewModel>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostReadRepository _postReadRepository;

    public GetPostLikeByIdQueryHandler(
        IPostLikeService postLikeService,
        IApplicationMapper applicationMapper,
        IPostReadRepository postReadRepository)
    {
        _postLikeService = postLikeService;
        _applicationMapper = applicationMapper;
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
        var response = _applicationMapper.Map<PostLikeQueryViewModel>(postLike);

        return response;
    }
}
