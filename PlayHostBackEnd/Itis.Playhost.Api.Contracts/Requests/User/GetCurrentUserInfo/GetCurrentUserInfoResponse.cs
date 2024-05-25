using Itis.Playhost.Api.Contracts.Requests.User.SendResetPasswordCode;

namespace Itis.Playhost.Api.Contracts.Requests.User.GetCurrentUserInfo;

/// <summary>
/// Ответ на запрос <see cref="SendResetPasswordCodeRequest"/>
/// </summary>
public class GetCurrentUserInfoResponse
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Идентификатор профиля пользователя
    /// </summary>
    public Guid? UserProfileId { get; set; }

    /// <summary>
    /// Почта
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; set; } = default!;
        
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; set; } = default!;
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string Role { get; set; } = default!;
}