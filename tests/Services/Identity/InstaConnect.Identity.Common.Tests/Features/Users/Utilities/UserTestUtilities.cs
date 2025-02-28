using InstaConnect.Common.Tests.Utilities;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

public abstract class UserTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength);

    public static readonly string ValidAddName = GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
    public static readonly string ValidUpdateName = GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);

    public static readonly string ValidAddFirstName = GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength);
    public static readonly string ValidUpdateFirstName = GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength);

    public static readonly string ValidAddEmail = GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength);
    public static readonly string ValidUpdateEmail = GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength);

    public static readonly string ValidAddLastName = GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength);
    public static readonly string ValidUpdateLastName = GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength);

    public static readonly string ValidProfileImage = GetUrl();
    public static readonly string ValidAddProfileImage = GetUrl();
    public static readonly string ValidUpdateProfileImage = GetUrl();

    public static readonly string ValidAddFormFileName = GetString();
    public static readonly string ValidUpdateFormFileName = GetString();

    public static readonly IFormFile ValidAddFormFile = GetFile(ValidAddFormFileName);
    public static readonly IFormFile ValidUpdateFormFile = GetFile(ValidUpdateFormFileName);

    public static readonly string ValidPassword = GetAverageString(UserConfigurations.PasswordMaxLength, UserConfigurations.PasswordMinLength);
    public static readonly string ValidAddPassword = GetAverageString(UserConfigurations.PasswordMaxLength, UserConfigurations.PasswordMinLength);
    public static readonly string ValidUpdatePassword = GetAverageString(UserConfigurations.PasswordMaxLength, UserConfigurations.PasswordMinLength);

    public static readonly string ValidPasswordHash = GetAverageString(UserConfigurations.PasswordMaxLength, UserConfigurations.PasswordMinLength);
    public static readonly string ValidAddPasswordHash = GetAverageString(UserConfigurations.PasswordMaxLength, UserConfigurations.PasswordMinLength);
    public static readonly string ValidUpdatePasswordHash = GetAverageString(UserConfigurations.PasswordMaxLength, UserConfigurations.PasswordMinLength);

    public static readonly string ValidAccessTokenValue = GetGuid();

    public static readonly DateTimeOffset ValidUntil = GetMaxDate();

    public static readonly int ValidPageValue = 1;
    public static readonly int ValidPageSizeValue = 20;
    public static readonly int ValidTotalCountValue = 1;

    public static readonly string ValidSortPropertyName = "CreatedAt";
    public static readonly string InvalidSortPropertyName = "CreatedAtt";

    public static readonly SortOrder ValidSortOrderProperty = SortOrder.ASC;
}
