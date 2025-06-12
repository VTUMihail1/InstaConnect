using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public static class PostDataFaker
{
    public static string GetId()
    {
        return DataFaker.GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength);
    }

    public static string GetInvalidId()
    {
        return DataFaker.GetAverageString(PostConfigurations.IdMaxLength, PostConfigurations.IdMinLength);
    }

    public static string GetTitle()
    {
        return DataFaker.GetAverageString(PostConfigurations.TitleMaxLength, PostConfigurations.TitleMinLength);
    }

    public static string GetContent()
    {
        return DataFaker.GetAverageString(PostConfigurations.ContentMaxLength, PostConfigurations.ContentMinLength);
    }

    public static DateTimeOffset GetCreatedAt()
    {
        return DataFaker.GetMaxDate();
    }

    public static DateTimeOffset GetUpdatedAt()
    {
        return DataFaker.GetMaxDate();
    }

    public static int GetPage()
    {
        const int Page = 1;

        return Page;
    }

    public static int GetPageSize()
    {
        const int PageSize = 20;

        return PageSize;
    }

    public static SortOrder GetSortOrder()
    {
        const SortOrder sortOrder = SortOrder.ASC;

        return sortOrder;
    }

    public static SortOrder GetEmptySortOrder()
    {
        const SortOrder sortOrder = SortOrder.None;

        return sortOrder;
    }

    public static PostSortProperty GetSortProperty()
    {
        const PostSortProperty sortPropertyName = PostSortProperty.ByCreatedAt;

        return sortPropertyName;
    }

    public static PostSortProperty GetEmptySortProperty()
    {
        const PostSortProperty sortPropertyName = PostSortProperty.None;

        return sortPropertyName;
    }
}
