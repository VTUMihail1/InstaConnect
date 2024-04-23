namespace InstaConnect.Shared.Business.Models.Requests
{
    public class ValidateUserByIdRequest
    {
        public string Id { get; set; }

        public string CurrentUserId { get; set; }
    }
}
