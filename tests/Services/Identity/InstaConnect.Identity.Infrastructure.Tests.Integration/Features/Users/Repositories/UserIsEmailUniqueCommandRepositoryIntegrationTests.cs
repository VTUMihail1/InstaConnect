using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class UserIsEmailUniqueCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	private readonly EmailBuilderFactory _emailBuilderFactory;
	private readonly EmailBuilder _emailBuilder;
	private readonly Email _email;

	public UserIsEmailUniqueCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_emailBuilderFactory = new();
		_emailBuilder = _emailBuilderFactory.Create(User.Email);
		_email = _emailBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task IsEmailUniqueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.IsEmailUniqueAsync(_email, CancellationToken);

		// Assert
		response.ShouldSatisfy(_email);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task IsEmailUniqueAsync_ShouldReturnResponse_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var email = _emailBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Repository.IsEmailUniqueAsync(email, CancellationToken);

		// Assert
		response.ShouldSatisfy(email);
	}
}
