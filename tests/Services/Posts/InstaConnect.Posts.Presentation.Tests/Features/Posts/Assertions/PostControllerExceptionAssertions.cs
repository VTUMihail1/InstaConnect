namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostControllerExceptionAssertions
{
	extension(PostController controller)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostApiRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowUserNotFoundExceptionAsync(
				request,
				r => r.UserId,
				cancellationToken);
		}
	}
}
