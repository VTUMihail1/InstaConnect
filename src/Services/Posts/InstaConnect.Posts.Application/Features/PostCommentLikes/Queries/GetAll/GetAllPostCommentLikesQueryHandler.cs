using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;

internal class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQueryResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentLikeService _postCommentLikeService;

    public GetAllPostCommentLikesQueryHandler(
        IApplicationMapper applicationMapper,
        IPostCommentLikeService postCommentLikeService)
    {
        _applicationMapper = applicationMapper;
        _postCommentLikeService = postCommentLikeService;
    }

    public async Task<GetAllPostCommentLikesQueryResponse> Handle(
        GetAllPostCommentLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllPostCommentLikesQuery>(request);
        var collection = await _postCommentLikeService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllPostCommentLikesQueryResponse>(collection);

        return response;
    }
}
