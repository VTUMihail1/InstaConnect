using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeValidationExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
		IStringMessageTransformer messageTransformer,
		DeletePostLikeCommandRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			IStringMessageTransformer messageTransformer,
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostLikeByIdQueryRequest, string, GetPostLikeByIdQueryResponse>(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			IStringMessageTransformer messageTransformer,
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostLikeCommandRequest, string, AddPostLikeCommandResponse>(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			IStringMessageTransformer messageTransformer,
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, string, GetAllPostLikesQueryResponse>(
				p => p.Id,
				messageTransformer,
				request,
				cancellationToken);
		}


		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			IStringMessageTransformer messageTransformer,
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesForUserQueryRequest, string, GetAllPostLikesForUserQueryResponse>(
				p => p.UserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			IStringMessageTransformer messageTransformer,
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostLikeByIdQueryRequest, string, GetPostLikeByIdQueryResponse>(
				p => p.UserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			IStringMessageTransformer messageTransformer,
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<AddPostLikeCommandRequest, string, AddPostLikeCommandResponse>(
				p => p.UserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			IStringMessageTransformer messageTransformer,
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync(
				p => p.UserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			IStringMessageTransformer messageTransformer,
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetPostLikeByIdQueryRequest, string, GetPostLikeByIdQueryResponse>(
				p => p.CurrentUserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			IStringMessageTransformer messageTransformer,
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, string, GetAllPostLikesQueryResponse>(
				p => p.CurrentUserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			IStringMessageTransformer messageTransformer,
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesForUserQueryRequest, string, GetAllPostLikesForUserQueryResponse>(
				p => p.CurrentUserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserNameAsync(
			IStringMessageTransformer messageTransformer,
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, string, GetAllPostLikesQueryResponse>(
				p => p.UserName,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
			IIntMessageTransformer messageTransformer,
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, int, GetAllPostLikesQueryResponse>(
				p => p.Page,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
			IIntMessageTransformer messageTransformer,
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesForUserQueryRequest, int, GetAllPostLikesForUserQueryResponse>(
				p => p.Page,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			IIntMessageTransformer messageTransformer,
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, int, GetAllPostLikesQueryResponse>(
				p => p.PageSize,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			IIntMessageTransformer messageTransformer,
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesForUserQueryRequest, int, GetAllPostLikesForUserQueryResponse>(
				p => p.PageSize,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, CommonSortOrder, GetAllPostLikesQueryResponse>(
				p => p.SortOrder,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesForUserQueryRequest, CommonSortOrder, GetAllPostLikesForUserQueryResponse>(
				p => p.SortOrder,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
			IEnumMessageTransformer<PostLikesSortTerm> messageTransformer,
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesQueryRequest, PostLikesSortTerm, GetAllPostLikesQueryResponse>(
				p => p.SortTerm,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
			IEnumMessageTransformer<PostLikesForUserSortTerm> messageTransformer,
			GetAllPostLikesForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllPostLikesForUserQueryRequest, PostLikesForUserSortTerm, GetAllPostLikesForUserQueryResponse>(
				p => p.SortTerm,
				messageTransformer,
				request,
				cancellationToken);
		}
	}
}
