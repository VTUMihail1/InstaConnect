namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQueryRequest, GetPostByIdQueryResponse>
{
    private readonly IPostService _postService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostIncludeQueryBuilderFactory _postIncludeQueryBuilderFactory;

    public GetPostByIdQueryHandler(
        IPostService postService,
        IApplicationMapper applicationMapper,
        IPostIncludeQueryBuilderFactory postIncludeQueryBuilderFactory)
    {
        _postService = postService;
        _applicationMapper = applicationMapper;
        _postIncludeQueryBuilderFactory = postIncludeQueryBuilderFactory;
    }

    public async Task<GetPostByIdQueryResponse> Handle(
        GetPostByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _postIncludeQueryBuilderFactory.Create().WithUser().Build();
        var serviceRequest = _applicationMapper.Map<GetPostByIdQuery>(request).AddInclude(include);
        var post = await _postService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetPostByIdQueryResponse>(post);

        return response;
    }
}
