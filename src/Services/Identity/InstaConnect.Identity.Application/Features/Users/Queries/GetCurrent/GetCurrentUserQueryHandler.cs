namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrent;

public class GetCurrentUserQueryHandler : IQueryHandler<GetCurrentUserQuery, UserQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetCurrentUserQueryHandler(
        IApplicationMapper applicationMapper,
        IUserReadRepository userReadRepository)
    {
        _applicationMapper = applicationMapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<UserQueryViewModel> Handle(
        GetCurrentUserQuery request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userReadRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var response = _applicationMapper.Map<UserQueryViewModel>(existingUser);

        return response;
    }
}
