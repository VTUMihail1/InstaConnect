using AutoMapper;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Business.Features.Users.Utilities;
using InstaConnect.Identity.Web.Features.Accounts.Mappings;
using InstaConnect.Identity.Web.Features.Users.Mappings;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace InstaConnect.Identity.Web.UnitTests.Features.Users.Utilities;

public abstract class BaseUserUnitTest : BaseSharedUnitTest
{
    protected readonly string ValidId;
    protected readonly string ValidEmail;
    protected readonly string ValidFirstName;
    protected readonly string ValidLastName;
    protected readonly string ValidName;
    protected readonly string ValidProfileImage;
    protected readonly string ValidEmailConfirmationToken;
    protected readonly string ValidForgotPasswordToken;
    protected readonly string ValidAccessToken;
    protected readonly string ValidPassword;
    protected readonly DateTime ValidUntil;
    protected readonly IFormFile ValidFormFile;

    public BaseUserUnitTest() : base(
        Substitute.For<IInstaConnectSender>(),
        Substitute.For<ICurrentUserContext>(),
        new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AccountCommandProfile>();
                    cfg.AddProfile<UserQueryProfile>();
                }))))
    {
        ValidId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
        ValidName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
        ValidFirstName = GetAverageString(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH, UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH);
        ValidLastName = GetAverageString(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH, UserBusinessConfigurations.LAST_NAME_MIN_LENGTH);
        ValidEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
        ValidPassword = GetAverageString(UserBusinessConfigurations.PASSWORD_MAX_LENGTH, UserBusinessConfigurations.PASSWORD_MIN_LENGTH);
        ValidProfileImage = Faker.Internet.Url();
        ValidFormFile = Substitute.For<IFormFile>();
        ValidUntil = Faker.Date.Recent();
        ValidEmailConfirmationToken = Faker.Random.Guid().ToString();
        ValidForgotPasswordToken = Faker.Random.Guid().ToString();
        ValidAccessToken = Faker.Random.Guid().ToString();

        var existingUserQueryViewModel = new UserQueryViewModel(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidProfileImage);

        var existingUserDetailedQueryViewModel = new UserDetailedQueryViewModel(
            ValidId,
            ValidFirstName,
            ValidLastName,
            ValidName,
            ValidEmail,
            ValidProfileImage);

        var existingAccountCommandViewModel = new AccountCommandViewModel(ValidId);

        var existingAccountTokenCommandViewModel = new AccountTokenCommandViewModel(ValidAccessToken, ValidUntil);

        var existingCurrentUserModel = new CurrentUserModel(ValidId, ValidName);

        var existingUserPaginationCollectionModel = new UserPaginationQueryViewModel(
            [existingUserQueryViewModel],
            ValidPageValue,
            ValidPageSizeValue,
            ValidTotalCountValue,
            false,
            false);


        CurrentUserContext
            .GetCurrentUser()
            .Returns(existingCurrentUserModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetAllUsersQuery>(), CancellationToken)
            .Returns(existingUserPaginationCollectionModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetCurrentUserQuery>(), CancellationToken)
            .Returns(existingUserQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetUserByIdQuery>(), CancellationToken)
            .Returns(existingUserQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetUserByNameQuery>(), CancellationToken)
            .Returns(existingUserQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetCurrentUserDetailedQuery>(), CancellationToken)
            .Returns(existingUserDetailedQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<GetUserDetailedByIdQuery>(), CancellationToken)
            .Returns(existingUserDetailedQueryViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<EditCurrentAccountCommand>(), CancellationToken)
            .Returns(existingAccountCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<RegisterAccountCommand>(), CancellationToken)
            .Returns(existingAccountCommandViewModel);

        InstaConnectSender
            .SendAsync(Arg.Any<LoginAccountCommand>(), CancellationToken)
            .Returns(existingAccountTokenCommandViewModel);
    }
}
