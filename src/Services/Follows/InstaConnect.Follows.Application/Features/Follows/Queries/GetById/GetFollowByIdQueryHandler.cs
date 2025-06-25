namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public class GetFollowByIdQueryHandler : IQueryHandler<GetFollowByIdQuery, FollowQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IFollowReadRepository _followReadRepository;

    public GetFollowByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IFollowReadRepository followReadRepository)
    {
        _applicationMapper = applicationMapper;
        _followReadRepository = followReadRepository;
    }

    public async Task<FollowQueryViewModel> Handle(
        GetFollowByIdQuery request,
        CancellationToken cancellationToken)
    {
        var follow = await _followReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (follow == null)
        {
            throw new FollowNotFoundException();
        }

        var response = _applicationMapper.Map<FollowQueryViewModel>(follow);

        return response;
    }
}
