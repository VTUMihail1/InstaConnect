using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
public abstract class BasePostCommentLikeTest
{
    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }

    protected PostBuilderFactory PostBuilderFactory { get; }
    protected PostBuilder PostBuilder { get; }
    protected Post Post { get; }

    protected PostCommentBuilderFactory PostCommentBuilderFactory { get; }
    protected PostCommentBuilder PostCommentBuilder { get; }
    protected PostComment PostComment { get; }

    protected PostCommentLikeBuilderFactory PostCommentLikeBuilderFactory { get; }
    protected PostCommentLikeBuilder PostCommentLikeBuilder { get; }
    protected PostCommentLike PostCommentLike { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostCommentLikeTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Create();

        PostBuilderFactory = new();
        PostBuilder = PostBuilderFactory.Create(User);
        Post = PostBuilder.Create();

        PostCommentBuilderFactory = new();
        PostCommentBuilder = PostCommentBuilderFactory.Create(Post, User);
        PostComment = PostCommentBuilder.Create();

        PostCommentLikeBuilderFactory = new();
        PostCommentLikeBuilder = PostCommentLikeBuilderFactory.Create(Post, PostComment, User);
        PostCommentLike = PostCommentLikeBuilder.Create();

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
