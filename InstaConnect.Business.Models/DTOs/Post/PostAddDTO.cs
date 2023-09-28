using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Post
{
    public class PostAddDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(InstaConnectModelConfigurations.PostTitleMinLength)]
        [MaxLength(InstaConnectModelConfigurations.PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(InstaConnectModelConfigurations.PostTitleMinLength)]
        [MaxLength(InstaConnectModelConfigurations.PostTitleMaxLength)]
        public string Content { get; set; }
    }
}
