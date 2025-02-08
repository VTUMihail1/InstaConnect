using AutoMapper;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Mappings;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Identity.Domain.Features.Users.Models.Filters;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Application.Models;
using InstaConnect.Shared.Application.UnitTests.Utilities;
using InstaConnect.Shared.Common.Utilities;
using InstaConnect.Shared.Domain.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;

public abstract class BaseEmailConfirmationTokenUnitTest
{
    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IEmailConfirmationTokenWriteRepository EmailConfirmationTokenWriteRepository { get; }

    protected IEmailConfirmationTokenPublisher EmailConfirmationTokenPublisher { get; }

    public BaseEmailConfirmationTokenUnitTest()
    {
        UnitOfWork = Substitute.For<IUnitOfWork>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddProfile<EmailConfirmationTokenCommandProfile>())));
        CancellationToken = new CancellationToken();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        EmailConfirmationTokenWriteRepository = Substitute.For<IEmailConfirmationTokenWriteRepository>();
        EmailConfirmationTokenPublisher = Substitute.For<IEmailConfirmationTokenPublisher>();
    }

    public User CreateUser()
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidPasswordHash,
            UserTestUtilities.ValidProfileImage);

        UserWriteRepository.GetByIdAsync(user.Id, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByNameAsync(user.UserName, CancellationToken)
            .Returns(user);

        UserWriteRepository.GetByEmailAsync(user.Email, CancellationToken)
            .Returns(user);

        return user;
    }

    public EmailConfirmationToken CreateEmailConfirmationToken()
    {
        var user = CreateUser();
        var emailConfirmationToken = new EmailConfirmationToken(
            SharedTestUtilities.GetGuid(), 
            SharedTestUtilities.GetMaxDate(), 
            user.Id);

        EmailConfirmationTokenWriteRepository.GetByValueAsync(emailConfirmationToken.Value, CancellationToken)
            .Returns(emailConfirmationToken);

        return emailConfirmationToken;
    }
}
