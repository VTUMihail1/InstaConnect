using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
public abstract class BasePostCommentTest
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

    protected CancellationToken CancellationToken { get; }

    protected BasePostCommentTest()
    {
        UserBuilderFactory = new();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Create();

        PostBuilderFactory = new();
        PostBuilder = PostBuilderFactory.Create(User);
        Post = PostBuilder.Create();

        PostCommentBuilderFactory = new();
        PostCommentBuilder = PostCommentBuilderFactory.Create(User);
        PostComment = PostCommentBuilder.Create();

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
