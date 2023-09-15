using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Token
{
    public class TokenAddDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }
    }
}
