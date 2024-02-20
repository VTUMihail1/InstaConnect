using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.PostLike
{
    public class PostLikeAddDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string PostId { get; set; }
    }
}
