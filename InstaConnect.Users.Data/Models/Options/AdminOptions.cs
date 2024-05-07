using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Users.Data.Models.Options;

internal class AdminOptions
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
