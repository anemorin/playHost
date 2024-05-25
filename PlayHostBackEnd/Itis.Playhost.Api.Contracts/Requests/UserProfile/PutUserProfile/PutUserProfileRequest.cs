using System.ComponentModel.DataAnnotations;
using Itis.Playhost.Api.Contracts.Enums;

namespace Itis.Playhost.Api.Contracts.Requests.UserProfile.PutUserProfile;

/// <summary>
/// Запрос на изменение профиля пользователя
/// </summary>
public class PutUserProfileRequest
{
    /// <summary>
    /// Пол
    /// </summary>
    public Genders? Gender { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Рост
    /// </summary>
    public int? Height { get; set; }
    
    /// <summary>
    /// Вес
    /// </summary>
    public int? Weight { get; set; }
}