using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Account
{
    public class AccountResetPasswordDTO
    {
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
    }
}
