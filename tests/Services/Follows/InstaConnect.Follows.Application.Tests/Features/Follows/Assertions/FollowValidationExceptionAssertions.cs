using InstaConnect.Common.Application.Abstractions;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowValidationExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowInvalidValidationExceptionForFollowerIdAsync(
        IStringMessageTransformer messageTransformer,
        DeleteFollowCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync(
                p => p.FollowerId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFollowerIdAsync(
            IStringMessageTransformer messageTransformer,
            GetFollowByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetFollowByIdQueryRequest, string, GetFollowByIdQueryResponse>(
                p => p.FollowerId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFollowerIdAsync(
            IStringMessageTransformer messageTransformer,
            AddFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddFollowCommandRequest, string, AddFollowCommandResponse>(
                p => p.FollowerId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFollowerIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsQueryRequest, string, GetAllFollowsQueryResponse>(
                p => p.FollowerId,
                messageTransformer,
                request,
                cancellationToken);
        }


        public async Task ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsForFollowingQueryRequest, string, GetAllFollowsForFollowingQueryResponse>(
                p => p.FollowingId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
            IStringMessageTransformer messageTransformer,
            GetFollowByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetFollowByIdQueryRequest, string, GetFollowByIdQueryResponse>(
                p => p.FollowingId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
            IStringMessageTransformer messageTransformer,
            AddFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<AddFollowCommandRequest, string, AddFollowCommandResponse>(
                p => p.FollowingId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
            IStringMessageTransformer messageTransformer,
            DeleteFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync(
                p => p.FollowingId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
            IStringMessageTransformer messageTransformer,
            GetFollowByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetFollowByIdQueryRequest, string, GetFollowByIdQueryResponse>(
                p => p.CurrentUserId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsQueryRequest, string, GetAllFollowsQueryResponse>(
                p => p.CurrentUserId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsForFollowingQueryRequest, string, GetAllFollowsForFollowingQueryResponse>(
                p => p.CurrentUserId,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFollowingNameAsync(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsQueryRequest, string, GetAllFollowsQueryResponse>(
                p => p.FollowingName,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForFollowerNameAsync(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsForFollowingQueryRequest, string, GetAllFollowsForFollowingQueryResponse>(
                p => p.FollowerName,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsQueryRequest, int, GetAllFollowsQueryResponse>(
                p => p.Page,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsForFollowingQueryRequest, int, GetAllFollowsForFollowingQueryResponse>(
                p => p.Page,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsQueryRequest, int, GetAllFollowsQueryResponse>(
                p => p.PageSize,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsForFollowingQueryRequest, int, GetAllFollowsForFollowingQueryResponse>(
                p => p.PageSize,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllFollowsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsQueryRequest, CommonSortOrder, GetAllFollowsQueryResponse>(
                p => p.SortOrder,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllFollowsForFollowingQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsForFollowingQueryRequest, CommonSortOrder, GetAllFollowsForFollowingQueryResponse>(
                p => p.SortOrder,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
            IEnumMessageTransformer<FollowsSortTerm> messageTransformer,
            GetAllFollowsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsQueryRequest, FollowsSortTerm, GetAllFollowsQueryResponse>(
                p => p.SortTerm,
                messageTransformer,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
            IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer,
            GetAllFollowsForFollowingQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllFollowsForFollowingQueryRequest, FollowsForFollowingSortTerm, GetAllFollowsForFollowingQueryResponse>(
                p => p.SortTerm,
                messageTransformer,
                request,
                cancellationToken);
        }
    }
}
