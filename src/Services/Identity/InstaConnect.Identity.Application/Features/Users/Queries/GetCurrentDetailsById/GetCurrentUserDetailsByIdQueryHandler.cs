namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

internal class GetCurrentUserDetailsByIdQueryHandler : IQueryHandler<GetCurrentUserDetailsByIdQueryRequest, GetCurrentUserDetailsByIdQueryResponse>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public GetCurrentUserDetailsByIdQueryHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetCurrentUserDetailsByIdQueryResponse> Handle(
        GetCurrentUserDetailsByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetUserByIdQuery>(request);
        var user = await _userService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetCurrentUserDetailsByIdQueryResponse>(user);

        return response;
    }
}
