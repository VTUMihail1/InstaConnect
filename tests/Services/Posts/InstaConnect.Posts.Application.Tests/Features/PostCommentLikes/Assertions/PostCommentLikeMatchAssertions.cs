using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
    extension(AddPostCommentLikeCommandResponse response)
    {
        public void ShouldSatisfy(PostCommentLike postCommentLike, AddPostCommentLikeCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postCommentLike, request));
        }
    }

    extension(GetPostCommentLikeByIdQueryResponse response)
    {
        public void ShouldSatisfy(PostCommentLike postCommentLike, GetPostCommentLikeByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postCommentLike, request));
        }
    }

    extension(GetAllPostCommentLikesQueryResponse response)
    {
        public void ShouldSatisfy(PostComment postComment, ICollection<PostCommentLike> postCommentLikes, GetAllPostCommentLikesQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, request));
        }

        public void ShouldSatisfy(PostComment postComment, ICollection<PostCommentLike> postCommentLikes, GetAllPostCommentLikesQueryRequest request, ISortEnumTermTransformer<PostCommentLike> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, postCommentLikes, request, termTransformer));
        }
    }

    extension(GetAllPostCommentLikesForUserQueryResponse response)
    {
        public void ShouldSatisfy(User user, ICollection<PostCommentLike> postCommentLikes, GetAllPostCommentLikesForUserQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, request));
        }

        public void ShouldSatisfy(User user, ICollection<PostCommentLike> postCommentLikes, GetAllPostCommentLikesForUserQueryRequest request, ISortEnumTermTransformer<PostCommentLike> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, postCommentLikes, request, termTransformer));
        }
    }

    extension(PostCommentLike postCommentLike)
    {
        public void ShouldSatisfy(AddPostCommentLikeCommandRequest request)
        {
            postCommentLike.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
