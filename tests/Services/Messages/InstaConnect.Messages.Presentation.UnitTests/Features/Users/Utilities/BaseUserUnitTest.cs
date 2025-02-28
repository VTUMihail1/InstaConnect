using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Messages.Domain.Features.Users.Abstractions;
using InstaConnect.Messages.Presentation.Extensions;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Users.Utilities;

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
            SharedTestUtilities.GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength),
            SharedTestUtilities.GetMaxDate(),
            SharedTestUtilities.GetMaxDate());

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
