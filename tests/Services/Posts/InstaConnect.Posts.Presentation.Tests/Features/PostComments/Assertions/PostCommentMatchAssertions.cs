using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
    extension(AddPostCommentApiResponse response)
    {
        public void ShouldSatisfy(
        PostComment postComment,
        AddPostCommentApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(UpdatePostCommentApiResponse response)
    {
        public void ShouldSatisfy(
        PostComment postComment,
        UpdatePostCommentApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(GetPostCommentByIdApiResponse response)
    {
        public void ShouldSatisfy(
        PostComment postComment,
        GetPostCommentByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(GetAllPostCommentsApiResponse response)
    {
        public void ShouldSatisfy(
        Post post,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(post, postComments, request));
        }

        public void ShouldSatisfy(
            Post post,
            ICollection<PostComment> postComments,
            GetAllPostCommentsApiRequest request,
            ISortEnumTermTransformer<PostComment> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(post, postComments, request, termTransformer));
        }
    }

    extension(GetAllPostCommentsForUserApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, postComments, request));
        }

        public void ShouldSatisfy(
            User user,
            ICollection<PostComment> postComments,
            GetAllPostCommentsForUserApiRequest request,
            ISortEnumTermTransformer<PostComment> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, postComments, request, termTransformer));
        }
    }

    extension(ActionResult<AddPostCommentApiResponse> response)
    {
        public void ShouldSatisfy(
        PostComment postComment,
        AddPostCommentApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(ActionResult<UpdatePostCommentApiResponse> response)
    {
        public void ShouldSatisfy(
        PostComment postComment,
        UpdatePostCommentApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(ActionResult<GetPostCommentByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        PostComment postComment,
        GetPostCommentByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(postComment, request));
        }
    }

    extension(ActionResult<GetAllPostCommentsApiResponse> response)
    {
        public void ShouldSatisfy(
        Post post,
        ICollection<PostComment> postComments,
        GetAllPostCommentsApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(post, postComments, request));
        }
    }

    extension(ActionResult<GetAllPostCommentsForUserApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<PostComment> postComments,
        GetAllPostCommentsForUserApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, postComments, request));
        }
    }

    extension(PostComment postComment)
    {
        public void ShouldSatisfy(AddPostCommentApiRequest request)
        {
            postComment.ShouldSatisfy(p => p.Matches(request));
        }

        public void ShouldSatisfy(UpdatePostCommentApiRequest request)
        {
            postComment.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
