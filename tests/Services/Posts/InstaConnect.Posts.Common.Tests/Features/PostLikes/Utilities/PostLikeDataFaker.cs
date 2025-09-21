using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;

public static class PostLikeDataFaker
{
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

    public static PostLikeSortProperty GetSortProperty()
    {
        const PostLikeSortProperty SortProperty = PostLikeSortProperty.ByCreatedAt;

        return SortProperty;
    }
}
