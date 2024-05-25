using Itis.Playhost.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Itis.Playhost.Api.Core.Abstractions;

/// <summary>
/// Контекст EF Core для приложения
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Профиль пользователя
    /// </summary>
    DbSet<UserProfile> UserProfiles { get; set; }
    
    /// <summary>
    /// Сервер
    /// </summary>
    DbSet<Server> Servers { get; set; }
    
    /// <summary>
    /// Игра
    /// </summary>
    DbSet<Game> Games { get; set; }
    
    /// <summary>
    /// Обзор
    /// </summary>
    DbSet<Review> Reviews { get; set; }
    
    /// <summary>
    /// Новость
    /// </summary>
    DbSet<New> News { get; set; }
    
    /// <summary>
    /// Подписка
    /// </summary>
    DbSet<Subscription> Subscriptions { get; set; }
    
    /// <summary>
    /// Сохранить изменения в БД
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Количество обновленных записей</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}