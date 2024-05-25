using System.ComponentModel.DataAnnotations;
using Itis.Playhost.Api.Contracts.Enums;

namespace Itis.Playhost.Api.Contracts.Requests.UserProfile.PostUserProfile;

/// <summary>
/// Запрос на создания профиля пользователя
/// </summary>
public class PostUserProfileRequest
{
    /// <summary>
    /// Роль
    /// </summary>
    public string Role { get; set; }
}