using AutoMapper;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Posts.Presentation.Features.Users.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using NSubstitute;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    public BaseUserUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        CancellationToken = new();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<UserConsumerProfile>())));
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
    }

    public string CreateUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        UserWriteRepository.GetByIdAsync(
            user.Id,
            CancellationToken)
            .Returns(user);

        return user.Id;
    }
}
