using AutoMapper;
using InstaConnect.Emails.Business.Features.Emails.Models.Emails;
using InstaConnect.Shared.Business.Contracts.Emails;

namespace InstaConnect.Emails.Business.Features.Emails.Mappings;

internal class EmailProfile : Profile
{
    public EmailProfile()
    {
        CreateMap<UserConfirmEmailTokenCreatedEvent, SendConfirmEmailModel>();

        CreateMap<UserForgotPasswordTokenCreatedEvent, SendForgotPasswordModel>();
    }
}
