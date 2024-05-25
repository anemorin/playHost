using Itis.Playhost.Api.Core.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace Itis.Playhost.Api.Core.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User: IdentityUser<Guid>, IEntity
{
    private UserProfile? _userProfile;
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; set; } = default!;
        
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Идентификатор профиля пользователя
    /// </summary>
    public Guid? UserProfileId { get; set; }

    /// <summary>
    /// Профиль пользователя
    /// </summary>
    public UserProfile? UserProfile 
    { 
        get => _userProfile;
        set
        {
            _userProfile = value;
            UserProfileId = value?.Id;
        }
    }
    
    /// <summary>
    /// Подписки
    /// </summary>
    public IReadOnlyList<Subscription>? Subscriptions { get; set; }

    /// <summary>
    /// Обзоры
    /// </summary>
    public IReadOnlyList<Review>? Reviews { get; set; }
}