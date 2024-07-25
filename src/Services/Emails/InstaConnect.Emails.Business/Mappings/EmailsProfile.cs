using AutoMapper;
using InstaConnect.Emails.Business.Models.Emails;
using InstaConnect.Shared.Business.Contracts.Emails;

namespace InstaConnect.Emails.Business.Profiles;

internal class EmailsProfile : Profile
{
    public EmailsProfile()
    {
        CreateMap<UserConfirmEmailTokenCreatedEvent, SendConfirmEmailModel>();

        CreateMap<UserForgotPasswordTokenCreatedEvent, SendForgotPasswordModel>();
    }
}
