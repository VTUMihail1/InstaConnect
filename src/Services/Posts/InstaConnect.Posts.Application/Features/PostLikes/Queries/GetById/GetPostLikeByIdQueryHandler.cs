using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQueryRequest, GetPostLikeByIdQueryResponse>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IApplicationMapper _applicationMapper;

    public GetPostLikeByIdQueryHandler(
        IPostLikeService postLikeService,
        IApplicationMapper applicationMapper)
    {
        _postLikeService = postLikeService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetPostLikeByIdQueryResponse> Handle(
        GetPostLikeByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetPostLikeByIdQuery>(request);
        var postLike = await _postLikeService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetPostLikeByIdQueryResponse>(postLike);

        return response;
    }
}
