using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Account
{
    public class AccountLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
