using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQueryRequest, GetAllPostsQueryResponse>
{
    private readonly IPostService _postService;
    private readonly IApplicationMapper _applicationMapper;

    public GetAllPostsQueryHandler(
        IPostService postService,
        IApplicationMapper applicationMapper)
    {
        _postService = postService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetAllPostsQueryResponse> Handle(
        GetAllPostsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllPostsQuery>(request);
        var collection = await _postService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllPostsQueryResponse>(collection);

        return response;
    }
}
