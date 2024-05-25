using Itis.Playhost.Api.Contracts.Requests.UserProfile.PutUserProfile;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.UserProfile.PutUserProfile;

public class PutUserProfileCommandHandler: IRequestHandler<PutUserProfileCommand, PutUserProfileResponse>
{
    private readonly IUserService _userService;
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователем</param>
    /// <param name="dbContext">Контекст БД</param>
    public PutUserProfileCommandHandler(
        IUserService userService,
        IDbContext dbContext)
    {
        _userService = userService;
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<PutUserProfileResponse> Handle(PutUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = await _userService.FindUserProfileByUserId(request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException<Entities.UserProfile>("Не найден профиль для данного пользователя");
    
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new PutUserProfileResponse(userProfile.Id);
    }
}