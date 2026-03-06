using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class PostLikeAggregateFluentExtensions
{
    extension(IAggregateFluent<PostLike> aggregate)
    {
        public IAggregateFluent<PostLike> Match(PostLikesFilterQuery filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<PostLike> Match(PostLikesForUserFilterQuery filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<PostLike> Match(PostLikeId filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<PostLikeResponse> ProjectToFullResponse(CurrentUserQuery currentUser)
        {
            var currentUserId = currentUser.Id.Id?.ToLower();
            var projection = Builders<PostLike>.Projection.Expression(
                p => new PostLikeResponse(
                    p.Id,
                    new UserResponse(
                        p.User!.Id,
                        p.User.FirstName,
                        p.User.LastName,
                        p.User.Email,
                        p.User.Name,
                        p.User.ProfileImage,
                        p.User.CreatedAtUtc,
                        p.User.UpdatedAtUtc),
                    new PostResponse(
                        p.Post!.Id,
                        p.Post.UserId,
                        p.Post.Title,
                        p.Post.Content,
                            new UserResponse(
                                p.Post.User!.Id,
                                p.Post.User.FirstName,
                                p.Post.User.LastName,
                                p.Post.User.Email,
                                p.Post.User.Name,
                                p.Post.User.ProfileImage,
                                p.Post.User.CreatedAtUtc,
                                p.Post.User.UpdatedAtUtc),
                        p.Post.PostLikes.Any(
                            pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                        p.Post.CreatedAtUtc,
                        p.Post.UpdatedAtUtc),
                    p.CreatedAtUtc));

            return aggregate.Project(projection);
        }

        public IAggregateFluent<PostLikeResponse> ProjectToResponseWithoutUser(CurrentUserQuery currentUser)
        {
            var currentUserId = currentUser.Id.Id?.ToLower();
            var projection = Builders<PostLike>.Projection.Expression(
                p => new PostLikeResponse(
                    p.Id,
                    null,
                    new PostResponse(
                        p.Post!.Id,
                        p.Post.UserId,
                        p.Post.Title,
                        p.Post.Content,
                            new UserResponse(
                                p.Post.User!.Id,
                                p.Post.User.FirstName,
                                p.Post.User.LastName,
                                p.Post.User.Email,
                                p.Post.User.Name,
                                p.Post.User.ProfileImage,
                                p.Post.User.CreatedAtUtc,
                                p.Post.User.UpdatedAtUtc),
                        p.Post.PostLikes.Any(
                            pl => pl.Id.UserId.Id.ToLower() == currentUserId),
                        p.Post.CreatedAtUtc,
                        p.Post.UpdatedAtUtc),
                    p.CreatedAtUtc));

            return aggregate.Project(projection);
        }

        public IAggregateFluent<PostLikeResponse> ProjectToResponseWithoutPost(CurrentUserQuery currentUser)
        {
            var projection = Builders<PostLike>.Projection.Expression(
                p => new PostLikeResponse(
                    p.Id,
                    new UserResponse(
                        p.User!.Id,
                        p.User.FirstName,
                        p.User.LastName,
                        p.User.Email,
                        p.User.Name,
                        p.User.ProfileImage,
                        p.User.CreatedAtUtc,
                        p.User.UpdatedAtUtc),
                    null,
                    p.CreatedAtUtc));

            return aggregate.Project(projection);
        }
    }
}
