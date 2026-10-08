using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class GetUserByIdCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	private readonly UserIdBuilderFactory _idBuilderFactory;
	private readonly UserIdBuilder _idBuilder;
	private readonly UserId _id;

	private readonly UserInclude _include;

	public GetUserByIdCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(User.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithFollowers().WithFollowings().Build();
	}

	protected override async Task OnInitializeAsync()
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
