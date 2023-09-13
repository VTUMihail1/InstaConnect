namespace InstaConnect.Business.Models.DTOs.Account
{
    public class AccountSendEmailDTO
    {
        public string Email { get; set; }

        public string Subject { get; set; }

        public string PlainText { get; set; }

        public string Html { get; set; }
    }
}
