using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Repositories;

public class GetUserClaimByIdQueryRepositoryIntegrationTests : BaseUserClaimInfrastructureQueryIntegrationTest
{
	private readonly UserClaimIdBuilderFactory _idBuilderFactory;
	private readonly UserClaimIdBuilder _idBuilder;
	private readonly UserClaimId _id;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetUserClaimByIdQueryRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(UserClaim.Id);
		_id = _idBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(User);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(UserClaim, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, _currentUserQuery, UserClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, UserClaim);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(_id, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, currentUserQuery, UserClaim);
	}
}
