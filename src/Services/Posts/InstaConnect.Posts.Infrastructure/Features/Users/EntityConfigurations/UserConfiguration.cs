using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.Users.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(p => p.Id)
            .HasMaxLength(UserConfigurations.IdMaxLength)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(p => p.FirstName)
            .HasMaxLength(UserConfigurations.FirstNameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.LastName)
            .HasMaxLength(UserConfigurations.LastNameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasMaxLength(UserConfigurations.EmailMaxLength)
            .IsRequired();

        builder
            .Property(p => p.Name)
            .HasMaxLength(UserConfigurations.NameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.ProfileImage)
            .HasMaxLength(UserConfigurations.ProfileImageMaxLength);

        builder.HasMany(f => f.Posts)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.PostLikes)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.PostComments)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.PostCommentLikes)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
