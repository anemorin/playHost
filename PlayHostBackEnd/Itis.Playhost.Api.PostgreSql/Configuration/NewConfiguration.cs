using Itis.Playhost.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itis.Playhost.Api.PostgreSql.Configuration;

/// <summary>
/// Конфигурация для <see cref="New"/>
/// </summary>
internal class NewConfiguration : EntityBaseConfiguration<New>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<New> builder)
    {
        builder.ToTable("news", "public")
            .HasComment("Новости");
        
        builder.Property(x => x.Text)
            .HasComment("Текст");
        
        builder.Property(x => x.Title)
            .HasComment("Заголовок");
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasComment("Время создания")
            .HasDefaultValueSql("now()");
    }
}