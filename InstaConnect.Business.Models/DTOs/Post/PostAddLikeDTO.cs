using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Post
{
    public class PostAddLikeDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string PostId { get; set; }
    }
}
