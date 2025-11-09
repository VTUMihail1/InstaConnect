namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

internal class GetPostCommentByIdQueryHandler : IQueryHandler<GetPostCommentByIdQueryRequest, GetPostCommentByIdQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;
    private readonly IPostCommentIncludeQueryBuilderFactory _postCommentIncludeQueryBuilderFactory;

    public GetPostCommentByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService,
        IPostCommentIncludeQueryBuilderFactory postCommentIncludeQueryBuilderFactory)
    {
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
        _postCommentIncludeQueryBuilderFactory = postCommentIncludeQueryBuilderFactory;
    }

    public async Task<GetPostCommentByIdQueryResponse> Handle(
        GetPostCommentByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _postCommentIncludeQueryBuilderFactory.Create().WithUser().Build();
        var serviceRequest = _applicationMapper.Map<GetPostCommentByIdQuery>(request).AddInclude(include);
        var postComment = await _postCommentService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetPostCommentByIdQueryResponse>(postComment);

        return response;
    }
}
