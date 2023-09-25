using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Message
{
    public class MessageUpdateDTO
    {
        [Required]
        public string Content { get; set; }
    }
}
