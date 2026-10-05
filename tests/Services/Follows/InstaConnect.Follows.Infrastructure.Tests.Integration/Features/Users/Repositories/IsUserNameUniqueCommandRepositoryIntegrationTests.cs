using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class IsUserNameUniqueCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	private readonly NameBuilderFactory _nameBuilderFactory;
	private readonly NameBuilder _nameBuilder;
	private readonly Name _name;

	public IsUserNameUniqueCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_nameBuilderFactory = new();
		_nameBuilder = _nameBuilderFactory.Create(User.Name);
		_name = _nameBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task IsNameUniqueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.IsNameUniqueAsync(_name, CancellationToken);

		// Assert
		response.ShouldSatisfy(_name);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IsNameUniqueAsync_ShouldReturnResponse_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var name = _nameBuilder.WithName(transformer).Build();

		// Act
		var response = await Repository.IsNameUniqueAsync(name, CancellationToken);

		// Assert
		response.ShouldSatisfy(name);
	}
}
