﻿namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

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
