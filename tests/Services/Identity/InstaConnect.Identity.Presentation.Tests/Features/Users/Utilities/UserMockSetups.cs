using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupGetAllQueryRequest(
		GetAllUsersApiRequest request,
		ICollection<User> users,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetAllUsersQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(request));
		}

		public void SetupGetByIdQueryRequest(
			GetUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetUserByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetDetailsByIdQueryRequest(
			GetUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetUserDetailsByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetCurrentByIdQueryRequest(
			GetCurrentUserByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetCurrentUserByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetCurrentDetailsByIdQueryRequest(
			GetCurrentUserDetailsByIdApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsGetCurrentUserDetailsByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsAddUserCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupUpdateCurrentCommandRequest(
			UpdateCurrentUserApiRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(UserMatcher.IsUpdateCurrentUserCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}

	extension(IImageHandler imageHandler)
	{
		public void SetupUpload(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var image = new Image(request.Form.ProfileImage!.GetUrl());

			imageHandler
				.UploadAsync(request.Form.ProfileImage!, cancellationToken)
				.ReturnsTaskResponse(image);
		}

		public void SetupUpload(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var image = new Image(request.Form.ProfileImage!.GetUrl());

			imageHandler
				.UploadAsync(request.Form.ProfileImage!, cancellationToken)
				.ReturnsTaskResponse(image);
		}
	}
}
