﻿using AutoMapper;
using InstaConnect.Follows.Read.Business.Models;
using InstaConnect.Follows.Read.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Follow;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetFollowById;

public class GetFollowByIdQueryHandler : IQueryHandler<GetFollowByIdQuery, FollowViewModel>
{
    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;

    public GetFollowByIdQueryHandler(
        IMapper mapper,
        IFollowRepository followRepository)
    {
        _mapper = mapper;
        _followRepository = followRepository;
    }

    public async Task<FollowViewModel> Handle(GetFollowByIdQuery request, CancellationToken cancellationToken)
    {
        var follow = await _followRepository.GetByIdAsync(request.Id, cancellationToken);

        if (follow == null)
        {
            throw new FollowNotFoundException();
        }

        var response = _mapper.Map<FollowViewModel>(follow);

        return response;
    }
}