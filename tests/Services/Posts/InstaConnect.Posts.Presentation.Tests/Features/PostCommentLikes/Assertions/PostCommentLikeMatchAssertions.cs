using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    extension(AddPostCommentLikeApiResponse response)
    {
        public void ShouldSatisfy(
        PostCommentLike postCommentLike,
        AddPostCommentLikeApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postCommentLike, request));
        }
    }

    extension(GetPostCommentLikeByIdApiResponse response)
    {
        public void ShouldSatisfy(
        PostCommentLike postCommentLike,
        GetPostCommentLikeByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postCommentLike, request));
        }
    }

    extension(GetAllPostCommentLikesApiResponse response)
    {
        public void ShouldSatisfy(
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, request));
        }

        public void ShouldSatisfy(
            PostComment postComment,
            ICollection<PostCommentLike> postCommentLikes,
            GetAllPostCommentLikesApiRequest request,
            ISortEnumTermTransformer<PostCommentLike> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, request, termTransformer));
        }
    }

    extension(GetAllPostCommentLikesForUserApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, request));
        }

        public void ShouldSatisfy(
            User user,
            ICollection<PostCommentLike> postCommentLikes,
            GetAllPostCommentLikesForUserApiRequest request,
            ISortEnumTermTransformer<PostCommentLike> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, request, termTransformer));
        }
    }

    extension(ActionResult<AddPostCommentLikeApiResponse> response)
    {
        public void ShouldSatisfy(
        PostCommentLike postCommentLike,
        AddPostCommentLikeApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(postCommentLike, request));
        }
    }

    extension(ActionResult<GetPostCommentLikeByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        PostCommentLike postCommentLike,
        GetPostCommentLikeByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(postCommentLike, request));
        }
    }

    extension(ActionResult<GetAllPostCommentLikesApiResponse> response)
    {
        public void ShouldSatisfy(
        PostComment postComment,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, postCommentLikes, request));
        }
    }

    extension(ActionResult<GetAllPostCommentLikesForUserApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<PostCommentLike> postCommentLikes,
        GetAllPostCommentLikesForUserApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, postCommentLikes, request));
        }
    }

    extension(PostCommentLike postCommentLike)
    {
        public void ShouldSatisfy(AddPostCommentLikeApiRequest request)
        {
            postCommentLike.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
