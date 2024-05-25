using Itis.Playhost.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itis.Playhost.Api.PostgreSql.Configuration;

/// <summary>
/// Конфигурация для <see cref="Server"/>
/// </summary>
internal class ServerConfiguration : EntityBaseConfiguration<Server>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Server> builder)
    {
        builder.ToTable("servers", "public")
            .HasComment("Сервера");
        
        builder.Property(x => x.Name)
            .HasComment("Название");
        
        builder.Property(x => x.Price)
            .HasComment("Цена");

        builder.Property(x => x.Ram)
            .HasComment("Оперативная память");
        
        builder.Property(x => x.MaxUsers)
            .HasComment("Максимальное количество пользователей");

        builder.HasMany(x => x.Subscriptions)
            .WithOne(x => x.Server)
            .HasForeignKey(x => x.ServerId)
            .HasPrincipalKey(x => x.Id);
    }
}