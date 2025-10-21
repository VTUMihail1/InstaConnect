using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;

internal class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentLikeService _postCommentLikeService;
    private readonly IPostCommentLikeIncludeQueryBuilderFactory _postCommentLikeIncludeQueryBuilderFactory;

    public GetAllPostCommentLikesQueryHandler(
        IApplicationMapper applicationMapper,
        IPostCommentLikeService postCommentLikeService,
        IPostCommentLikeIncludeQueryBuilderFactory postCommentLikeIncludeQueryBuilderFactory)
    {
        _applicationMapper = applicationMapper;
        _postCommentLikeService = postCommentLikeService;
        _postCommentLikeIncludeQueryBuilderFactory = postCommentLikeIncludeQueryBuilderFactory;
    }

    public async Task<GetAllPostCommentLikesQueryResponse> Handle(
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var include = _postCommentLikeIncludeQueryBuilderFactory.Create().WithUser().Build();
        var serviceRequest = _applicationMapper.Map<GetAllPostCommentLikesQuery>(request).AddInclude(include);
        var collection = await _postCommentLikeService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllPostCommentLikesQueryResponse>(collection);

        return response;
    }
}
