﻿using AutoMapper;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;

public class GetAllFilteredUsersQueryHandler : IQueryHandler<GetAllFilteredUsersQuery, ICollection<UserViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetAllFilteredUsersQueryHandler(
        IMapper mapper,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<ICollection<UserViewModel>> Handle(GetAllFilteredUsersQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<UserFilteredCollectionQuery>(request);
        var users = await _userRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);

        var response = _mapper.Map<ICollection<UserViewModel>>(users);

        return response;
    }
}