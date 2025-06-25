namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetUserByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IUserReadRepository userReadRepository)
    {
        _applicationMapper = applicationMapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<UserQueryViewModel> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var response = _applicationMapper.Map<UserQueryViewModel>(existingUser);

        return response;
    }
}
