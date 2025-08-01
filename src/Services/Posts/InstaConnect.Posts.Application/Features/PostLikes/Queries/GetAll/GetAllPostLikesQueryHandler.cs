using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQueryRequest, GetAllPostLikesQueryResponse>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IApplicationMapper _applicationMapper;

    public GetAllPostLikesQueryHandler(
        IPostLikeService postLikeService,
        IApplicationMapper applicationMapper)
    {
        _postLikeService = postLikeService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetAllPostLikesQueryResponse> Handle(
        GetAllPostLikesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllPostLikesQuery>(request);
        var collection = await _postLikeService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllPostLikesQueryResponse>(collection);

        return response;
    }
}
