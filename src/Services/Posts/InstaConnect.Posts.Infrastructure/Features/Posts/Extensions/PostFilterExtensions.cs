using System.Linq.Expressions;

using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class PostFilterExtensions
{
    extension(PostsFilterQuery filter)
    {
        public FilterDefinition<Post> GetFilter()
        {
            var userName = filter.UserName.GetFilterForNameStartsWith<Post>(p => p.User!.Name.Value);
            var title = Builders<Post>.Filter.StartsWithCaseInsensitive(
                p => p.Title, filter.Title, filter.Title.IsNullOrEmptyOrWhiteSpace());

            return Builders<Post>.Filter.And(userName, title);
        }
    }

    extension(PostsForUserFilterQuery filter)
    {
        public FilterDefinition<Post> GetFilter()
        {
            var userId = filter.UserId.GetFilterForIdEquals<Post>(p => p.UserId.Id);
            var title = Builders<Post>.Filter.StartsWithCaseInsensitive(
                p => p.Title, filter.Title, filter.Title.IsNullOrEmptyOrWhiteSpace());

            return Builders<Post>.Filter.And(userId, title);
        }
    }

    extension(PostId filter)
    {
        public FilterDefinition<Post> GetFilter()
        {
            return filter.GetFilterForIdEquals<Post>(p => p.Id.Id);
        }

        public FilterDefinition<T> GetFilterForIdEquals<T>(Expression<Func<T, object>> idField)
        {
            return Builders<T>.Filter.EqualsCaseInsensitive(idField, filter.Id, filter.Id.IsEmpty());
        }
    }
}
