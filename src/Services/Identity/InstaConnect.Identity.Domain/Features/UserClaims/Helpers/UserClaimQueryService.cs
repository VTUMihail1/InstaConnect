namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

internal class UserClaimQueryService : IUserClaimQueryService
{
	private readonly IUserQueryRepository _repository;
	private readonly IUserClaimQueryRepository _claimRepository;
	private readonly IUserClaimCollectionResponseFactory _claimCollectionResponseFactory;

	public UserClaimQueryService(
		IUserQueryRepository repository,
		IUserClaimQueryRepository claimRepository,
		IUserClaimCollectionResponseFactory claimCollectionResponseFactory)
	{
		_repository = repository;
		_claimRepository = claimRepository;
		_claimCollectionResponseFactory = claimCollectionResponseFactory;
	}

	public async Task<UserClaimCollectionResponse> GetAllAsync(GetAllUserClaimsQuery query, CancellationToken cancellationToken)
	{
		var user = await _repository.GetByIdAsync(query.Filter.Id, query.Current, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(query.Filter.Id);
		}

		var userClaims = await _claimRepository.GetAllAsync(
			query.Filter,
			query.Current,
			query.Sorting,
			query.Pagination,
			cancellationToken);

		var totalCount = await _claimRepository.GetTotalCountAsync(query.Filter, cancellationToken);

		return _claimCollectionResponseFactory.Create(user, userClaims, totalCount, query.Pagination);
	}
}
