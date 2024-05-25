using Itis.Playhost.Api.Contracts.Enums;
using Itis.Playhost.Api.Core.Exceptions;

namespace Itis.Playhost.Api.Core.Entities;

/// <summary>
/// Профиль пользователя
/// </summary>
public class UserProfile : EntityBase
{
    private User _user;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    public UserProfile()
    {
    }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Пользователь
    /// </summary>
    public User User 
    { 
        get => _user;
        set
        {
            _user = value 
                ?? throw new RequiredFieldIsEmpty("Пользователь");
            UserId = value.Id;
        }
    }
}