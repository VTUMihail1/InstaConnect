using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.CommentLike
{
    public class CommentLikeAddDTO
    {
        [Required]
        public string PostCommentId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
