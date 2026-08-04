namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostControllerValidationExceptionAssertions
{
	extension(PostController controller)
	{
		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			AddPostApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.UserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForTitleAsync(
			AddPostApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Body.Title,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
			AddPostApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Body.Content,
				messageTransformer,
				cancellationToken);
		}
	}
}
