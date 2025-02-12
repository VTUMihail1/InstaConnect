using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Common.Features.Users.Utilities;
public class UserTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidId = GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength);

    public static readonly string ValidAddName = GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
    public static readonly string ValidUpdateName = GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);

    public static readonly string ValidAddFirstName = GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength);
    public static readonly string ValidUpdateFirstName = GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength);

    public static readonly string ValidAddLastName = GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength);
    public static readonly string ValidUpdateLastName = GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength);

    public static readonly string ValidAddEmail = GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength);

    public static readonly string ValidAddProfileImage = GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength);
    public static readonly string ValidUpdateProfileImage = GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength);
}
