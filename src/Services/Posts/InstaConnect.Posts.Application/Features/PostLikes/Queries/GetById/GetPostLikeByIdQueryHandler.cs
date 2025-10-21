using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQueryRequest, GetPostLikeByIdQueryResponse>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostLikeIncludeQueryBuilderFactory _postLikeIncludeQueryBuilderFactory;

    public GetPostLikeByIdQueryHandler(
        IPostLikeService postLikeService,
        IApplicationMapper applicationMapper,
        IPostLikeIncludeQueryBuilderFactory postLikeIncludeQueryBuilderFactory)
    {
        _postLikeService = postLikeService;
        _applicationMapper = applicationMapper;
        _postLikeIncludeQueryBuilderFactory = postLikeIncludeQueryBuilderFactory;
    }

    public async Task<GetPostLikeByIdQueryResponse> Handle(
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _postLikeIncludeQueryBuilderFactory.Create().WithUser().Build();
        var serviceRequest = _applicationMapper.Map<GetPostLikeByIdQuery>(request).AddInclude(include);
        var postLike = await _postLikeService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetPostLikeByIdQueryResponse>(postLike);

        return response;
    }
}
