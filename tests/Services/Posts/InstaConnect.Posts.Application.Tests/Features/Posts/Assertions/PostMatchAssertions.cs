using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    extension(AddPostCommandResponse response)
    {
        public void ShouldSatisfy(Post post, AddPostCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, request));
        }
    }

    extension(UpdatePostCommandResponse response)
    {
        public void ShouldSatisfy(Post post, UpdatePostCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, request));
        }
    }

    extension(GetPostByIdQueryResponse response)
    {
        public void ShouldSatisfy(Post post, GetPostByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, request));
        }
    }

    extension(GetAllPostsQueryResponse response)
    {
        public void ShouldSatisfy(
        ICollection<Post> posts,
        GetAllPostsQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(posts, request));
        }

        public void ShouldSatisfy(
            ICollection<Post> posts,
            GetAllPostsQueryRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(posts, request, termTransformer));
        }
    }

    extension(GetAllPostsForUserQueryResponse response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, posts, request));
        }

        public void ShouldSatisfy(
            User user,
            ICollection<Post> posts,
            GetAllPostsForUserQueryRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, posts, request, termTransformer));
        }
    }

    extension(Post post)
    {
        public void ShouldSatisfy(AddPostCommandRequest request)
        {
            post.ShouldSatisfy(p => p.Matches(request));
        }

        public void ShouldSatisfy(UpdatePostCommandRequest request)
        {
            post.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
