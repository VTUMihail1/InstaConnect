using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserMockSetups
{
	extension(IUserQueryService service)
	{
		public void SetupGetAllQuery(
		GetAllUsersQueryRequest request,
		ICollection<User> users,
		CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(UserMatcher.IsGetAllUsersQuery(request), cancellationToken)
				.ReturnsTaskResponse(users.ToResponse(request));
		}

		public void SetupGetByIdQuery(
			GetUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdQuery(
			GetCurrentUserByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdQuery(
			GetUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupGetByIdQuery(
			GetCurrentUserDetailsByIdQueryRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}

	extension(IUserCommandService service)
	{
		public void SetupAddCommand(
		AddUserCommandRequest request,
		User user,
		CancellationToken cancellationToken)
		{
			service
				.AddAsync(UserMatcher.IsAddUserCommand(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}

		public void SetupUpdateCommand(
			UpdateCurrentUserCommandRequest request,
			User user,
			CancellationToken cancellationToken)
		{
			service
				.UpdateAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken)
				.ReturnsTaskResponse(user.ToResponse(request));
		}
	}

	extension(IImageHandler imageHandler)
	{
		public void SetupUpload(
			AddUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var image = new Image(request.ProfileImage!.GetUrl());

			imageHandler
				.UploadAsync(request.ProfileImage!, cancellationToken)
				.ReturnsTaskResponse(image);
		}

		public void SetupUpload(
			UpdateCurrentUserCommandRequest request,
			CancellationToken cancellationToken)
		{
			var image = new Image(request.ProfileImage!.GetUrl());

			imageHandler
				.UploadAsync(request.ProfileImage!, cancellationToken)
				.ReturnsTaskResponse(image);
		}
	}
}
