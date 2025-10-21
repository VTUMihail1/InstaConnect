using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;

internal class GetPostCommentLikeByIdQueryHandler : IQueryHandler<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentLikeService _postCommentLikeService;
    private readonly IPostCommentLikeIncludeQueryBuilderFactory _postCommentLikeIncludeQueryBuilderFactory;

    public GetPostCommentLikeByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IPostCommentLikeService postCommentLikeService,
        IPostCommentLikeIncludeQueryBuilderFactory postCommentLikeIncludeQueryBuilderFactory)
    {
        _applicationMapper = applicationMapper;
        _postCommentLikeService = postCommentLikeService;
        _postCommentLikeIncludeQueryBuilderFactory = postCommentLikeIncludeQueryBuilderFactory;
    }

    public async Task<GetPostCommentLikeByIdQueryResponse> Handle(
        GetPostCommentLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _postCommentLikeIncludeQueryBuilderFactory.Create().WithUser().Build();
        var serviceRequest = _applicationMapper.Map<GetPostCommentLikeByIdQuery>(request).AddInclude(include);
        var postCommentLike = await _postCommentLikeService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetPostCommentLikeByIdQueryResponse>(postCommentLike);

        return response;
    }
}
