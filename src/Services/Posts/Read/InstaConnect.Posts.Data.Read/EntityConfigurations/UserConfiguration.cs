using InstaConnect.Messages.Data.Read.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstaConnect.Messages.Data.Read.EntitiyConfigurations;

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

        builder.HasMany(f => f.Posts)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.PostLikes)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.PostComments)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.PostCommentLikes)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
