using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Comment
{
    public class CommentAddDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string PostId { get; set; }

        public string? CommentId { get; set; }

        [Required]
        [MinLength(InstaConnectModelConfigurations.PostCommentContentMinLength)]
        [MaxLength(InstaConnectModelConfigurations.PostCommentContentMaxLength)]
        public string Content { get; set; }
    }
}
