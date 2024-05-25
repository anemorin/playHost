using Itis.Playhost.Api.Contracts.Requests.User.GetCurrentUserInfo;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Exceptions;
using Itis.Playhost.Api.Core.Extensions;
using Itis.Playhost.Api.Core.Requests.User.SendResetPasswordCode;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.User.GetCurrentUserInfo;

/// <summary>
/// Обработчик запроса <see cref="SendResetPasswordQuery"/>
/// </summary>
public class GetCurrentUserInfoQueryHandler:
    IRequestHandler<GetCurrentUserInfoQuery, GetCurrentUserInfoResponse>
{
    private IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public GetCurrentUserInfoQueryHandler(
        IUserService userService)
    {
        _userService = userService;
    }
    
    /// <inheritdoc />
    public async Task<GetCurrentUserInfoResponse> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
    {
        if (request.UserId == null)
            throw new ArgumentNullException(nameof(request.UserId));
            
        var user = await _userService.FindUserByIdAsync(request.UserId.Value)
            ?? throw new EntityNotFoundException<Entities.User>("Пользователи не найдены");

        var userProfile = await _userService.FindUserProfileByUserId(user.Id, cancellationToken);
        
        return new GetCurrentUserInfoResponse
        {
            UserId = user.Id,
            UserProfileId = userProfile?.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }
}