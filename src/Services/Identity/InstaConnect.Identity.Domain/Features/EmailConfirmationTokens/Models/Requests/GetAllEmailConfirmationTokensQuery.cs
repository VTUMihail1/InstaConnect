using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

public record GetAllEmailConfirmationTokensQuery(EmailConfirmationTokenFilterQuery Filter);
