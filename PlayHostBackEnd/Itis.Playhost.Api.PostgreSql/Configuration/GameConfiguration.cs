using Itis.Playhost.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itis.Playhost.Api.PostgreSql.Configuration;

/// <summary>
/// Конфигурация для <see cref="Game"/>
/// </summary>
internal class GameConfiguration : EntityBaseConfiguration<Game>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("games", "public")
            .HasComment("Игры");
        
        builder.Property(x => x.Image)
            .HasComment("Url картинки");
        
        builder.Property(x => x.Name)
            .HasComment("Url картинки");
        
        builder.Property(x => x.Price)
            .HasComment("Url картинки");

        builder.HasMany(x => x.Subscriptions)
            .WithOne(x => x.Game)
            .HasForeignKey(x => x.GameId)
            .HasPrincipalKey(x => x.Id);
    }
}