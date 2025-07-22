using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQueryRequest, GetPostByIdQueryResponse>
{
    private readonly IPostService _postService;
    private readonly IApplicationMapper _applicationMapper;

    public GetPostByIdQueryHandler(
        IPostService postService,
        IApplicationMapper applicationMapper)
    {
        _postService = postService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetPostByIdQueryResponse> Handle(
        GetPostByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetPostByIdQuery>(request);
        var post = await _postService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetPostByIdQueryResponse>(post);

        return response;
    }
}
