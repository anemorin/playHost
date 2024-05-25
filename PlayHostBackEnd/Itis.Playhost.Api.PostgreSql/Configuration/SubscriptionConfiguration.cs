using Itis.Playhost.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itis.Playhost.Api.PostgreSql.Configuration;

/// <summary>
/// Конфигурация для <see cref="Subscription"/>
/// </summary>
internal class SubscriptionConfiguration : EntityBaseConfiguration<Subscription>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("subscriptions", "public")
            .HasComment("Подписки");
        
        builder.Property(x => x.EndDate)
            .HasComment("Дата окончания");
        
        builder.Property(x => x.Price)
            .HasComment("Цена");

        builder.Property(x => x.StartDate)
            .HasComment("Дата начала");
        
        builder.Property(x => x.UserId)
            .HasComment("Пользователь");
        
        builder.Property(x => x.ServerId)
            .HasComment("Сервер");
        
        builder.Property(x => x.GameId)
            .HasComment("Игра");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id);
        
        builder.HasOne(x => x.Server)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.ServerId)
            .HasPrincipalKey(x => x.Id);
        
        builder.HasOne(x => x.Game)
            .WithMany(x => x.Subscriptions)
            .HasForeignKey(x => x.GameId)
            .HasPrincipalKey(x => x.Id);
    }
}