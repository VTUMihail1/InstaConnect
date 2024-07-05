using AutoMapper;
using InstaConnect.Emails.Business.Models.Emails;
using InstaConnect.Shared.Business.Contracts.Emails;

namespace InstaConnect.Emails.Business.Profiles;

public class EmailsBusinessProfile : Profile
{
    public EmailsBusinessProfile()
    {
        CreateMap<UserConfirmEmailTokenCreatedEvent, SendConfirmEmailModel>();

        CreateMap<UserForgotPasswordTokenCreatedEvent, SendForgotPasswordModel>();
    }
}
