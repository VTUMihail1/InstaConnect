namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;

public record GetAllPostCommentsQuerySpecification(
    string Sql,
    GetAllPostCommentsQueryParameters Parameters);
