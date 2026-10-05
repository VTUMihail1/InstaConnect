using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Builders;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class GetUserByIdCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	private readonly UserIdBuilderFactory _idBuilderFactory;
	private readonly UserIdBuilder _idBuilder;
	private readonly UserId _id;

	private readonly UserInclude _include;

	public GetUserByIdCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(User.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUserClaims().WithRefreshTokens().WithForgotPasswordTokens().WithEmailConfirmationTokens().Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

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
		response.ShouldSatisfy(_id, User);
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
		response.ShouldSatisfy(id, User);
	}
}
