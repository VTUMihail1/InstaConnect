using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace InstaConnect.Users.Business.Commands.AccountRegister
{
    public class AccountRegisterCommand : ICommand
    {
        [Required]
        [MinLength(InstaConnectModelConfigurations.AccountUsernameMinLength)]
        [MaxLength(InstaConnectModelConfigurations.AccountUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(InstaConnectModelConfigurations.AccountEmailMinLength)]
        [MaxLength(InstaConnectModelConfigurations.AccountEmailMaxLength)]
        [RegularExpression(InstaConnectModelConfigurations.AccountEmailRegex)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(InstaConnectModelConfigurations.AccountPasswordMinLength)]
        [MaxLength(InstaConnectModelConfigurations.AccountPasswordMaxLength)]
        [RegularExpression(InstaConnectModelConfigurations.AccountPasswordRegex)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(InstaConnectModelConfigurations.AccountFirstNameMinLength)]
        [MaxLength(InstaConnectModelConfigurations.AccountFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(InstaConnectModelConfigurations.AccountLastNameMinLength)]
        [MaxLength(InstaConnectModelConfigurations.AccountLastNameMaxLength)]
        public string LastName { get; set; }
    }
}
