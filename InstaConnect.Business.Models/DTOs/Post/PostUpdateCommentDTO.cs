using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Post
{
    public class PostUpdateCommentDTO
    {
        [Required]
        [MinLength(InstaConnectModelConfigurations.PostCommentContentMinLength)]
        [MaxLength(InstaConnectModelConfigurations.PostCommentContentMaxLength)]
        public string Content { get; set; }
    }
}
