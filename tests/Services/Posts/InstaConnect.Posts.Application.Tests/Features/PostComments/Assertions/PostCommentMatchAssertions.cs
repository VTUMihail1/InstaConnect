using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    extension(AddPostCommentCommandResponse response)
    {
        public void ShouldSatisfy(PostComment postComment, AddPostCommentCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(UpdatePostCommentCommandResponse response)
    {
        public void ShouldSatisfy(PostComment postComment, UpdatePostCommentCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(GetPostCommentByIdQueryResponse response)
    {
        public void ShouldSatisfy(PostComment postComment, GetPostCommentByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(GetAllPostCommentsQueryResponse response)
    {
        public void ShouldSatisfy(Post post, ICollection<PostComment> postComments, GetAllPostCommentsQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, postComments, request));
        }

        public void ShouldSatisfy(Post post, ICollection<PostComment> postComments, GetAllPostCommentsQueryRequest request, ISortEnumTermTransformer<PostComment> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(post, postComments, request, termTransformer));
        }
    }

    extension(GetAllPostCommentsForUserQueryResponse response)
    {
        public void ShouldSatisfy(User user, ICollection<PostComment> postComments, GetAllPostCommentsForUserQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, postComments, request));
        }

        public void ShouldSatisfy(User user, ICollection<PostComment> postComments, GetAllPostCommentsForUserQueryRequest request, ISortEnumTermTransformer<PostComment> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, postComments, request, termTransformer));
        }
    }

    extension(PostComment postComment)
    {
        public void ShouldSatisfy(AddPostCommentCommandRequest request)
        {
            postComment.ShouldSatisfy(p => p.Matches(request));
        }

        public void ShouldSatisfy(UpdatePostCommentCommandRequest request)
        {
            postComment.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
