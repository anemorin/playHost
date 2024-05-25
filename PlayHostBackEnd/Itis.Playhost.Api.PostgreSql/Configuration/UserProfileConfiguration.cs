using Itis.Playhost.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itis.Playhost.Api.PostgreSql.Configuration;

/// <summary>
/// Конфигурация для <see cref="UserProfile"/>>
/// </summary>
internal class UserProfileConfiguration: EntityBaseConfiguration<UserProfile>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("user_profiles", "public")
            .HasComment("Профили пользователей");

        builder.HasOne(x => x.User)
            .WithOne(x => x.UserProfile)
            .HasForeignKey<UserProfile>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}