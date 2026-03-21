using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Domain.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimValidationExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
            IStringMessageTransformer messageTransformer,
            DeleteUserClaimCommandRequest request,
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
            AddUserClaimCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserClaimCommandRequest, string, AddUserClaimCommandResponse>(
                p => p.Id,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUserClaimsQueryRequest, string, GetAllUserClaimsQueryResponse>(
                p => p.Id,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForClaimAsync(
            IEnumMessageTransformer<ApplicationClaims> messageTransformer,
            DeleteUserClaimCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync(
                p => p.Claim,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForClaimAsync(
            IEnumMessageTransformer<ApplicationClaims> messageTransformer,
            AddUserClaimCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserClaimCommandRequest, ApplicationClaims, AddUserClaimCommandResponse>(
                p => p.Claim,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUserClaimsQueryRequest, string, GetAllUserClaimsQueryResponse>(
                p => p.CurrentId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
            IIntMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUserClaimsQueryRequest, int, GetAllUserClaimsQueryResponse>(
                p => p.Page,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            IIntMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUserClaimsQueryRequest, int, GetAllUserClaimsQueryResponse>(
                p => p.PageSize,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllUserClaimsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUserClaimsQueryRequest, CommonSortOrder, GetAllUserClaimsQueryResponse>(
                p => p.SortOrder,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
            IEnumMessageTransformer<UserClaimsSortTerm> messageTransformer,
            GetAllUserClaimsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllUserClaimsQueryRequest, UserClaimsSortTerm, GetAllUserClaimsQueryResponse>(
                p => p.SortTerm,
                messageTransformer,
                request,
                cancellationToken);
        }
    }
}
