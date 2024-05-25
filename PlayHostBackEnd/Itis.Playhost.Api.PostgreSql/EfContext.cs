using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Entities;
using Itis.Playhost.Api.PostgreSql.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.PostgreSql;

/// <summary>
/// Контекст EF Core для приложения
/// </summary>
public class EfContext: IdentityDbContext<User, Role, Guid>, IDbContext
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="options">Параметры подключения к БД</param>
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    /// <summary>
    /// Добавление моделей при запуске
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);
    }

    public DbSet<Subscription> Subscriptions { get; set; }

    /// <inheritdoc />
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await SaveChangesAsync(true, cancellationToken);

    /// <inheritdoc />
    public DbSet<UserProfile> UserProfiles { get; set; }

    /// <inheritdoc />
    public DbSet<Server> Servers { get; set; }
    
    /// <inheritdoc />
    public DbSet<Game> Games { get; set; }
    
    /// <inheritdoc />
    public DbSet<Review> Reviews { get; set; }
    
    /// <inheritdoc />
    public DbSet<New> News { get; set; }
}