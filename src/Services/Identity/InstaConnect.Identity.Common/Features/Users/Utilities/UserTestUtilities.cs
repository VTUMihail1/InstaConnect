using InstaConnect.Shared.Common.Utilities;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace InstaConnect.Identity.Common.Features.Users.Utilities;

public abstract class UserTestUtilities : SharedTestUtilities
{
    public static readonly string ValidId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string ValidTakenId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string ValidIdWithUnconfirmedEmail = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);
    public static readonly string InvalidId = GetAverageString(UserBusinessConfigurations.ID_MAX_LENGTH, UserBusinessConfigurations.ID_MIN_LENGTH);

    public static readonly string ValidName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
    public static readonly string ValidTakenName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
    public static readonly string ValidNameWithUnconfirmedEmail = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
    public static readonly string InvalidName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);

    public static readonly string ValidFirstName = GetAverageString(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH, UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH);
    public static readonly string ValidEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
    public static readonly string ValidTakenEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
    public static readonly string ValidEmailWithUnconfirmedEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
    public static readonly string InvalidEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);

    public static readonly string ValidLastName = GetAverageString(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH, UserBusinessConfigurations.LAST_NAME_MIN_LENGTH);

    public static readonly string ValidProfileImage = GetUrl();
    public static readonly string ValidEmailConfirmationTokenValue = GetGuid();
    public static readonly string ValidEmailConfirmationTokenValueWithConfirmedUser = GetGuid();
    public static readonly string ValidEmailConfirmationTokenValueWithTokenUser = GetGuid();
    public static readonly string InvalidEmailConfirmationTokenValue = GetGuid();
    public static readonly string ValidForgotPasswordTokenValue = GetGuid();
    public static readonly string ValidForgotPasswordTokenValueWithTokenUser = GetGuid();
    public static readonly string InvalidForgotPasswordTokenValue = GetGuid();
    public static readonly string ValidAccessTokenValue = GetGuid();
    public static readonly string ValidPassword = GetAverageString(UserBusinessConfigurations.PASSWORD_MAX_LENGTH, UserBusinessConfigurations.PASSWORD_MIN_LENGTH);
    public static readonly string InvalidPassword = GetAverageString(UserBusinessConfigurations.PASSWORD_MAX_LENGTH, UserBusinessConfigurations.PASSWORD_MIN_LENGTH);
    public static readonly string ValidPasswordHash = GetAverageString(UserBusinessConfigurations.PASSWORD_MAX_LENGTH, UserBusinessConfigurations.PASSWORD_MIN_LENGTH);

    public static readonly string ValidAddEmail = GetAverageString(UserBusinessConfigurations.EMAIL_MAX_LENGTH, UserBusinessConfigurations.EMAIL_MIN_LENGTH);
    public static readonly string ValidAddName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateName = GetAverageString(UserBusinessConfigurations.USER_NAME_MAX_LENGTH, UserBusinessConfigurations.USER_NAME_MIN_LENGTH);
    public static readonly string ValidAddFirstName = GetAverageString(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH, UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateFirstName = GetAverageString(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH, UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH);
    public static readonly string ValidAddLastName = GetAverageString(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH, UserBusinessConfigurations.LAST_NAME_MIN_LENGTH);
    public static readonly string ValidUpdateLastName = GetAverageString(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH, UserBusinessConfigurations.LAST_NAME_MIN_LENGTH);
    public static readonly string ValidAddProfileImage = GetUrl();
    public static readonly string ValidUpdateProfileImage = GetUrl();
    public static readonly IFormFile ValidFormFile = Substitute.For<IFormFile>();
    public static readonly IFormFile ValidAddFormFile = Substitute.For<IFormFile>();
    public static readonly IFormFile ValidUpdateFormFile = Substitute.For<IFormFile>();
    public static readonly DateTime ValidUntil = GetMaxDate();
}
