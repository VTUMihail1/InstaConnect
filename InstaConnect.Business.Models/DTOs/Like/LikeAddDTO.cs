using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Like
{
    public class LikeAddDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string PostId { get; set; }
    }
}
