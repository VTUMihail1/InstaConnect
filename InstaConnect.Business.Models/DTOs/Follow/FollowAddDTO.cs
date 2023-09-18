using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Follow
{
    public class FollowAddDTO
    {
        [Required]
        public string FollowingId { get; set; }

        [Required]
        public string FollowerId { get; set; }
    }
}
