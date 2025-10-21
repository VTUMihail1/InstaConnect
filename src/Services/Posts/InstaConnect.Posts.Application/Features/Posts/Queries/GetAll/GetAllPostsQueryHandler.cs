using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQueryRequest, GetAllPostsQueryResponse>
{
    private readonly IPostService _postService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostIncludeQueryBuilderFactory _postIncludeQueryBuilderFactory;

    public GetAllPostsQueryHandler(
        IPostService postService,
        IApplicationMapper applicationMapper,
        IPostIncludeQueryBuilderFactory postIncludeQueryBuilderFactory)
    {
        _postService = postService;
        _applicationMapper = applicationMapper;
        _postIncludeQueryBuilderFactory = postIncludeQueryBuilderFactory;
    }

    public async Task<GetAllPostsQueryResponse> Handle(
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _postIncludeQueryBuilderFactory.Create().WithUser().Build();
        var serviceRequest = _applicationMapper.Map<GetAllPostsQuery>(request).AddInclude(include);
        var collection = await _postService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllPostsQueryResponse>(collection);

        return response;
    }
}
