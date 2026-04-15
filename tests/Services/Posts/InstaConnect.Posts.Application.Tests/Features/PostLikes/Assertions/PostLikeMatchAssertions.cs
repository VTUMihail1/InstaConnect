using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
    extension(AddPostLikeCommandResponse response)
    {
        public void ShouldSatisfy(
        PostLike postLike,
        AddPostLikeCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postLike, request));
        }
    }

    extension(GetPostLikeByIdQueryResponse response)
    {
        public void ShouldSatisfy(
        PostLike postLike,
        GetPostLikeByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postLike, request));
        }
    }

    extension(GetAllPostLikesQueryResponse response)
    {
        public void ShouldSatisfy(
        Post post,
        ICollection<PostLike> postLikes,
        GetAllPostLikesQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, postLikes, request));
        }

        public void ShouldSatisfy(
            Post post,
            ICollection<PostLike> postLikes,
            GetAllPostLikesQueryRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(post, postLikes, request, termTransformer));
        }
    }

    extension(GetAllPostLikesForUserQueryResponse response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<PostLike> postLikes,
        GetAllPostLikesForUserQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, postLikes, request));
        }

        public void ShouldSatisfy(
            User user,
            ICollection<PostLike> postLikes,
            GetAllPostLikesForUserQueryRequest request,
            ISortEnumTermTransformer<PostLike> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, postLikes, request, termTransformer));
        }
    }

    extension(PostLike postLike)
    {
        public void ShouldSatisfy(AddPostLikeCommandRequest request)
        {
            postLike.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
