using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserValidationExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        IStringMessageTransformer messageTransformer,
        UpdateCurrentUserCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateCurrentUserCommandRequest, string, UpdateCurrentUserCommandResponse>(
                p => p.Id,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
            IStringMessageTransformer messageTransformer,
            DeleteUserCommandRequest request,
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
            DeleteCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync(
                p => p.CurrentId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateCurrentUserCommandRequest, string, UpdateCurrentUserCommandResponse>(
                p => p.Name,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
                p => p.Name,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateCurrentUserCommandRequest, string, UpdateCurrentUserCommandResponse>(
                p => p.FirstName,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
                p => p.FirstName,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateCurrentUserCommandRequest, string, UpdateCurrentUserCommandResponse>(
                p => p.LastName,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
                p => p.LastName,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
            IStringMessageTransformer messageTransformer,
            UpdateCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateCurrentUserCommandRequest, string, UpdateCurrentUserCommandResponse>(
                p => p.Email,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
                p => p.Email,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPasswordAsync(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
                p => p.Password,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForConfirmPasswordAsync(
            IStringMessageTransformer messageTransformer,
            AddUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
                p => p.ConfirmPassword,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
            IStringMessageTransformer messageTransformer,
            GetUserByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetUserByIdQueryRequest, string, GetUserByIdQueryResponse>(
                p => p.Id,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
            IStringMessageTransformer messageTransformer,
            GetUserDetailsByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetUserDetailsByIdQueryRequest, string, GetUserDetailsByIdQueryResponse>(
                p => p.Id,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
            IStringMessageTransformer messageTransformer,
            GetUserByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetUserByIdQueryRequest, string, GetUserByIdQueryResponse>(
                p => p.CurrentId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
            IStringMessageTransformer messageTransformer,
            GetCurrentUserByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetCurrentUserByIdQueryRequest, string, GetCurrentUserByIdQueryResponse>(
                p => p.CurrentId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
            IStringMessageTransformer messageTransformer,
            GetUserDetailsByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetUserDetailsByIdQueryRequest, string, GetUserDetailsByIdQueryResponse>(
                p => p.CurrentId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
            IStringMessageTransformer messageTransformer,
            GetCurrentUserDetailsByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetCurrentUserDetailsByIdQueryRequest, string, GetCurrentUserDetailsByIdQueryResponse>(
                p => p.CurrentId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUsersQueryRequest, string, GetAllUsersQueryResponse>(
                p => p.CurrentId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUsersQueryRequest, string, GetAllUsersQueryResponse>(
                p => p.Name,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUsersQueryRequest, string, GetAllUsersQueryResponse>(
                p => p.FirstName,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
            IStringMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUsersQueryRequest, string, GetAllUsersQueryResponse>(
                p => p.LastName,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
            IIntMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUsersQueryRequest, int, GetAllUsersQueryResponse>(
                p => p.Page,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            IIntMessageTransformer messageTransformer,
            GetAllUsersQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUsersQueryRequest, int, GetAllUsersQueryResponse>(
                p => p.PageSize,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllUsersQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUsersQueryRequest, CommonSortOrder, GetAllUsersQueryResponse>(
                p => p.SortOrder,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
            IEnumMessageTransformer<UsersSortTerm> messageTransformer,
            GetAllUsersQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUsersQueryRequest, UsersSortTerm, GetAllUsersQueryResponse>(
                p => p.SortTerm,
                messageTransformer,
                request,
                cancellationToken);
        }
    }
}
