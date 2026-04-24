using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenValidationExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowInvalidValidationExceptionForNameAsync(
            IStringMessageTransformer messageTransformer,
            IssueRefreshTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<IssueRefreshTokenCommandRequest, string, IssueRefreshTokenCommandResponse>(
                p => p.Name,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPasswordAsync(
            IStringMessageTransformer messageTransformer,
            IssueRefreshTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<IssueRefreshTokenCommandRequest, string, IssueRefreshTokenCommandResponse>(
                p => p.Password,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
            IStringMessageTransformer messageTransformer,
            DeleteCurrentRefreshTokenCommandRequest request,
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
            RotateRefreshTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<RotateRefreshTokenCommandRequest, string, RotateRefreshTokenCommandResponse>(
                p => p.Id,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForValueAsync(
            IStringMessageTransformer messageTransformer,
            DeleteCurrentRefreshTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync(
                p => p.Value,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForValueAsync(
            IStringMessageTransformer messageTransformer,
            RotateRefreshTokenCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<RotateRefreshTokenCommandRequest, string, RotateRefreshTokenCommandResponse>(
                p => p.Value,
                messageTransformer,
                request,
                cancellationToken);
        }
    }
}
