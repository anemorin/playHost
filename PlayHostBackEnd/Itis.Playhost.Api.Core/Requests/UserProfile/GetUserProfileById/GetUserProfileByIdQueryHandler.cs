using Itis.Playhost.Api.Contracts.Requests.UserProfile.GetUserProfileById;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.UserProfile.GetUserProfileById;

/// <summary>
/// Обработчик запроса на получение профиля пользователя
/// </summary>
public class GetUserProfileByIdQueryHandler 
: IRequestHandler<GetUserProfileByIdQuery, GetUserProfileByIdResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public GetUserProfileByIdQueryHandler(
        IDbContext dbContext,
        IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }
    
    /// <inheritdoc />
    public async Task<GetUserProfileByIdResponse> Handle(
        GetUserProfileByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var entity = await _userService.FindUserProfileByUserId(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.UserProfile>(request.Id);
        
        var response = new GetUserProfileByIdResponse
        {
            // Role = entity.Role,
        };

        return response;
    }
}