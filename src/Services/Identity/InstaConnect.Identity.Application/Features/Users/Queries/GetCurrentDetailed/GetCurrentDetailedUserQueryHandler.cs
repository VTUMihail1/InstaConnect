namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;

public class GetCurrentDetailedUserQueryHandler : IQueryHandler<GetCurrentDetailedUserQuery, UserDetailedQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetCurrentDetailedUserQueryHandler(
        IApplicationMapper applicationMapper,
        IUserReadRepository userReadRepository)
    {
        _applicationMapper = applicationMapper;
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

        var response = _applicationMapper.Map<UserDetailedQueryViewModel>(existingUser);

        return response;
    }
}
