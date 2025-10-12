using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;
internal static class UserSqlProperties
{
    public const string Id = nameof(Post.Id);

    public const string Name = nameof(User.Name);

    public const string FirstName = nameof(User.FirstName);

    public const string LastName = nameof(User.LastName);

    public const string Email = nameof(User.Email);

    public const string ProfileImage = nameof(User.ProfileImage);

    public const string CreatedAt = nameof(User.CreatedAt);

    public const string UpdatedAt = nameof(User.UpdatedAt);
}
