namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQueryRequest, GetAllPostLikesQueryResponse>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostLikeIncludeQueryBuilderFactory _postLikeIncludeQueryBuilderFactory;

    public GetAllPostLikesQueryHandler(
        IPostLikeService postLikeService,
        IApplicationMapper applicationMapper,
        IPostLikeIncludeQueryBuilderFactory postLikeIncludeQueryBuilderFactory)
    {
        _postLikeService = postLikeService;
        _applicationMapper = applicationMapper;
        _postLikeIncludeQueryBuilderFactory = postLikeIncludeQueryBuilderFactory;
    }

    public async Task<GetAllPostLikesQueryResponse> Handle(
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _postLikeIncludeQueryBuilderFactory.Create().WithUser().Build();
        var serviceRequest = _applicationMapper.Map<GetAllPostLikesQuery>(request).AddInclude(include);
        var collection = await _postLikeService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllPostLikesQueryResponse>(collection);

        return response;
    }
}
