using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetAllFilteredUsers;

public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, UserPaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetAllUsersQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IUserReadRepository userReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<UserPaginationQueryViewModel> Handle(
        GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<UserFilteredCollectionReadQuery>(request);
        var users = await _userReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        var response = _instaConnectMapper.Map<UserPaginationQueryViewModel>(users);

        return response;
    }
}
