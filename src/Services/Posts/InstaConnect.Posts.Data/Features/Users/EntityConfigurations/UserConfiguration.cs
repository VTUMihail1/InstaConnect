using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Posts.Data.Features.Users.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("user");

        builder
            .Property(p => p.Id)
            .HasColumnName("id");

        builder
            .Property(p => p.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(p => p.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasColumnName("email");

        builder
            .Property(p => p.UserName)
            .HasColumnName("user_name");

        builder
            .Property(p => p.ProfileImage)
            .HasColumnName("profile_image");

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
