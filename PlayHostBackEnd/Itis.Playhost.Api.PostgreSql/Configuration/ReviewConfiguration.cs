using Itis.Playhost.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itis.Playhost.Api.PostgreSql.Configuration;

/// <summary>
/// Конфигурация для <see cref="Review"/>
/// </summary>
internal class ReviewConfiguration : EntityBaseConfiguration<Review>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("reviews", "public")
            .HasComment("Обзоры");
        
        builder.Property(x => x.UserId)
            .HasComment("Пользователь");
        
        builder.Property(x => x.Rate)
            .HasComment("Оценка от 1 до 5");
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasComment("Время создания")
            .HasDefaultValueSql("now()");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id);
    }
}