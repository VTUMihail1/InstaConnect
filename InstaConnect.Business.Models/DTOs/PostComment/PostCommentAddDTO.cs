using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Comment
{
    public class PostCommentAddDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string PostId { get; set; }

        public string? PostCommentId { get; set; }

        [Required]
        [MinLength(InstaConnectModelConfigurations.PostCommentContentMinLength)]
        [MaxLength(InstaConnectModelConfigurations.PostCommentContentMaxLength)]
        public string Content { get; set; }
    }
}
