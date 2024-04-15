using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Account
{
    public class AccountLoginCommand
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
