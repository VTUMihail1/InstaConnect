using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    extension(AddPostLikeApiResponse response)
    {
        public void ShouldSatisfy(
        PostLike postLike,
        AddPostLikeApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postLike, request));
        }
    }

    extension(GetPostLikeByIdApiResponse response)
    {
        public void ShouldSatisfy(
        PostLike postLike,
        GetPostLikeByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postLike, request));
        }
    }

    extension(GetAllPostLikesApiResponse response)
    {
        public void ShouldSatisfy(
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, postLikes, request));
        }

        public void ShouldSatisfy(
            Post post,
            ICollection<PostLike> postLikes,
            GetAllPostLikesApiRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(post, postLikes, request, termTransformer));
        }
    }

    extension(GetAllPostLikesForUserApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, postLikes, request));
        }

        public void ShouldSatisfy(
            User user,
            ICollection<PostLike> postLikes,
            GetAllPostLikesForUserApiRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, postLikes, request, termTransformer));
        }
    }

    extension(ActionResult<AddPostLikeApiResponse> response)
    {
        public void ShouldSatisfy(
        PostLike postLike,
        AddPostLikeApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike, request));
        }
    }

    extension(ActionResult<GetPostLikeByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        PostLike postLike,
        GetPostLikeByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(postLike, request));
        }
    }

    extension(ActionResult<GetAllPostLikesApiResponse> response)
    {
        public void ShouldSatisfy(
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(post, postLikes, request));
        }
    }

    extension(ActionResult<GetAllPostLikesForUserApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, postLikes, request));
        }
    }

    extension(PostLike postLike)
    {
        public void ShouldSatisfy(AddPostLikeApiRequest request)
        {
            postLike.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
