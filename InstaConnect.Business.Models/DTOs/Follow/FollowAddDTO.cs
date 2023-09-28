using InstaConnect.Business.Models.Filters;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Business.Models.DTOs.Follow
{
    public class FollowAddDTO
    {
        [Required]
        public string FollowingId { get; set; }

        [Required]
        [NotEqual(nameof(FollowingId))]
        public string FollowerId { get; set; }
    }
}
