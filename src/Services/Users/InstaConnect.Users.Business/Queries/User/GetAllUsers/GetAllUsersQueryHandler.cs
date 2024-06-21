using AutoMapper;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction;

namespace InstaConnect.Users.Business.Queries.User.GetAllUsers;

public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, ICollection<UserViewModel>>
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

    public async Task<ICollection<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionQuery>(request);
        var users = await _userRepository.GetAllAsync(collectionQuery, cancellationToken);

        var response = _mapper.Map<ICollection<UserViewModel>>(users);

        return response;
    }
}
