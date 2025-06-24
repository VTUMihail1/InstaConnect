using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;

public abstract class BasePostUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected IPostFactory PostFactory { get; }

    protected IPostService PostService { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IUserRepository UserWriteRepository { get; }

    protected IPostReadRepository PostReadRepository { get; }

    protected IPostWriteRepository PostWriteRepository { get; }

    protected BasePostUnitTest()
    {
        CancellationToken = new CancellationToken();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PostApplicationReference.Assembly))));
        UnitOfWork = Mocker.Mock<IUnitOfWork>();
        PostFactory = Mocker.Mock<IPostFactory>();
        PostService = Mocker.Mock<IPostService>();
        UserWriteRepository = Mocker.Mock<IUserRepository>();
        PostReadRepository = Mocker.Mock<IPostReadRepository>();
        PostWriteRepository = Mocker.Mock<IPostWriteRepository>();
    }

    protected Post SetupPost(User user)
    {
        var post = new PostBuilder(user).Create();

        PostReadRepository.SetupGetByIdAsync(post, CancellationToken);

        PostWriteRepository.SetupGetByIdAsync(post, CancellationToken);

        return post;
    }

    protected User SetupUser()
    {
        var user = new UserBuilder().Create();

        UserWriteRepository.SetupGetByIdAsync(user, CancellationToken);

        return user;
    }
}
