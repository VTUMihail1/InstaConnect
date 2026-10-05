using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class GetUserClaimByIdQueryRepositoryUnitTests : BaseUserClaimInfrastructureQueryUnitTest
{
	private readonly UserClaimIdBuilderFactory _idBuilderFactory;
	private readonly UserClaimIdBuilder _idBuilder;
	private readonly UserClaimId _id;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly UserClaimQueryRepository _repository;

	public GetUserClaimByIdQueryRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(UserClaim.Id);
		_id = _idBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_repository = new(Collection);

		Collection.SetupAggregateFluent(_id, _currentUserQuery, Fluent);
		Fluent.SetupMatch(_id, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(_id, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(_id, _currentUserQuery, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, _currentUserQuery, UserClaim);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheResponseFluentFirstOrDefaultAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(_id, _currentUserQuery, CancellationToken);
	}
}
