﻿using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;

public class GetCurrentUserDetailedQueryHandler : IQueryHandler<GetCurrentUserDetailedQuery, UserDetailedQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetCurrentUserDetailedQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IUserReadRepository userReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<UserDetailedQueryViewModel> Handle(
        GetCurrentUserDetailedQuery request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userReadRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var response = _instaConnectMapper.Map<UserDetailedQueryViewModel>(existingUser);

        return response;
    }
}
