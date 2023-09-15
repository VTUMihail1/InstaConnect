namespace InstaConnect.Business.Models.Options
{
    public class EmailOptions
    {
        public string APIKey { get; set; }

        public string Sender { get; set; }

        public string ConfirmEmailEndpoint { get; set; }

        public string ResetPasswordEndpoint { get; set; }
    }
}
