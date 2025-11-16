using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Utilities;

public static class PostLikeExceptionErrorMessages
{
    public static string GetNotFoundMessage(PostLikeId id)
    {
        const string Format = "PostLike(id: {0}, userId: {1}) with that id does not exist";

        return Format.FormatCurrentCulture(id.Id.Id, id.UserId.Id);
    }

    public static string GetAlreadyExistsMessage(PostLikeId id)
    {
        const string Format = "PostLike(id: {0}, userId: {1}) already exists";

        return Format.FormatCurrentCulture(id.Id.Id, id.UserId.Id);
    }

    public static string GetSortPropertyNotSupportedMessage(PostLikeSortProperty sortProperty)
    {
        const string Format = "PostLikeSortProperty(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortProperty);
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<PostLikeIncludeProperty> includeProperties)
    {
        const string Format = "PostLikeIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
