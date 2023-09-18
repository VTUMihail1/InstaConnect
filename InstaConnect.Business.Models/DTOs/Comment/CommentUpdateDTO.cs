using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Comment
{
    public class CommentUpdateDTO
    {
        [Required]
        [MinLength(InstaConnectModelConfigurations.PostCommentContentMinLength)]
        [MaxLength(InstaConnectModelConfigurations.PostCommentContentMaxLength)]
        public string Content { get; set; }
    }
}
