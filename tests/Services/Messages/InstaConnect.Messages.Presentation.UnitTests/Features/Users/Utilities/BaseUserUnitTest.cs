using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Messages.Domain.Features.Users.Abstractions;
using InstaConnect.Messages.Presentation.Extensions;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected BaseUserUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        CancellationToken = new();
        ApplicationMapper = new ApplicationMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PresentationReference.Assembly))));
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
    }

    private User CreateUserUtil()
    {
        var user = new User(
            DataFaker.GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength),
            DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            DataFaker.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength),
            DataFaker.GetMaxDate(),
            DataFaker.GetMaxDate());

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
