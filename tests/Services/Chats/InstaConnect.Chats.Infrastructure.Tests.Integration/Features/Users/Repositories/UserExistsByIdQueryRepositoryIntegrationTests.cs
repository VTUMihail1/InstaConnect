using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class UserExistsByIdQueryRepositoryIntegrationTests : BaseUserInfrastructureQueryIntegrationTest
{
	private readonly UserIdBuilderFactory _idBuilderFactory;
	private readonly UserIdBuilder _idBuilder;
	private readonly UserId _id;

	public UserExistsByIdQueryRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(User.Id);
		_id = _idBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, user);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, user);
	}
}
