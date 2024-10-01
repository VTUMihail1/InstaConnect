using AutoMapper;
using InstaConnect.Follows.Business.Features.Users.Mappings;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Data.Features.Users.Abstractions;
using InstaConnect.Follows.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest : BaseSharedUnitTest
{
    protected IUserWriteRepository UserWriteRepository { get; }

    public BaseUserUnitTest() : base(
        Substitute.For<IUnitOfWork>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<UserConsumerProfile>()))),
        new EntityPropertyValidator())
    {
        UserWriteRepository = Substitute.For<IUserWriteRepository>();

        var existingUser = new User(
            UserTestUtilities.ValidUserFirstName,
            UserTestUtilities.ValidUserLastName,
            UserTestUtilities.ValidUserEmail,
            UserTestUtilities.ValidUserName,
            UserTestUtilities.ValidUserProfileImage)
        {
            Id = UserTestUtilities.ValidCurrentUserId,
        };

        UserWriteRepository.GetByIdAsync(
            UserTestUtilities.ValidCurrentUserId,
            CancellationToken)
            .Returns(existingUser);
    }
}
