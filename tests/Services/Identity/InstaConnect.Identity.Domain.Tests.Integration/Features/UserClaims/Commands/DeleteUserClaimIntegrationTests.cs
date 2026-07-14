using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.UserClaims.Commands;

public class DeleteUserClaimIntegrationTests : BaseUserClaimDomainCommandIntegrationTest
{
	private readonly DeleteUserClaimCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteUserClaimCommandBuilder _commandBuilder;
	private readonly DeleteUserClaimCommand _command;

	public DeleteUserClaimIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(UserClaim);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserClaimNotFoundException_WhenUserClaimNotFound()
	{
		// Arrange
		await ServiceScope.DeleteUserClaimAsync(UserClaim, CancellationToken);

		// Assert
		await Service.ShouldThrowUserClaimNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserClaim_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var userClaim = await ServiceScope.GetUserClaimByIdAsync(UserClaim.Id, CancellationToken);

		// Assert
		userClaim.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserClaim_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var userClaim = await ServiceScope.GetUserClaimByIdAsync(UserClaim.Id, CancellationToken);

		// Assert
		userClaim.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishUserClaimDeletedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserClaimDeletedAsync(_command, UserClaim, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishUserClaimDeletedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedUserClaimDeletedAsync(command, UserClaim, CancellationToken);
	}
}
