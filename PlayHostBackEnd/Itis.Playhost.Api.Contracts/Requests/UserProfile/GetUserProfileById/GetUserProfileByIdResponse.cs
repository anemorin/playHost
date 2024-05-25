using Itis.Playhost.Api.Contracts.Enums;

namespace Itis.Playhost.Api.Contracts.Requests.UserProfile.GetUserProfileById;

/// <summary>
/// Ответ на зпрос на получение профиля пользователя
/// </summary>
public class GetUserProfileByIdResponse
{
    /// <summary>
    /// Роль
    /// </summary>
    public string Role { get; set; }
}