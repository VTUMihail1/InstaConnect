﻿using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Users;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;

public class GetCurrentDetailedUserQueryHandler : IQueryHandler<GetCurrentDetailedUserQuery, UserDetailedQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetCurrentDetailedUserQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IUserReadRepository userReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<UserDetailedQueryViewModel> Handle(
        GetCurrentDetailedUserQuery request,
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
