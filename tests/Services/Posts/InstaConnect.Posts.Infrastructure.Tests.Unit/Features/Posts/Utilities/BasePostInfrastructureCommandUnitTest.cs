using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostInfrastructureCommandUnitTest : BasePostTest
{
	protected IPostFluent Fluent { get; }

	protected IPostCollection Collection { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostInfrastructureCommandUnitTest()
	{
		Fluent = PostInfrastructureMockFactory.CreateFluent();
		Collection = PostInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
	}
}
