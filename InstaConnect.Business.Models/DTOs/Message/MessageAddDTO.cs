using InstaConnect.Business.Models.Filters;
using InstaConnect.Business.Models.Utilities;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Message
{
    public class MessageAddDTO
    {
        [Required]
        public string SenderId { get; set; }

        [Required]
        [NotEqual(nameof(SenderId))]
        public string ReceiverId { get; set; }

        [Required]
        [MinLength(InstaConnectModelConfigurations.MessageContentMinLength)]
        [MaxLength(InstaConnectModelConfigurations.MessageContentMaxLength)]
        public string Content { get; set; }
    }
}
