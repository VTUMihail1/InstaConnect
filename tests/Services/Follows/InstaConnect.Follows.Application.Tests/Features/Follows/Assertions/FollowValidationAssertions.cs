using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowValidationAssertions
{
    extension(TestValidationResult<DeleteFollowCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForFollowerId(
        IStringMessageTransformer messageTransformer,
        DeleteFollowCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowerId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForFollowingId(
            IStringMessageTransformer messageTransformer,
            DeleteFollowCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowingId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetFollowByIdQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForFollowerId(
        IStringMessageTransformer messageTransformer,
        GetFollowByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowerId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForFollowingId(
            IStringMessageTransformer messageTransformer,
            GetFollowByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowingId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetFollowByIdQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<AddFollowCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForFollowerId(
        IStringMessageTransformer messageTransformer,
        AddFollowCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowerId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForFollowingId(
            IStringMessageTransformer messageTransformer,
            AddFollowCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowingId, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllFollowsQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForFollowerId(
        IStringMessageTransformer messageTransformer,
        GetAllFollowsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowerId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForFollowingName(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowingName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllFollowsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(
            IEnumMessageTransformer<FollowsSortTerm> messageTransformer,
            GetAllFollowsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllFollowsForFollowingQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForFollowingId(
        IStringMessageTransformer messageTransformer,
        GetAllFollowsForFollowingQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowingId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForFollowerName(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.FollowerName, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentUserId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsForFollowingQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllFollowsForFollowingQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(
            IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer,
            GetAllFollowsForFollowingQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }
}
