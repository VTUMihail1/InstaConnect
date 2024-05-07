﻿using AutoMapper;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Queries.User.GetAllUsers;

public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, ICollection<UserViewDTO>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(
        IMapper mapper,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ICollection<UserViewDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionQuery>(request);
        var users = await _userRepository.GetAllAsync(collectionQuery, cancellationToken);

        var userViewDTOs = _mapper.Map<ICollection<UserViewDTO>>(users);

        return userViewDTOs;
    }
}
