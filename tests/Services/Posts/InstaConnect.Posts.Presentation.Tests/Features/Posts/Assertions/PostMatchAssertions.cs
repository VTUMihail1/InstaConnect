using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    extension(AddPostApiResponse response)
    {
        public void ShouldSatisfy(
        Post post,
        AddPostApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, request));
        }
    }

    extension(UpdatePostApiResponse response)
    {
        public void ShouldSatisfy(
        Post post,
        UpdatePostApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, request));
        }
    }

    extension(GetPostByIdApiResponse response)
    {
        public void ShouldSatisfy(
        Post post,
        GetPostByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, request));
        }
    }

    extension(GetAllPostsApiResponse response)
    {
        public void ShouldSatisfy(
        ICollection<Post> posts,
        GetAllPostsApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(posts, request));
        }

        public void ShouldSatisfy(
            ICollection<Post> posts,
            GetAllPostsApiRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(posts, request, termTransformer));
        }
    }

    extension(GetAllPostsForUserApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, posts, request));
        }

        public void ShouldSatisfy(
            User user,
            ICollection<Post> posts,
            GetAllPostsForUserApiRequest request,
            ISortEnumTermTransformer<Post> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, posts, request, termTransformer));
        }
    }

    extension(ActionResult<AddPostApiResponse> response)
    {
        public void ShouldSatisfy(
        Post post,
        AddPostApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(post, request));
        }
    }

    extension(ActionResult<UpdatePostApiResponse> response)
    {
        public void ShouldSatisfy(
        Post post,
        UpdatePostApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(post, request));
        }
    }

    extension(ActionResult<GetPostByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        Post post,
        GetPostByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(post, request));
        }
    }

    extension(ActionResult<GetAllPostsApiResponse> response)
    {
        public void ShouldSatisfy(
        ICollection<Post> posts,
        GetAllPostsApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(posts, request));
        }
    }

    extension(ActionResult<GetAllPostsForUserApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<Post> posts,
        GetAllPostsForUserApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, posts, request));
        }
    }

    extension(Post post)
    {
        public void ShouldSatisfy(AddPostApiRequest request)
        {
            post.ShouldSatisfy(p => p.Matches(request));
        }

        public void ShouldSatisfy(UpdatePostApiRequest request)
        {
            post.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
