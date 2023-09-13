using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Account
{
    public class AccountRegistrationDTO
    {
        [Required]
        [MinLength(InstaConnectBusinessModelConfiguration.AccountUsernameMinLength)]
        [MaxLength(InstaConnectBusinessModelConfiguration.AccountUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(InstaConnectBusinessModelConfiguration.AccountEmailMinLength)]
        [MaxLength(InstaConnectBusinessModelConfiguration.AccountEmailMaxLength)]
        [RegularExpression(InstaConnectBusinessModelConfiguration.AccountEmailRegex)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(InstaConnectBusinessModelConfiguration.AccountPasswordMinLength)]
        [MaxLength(InstaConnectBusinessModelConfiguration.AccountPasswordMaxLength)]
        [RegularExpression(InstaConnectBusinessModelConfiguration.AccountPasswordRegex)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(InstaConnectBusinessModelConfiguration.AccountFirstNameMinLength)]
        [MaxLength(InstaConnectBusinessModelConfiguration.AccountFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(InstaConnectBusinessModelConfiguration.AccountLastNameMinLength)]
        [MaxLength(InstaConnectBusinessModelConfiguration.AccountLastNameMaxLength)]
        public string LastName { get; set; }
    }
}
