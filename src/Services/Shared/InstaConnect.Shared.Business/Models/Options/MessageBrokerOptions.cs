using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Shared.Business.Models.Options;
internal class MessageBrokerOptions
{
    [Required]
    public string Host { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
