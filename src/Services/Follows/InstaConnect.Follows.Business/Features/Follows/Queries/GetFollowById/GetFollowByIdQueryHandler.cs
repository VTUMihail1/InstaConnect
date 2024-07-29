using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Data.Features.Follows.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Follow;

namespace InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;

public class GetFollowByIdQueryHandler : IQueryHandler<GetFollowByIdQuery, FollowQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IFollowReadRepository _followReadRepository;

    public GetFollowByIdQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IFollowReadRepository followReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _followReadRepository = followReadRepository;
    }

    public async Task<FollowQueryViewModel> Handle(
        GetFollowByIdQuery request,
        CancellationToken cancellationToken)
    {
        var follow = await _followReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (follow == null)
        {
            throw new FollowNotFoundException();
        }

        var response = _instaConnectMapper.Map<FollowQueryViewModel>(follow);

        return response;
    }
}
