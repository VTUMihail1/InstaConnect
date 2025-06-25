using InstaConnect.Identity.Domain.Features.Users.Models.Filters;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, UserPaginationQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetAllUsersQueryHandler(
        IApplicationMapper applicationMapper,
        IUserReadRepository userReadRepository)
    {
        _applicationMapper = applicationMapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<UserPaginationQueryViewModel> Handle(
        GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _applicationMapper.Map<UserCollectionReadQuery>(request);
        var users = await _userReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);

        var response = _applicationMapper.Map<UserPaginationQueryViewModel>(users);

        return response;
    }
}
