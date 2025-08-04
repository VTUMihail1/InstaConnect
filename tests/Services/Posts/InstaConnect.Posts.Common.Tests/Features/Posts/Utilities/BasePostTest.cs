using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
public abstract class BasePostTest
{
    protected UserBuilderFactory UserBuilderFactory { get; }
    protected UserBuilder UserBuilder { get; }
    protected User User { get; }

    protected PostBuilderFactory PostBuilderFactory { get; }
    protected PostBuilder PostBuilder { get; }
    protected Post Post { get; }

    protected CancellationToken CancellationToken { get; }

    protected BasePostTest()
    {
        UserBuilderFactory = new UserBuilderFactory();
        UserBuilder = UserBuilderFactory.Create();
        User = UserBuilder.Create();

        PostBuilderFactory = new PostBuilderFactory();
        PostBuilder = PostBuilderFactory.Create(User);
        Post = PostBuilder.Create();

        CancellationToken = MockFactory.CreateCancellationToken();
    }
}
