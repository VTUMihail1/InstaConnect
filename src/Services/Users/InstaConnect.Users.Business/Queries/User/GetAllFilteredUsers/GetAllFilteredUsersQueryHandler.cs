using AutoMapper;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Models.Filters;

namespace InstaConnect.Users.Business.Queries.User.GetAllFilteredUsers;

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
