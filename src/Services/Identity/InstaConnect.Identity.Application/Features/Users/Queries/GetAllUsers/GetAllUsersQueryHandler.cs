using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.Filters;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAllUsers;

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
        var filteredCollectionQuery = _instaConnectMapper.Map<UserCollectionReadQuery>(request);
        var users = await _userReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        var response = _instaConnectMapper.Map<UserPaginationQueryViewModel>(users);

        return response;
    }
}
