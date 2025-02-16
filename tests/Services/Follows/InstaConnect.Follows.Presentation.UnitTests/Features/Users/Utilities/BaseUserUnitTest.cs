using AutoMapper;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Follows.Presentation.Extensions;
using InstaConnect.Follows.Presentation.Features.Users.Mappings;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Helpers;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected BaseUserUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        CancellationToken = new();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PresentationReference.Assembly))));
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
    }

    private User CreateUserUtil()
    {
        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        UserWriteRepository.GetByIdAsync(
            user.Id,
            CancellationToken)
            .Returns(user);

        return user;
    }

    protected User CreateUser()
    {
        var user = CreateUserUtil();

        return user;
    }
}
