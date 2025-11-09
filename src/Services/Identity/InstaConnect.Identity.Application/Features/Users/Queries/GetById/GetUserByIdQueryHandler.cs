namespace InstaConnect.Identity.Application.Features.Users.Queries.GetById;

internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public GetUserByIdQueryHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetUserByIdQueryResponse> Handle(
        GetUserByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetUserByIdQuery>(request);
        var user = await _userService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetUserByIdQueryResponse>(user);

        return response;
    }
}
