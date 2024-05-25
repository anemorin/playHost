﻿using System.ComponentModel.DataAnnotations;
using Itis.Playhost.Api.Contracts.Requests.UserProfile.PostUserProfile;
using Itis.Playhost.Api.Core.Abstractions;
using Itis.Playhost.Api.Core.Exceptions;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.UserProfile.PostUserProfile;

/// <summary>
/// Обработчик запроса для <see cref="PostUserProfileCommand"/>
/// </summary>
public class PostUserProfileCommandHandler: IRequestHandler<PostUserProfileCommand, PostUserProfileResponse>
{
    private readonly IDbContext _dbContext;
    private readonly IUserService _userService;
    
    /// <summary>
    /// Конструтор
    /// </summary>
    /// <param name="dbContext">Контекст EF Core для приложения</param>
    /// <param name="userService">Сервис для работы с пользователем</param>
    public PostUserProfileCommandHandler(
        IDbContext dbContext, 
        IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }
    
    /// <inheritdoc />
    public async Task<PostUserProfileResponse> Handle(
        PostUserProfileCommand request, 
        CancellationToken cancellationToken)
    {
        var user = await _userService.FindUserByIdAsync(request.UserId)
            ?? throw new EntityNotFoundException<Entities.User>(request.UserId);

        if (user.UserProfileId.HasValue)
            throw new ValidationException("Профиль пользователя уже создан");
        
        var userProfile = new Entities.UserProfile
        {
            UserId = user.Id,
            // Role = request.Role,
        };

        _dbContext.UserProfiles.Add(userProfile);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        user.UserProfileId = userProfile.Id;
        
        await _userService.UpdateUserAsync(user);
        
        return new PostUserProfileResponse(userProfile.Id);
    }
}