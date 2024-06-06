using AutoMapper;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Models.Filters;

namespace InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;

public class GetAllFilteredUsersQueryHandler : IQueryHandler<GetAllFilteredUsersQuery, ICollection<UserViewDTO>>
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
    public async Task<ICollection<UserViewDTO>> Handle(GetAllFilteredUsersQuery request, CancellationToken cancellationToken)
    {
        var filteredCollection = _mapper.Map<UserFilteredCollectionQuery>(request);
        var users = await _userRepository.GetAllFilteredAsync(filteredCollection, cancellationToken);

        var userViewDTOs = _mapper.Map<ICollection<UserViewDTO>>(users);

        return userViewDTOs;
    }
}
