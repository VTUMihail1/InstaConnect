using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Helpers;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Users.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IUserEventClient CreateUserEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new UserEventClient(eventClient);
		}
	}
}
