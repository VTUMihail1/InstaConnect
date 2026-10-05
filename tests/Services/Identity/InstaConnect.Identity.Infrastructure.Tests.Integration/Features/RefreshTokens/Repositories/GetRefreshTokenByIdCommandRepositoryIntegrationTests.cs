using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class GetRefreshTokenByIdCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	private readonly RefreshTokenIdBuilderFactory _idBuilderFactory;
	private readonly RefreshTokenIdBuilder _idBuilder;
	private readonly RefreshTokenId _id;

	private readonly RefreshTokenInclude _include;

	public GetRefreshTokenByIdCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(RefreshToken.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, RefreshToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, RefreshToken);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithValue(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, RefreshToken);
	}
}
