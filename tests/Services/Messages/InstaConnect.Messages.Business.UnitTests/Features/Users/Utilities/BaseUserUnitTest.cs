using AutoMapper;
using InstaConnect.Messages.Business.Features.Users.Mappings;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Data.Features.Users.Abstract;
using InstaConnect.Messages.Data.Features.Users.Models.Entities;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstractions;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Features.Users.Utilities;

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
