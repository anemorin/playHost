using Itis.Playhost.Api.Contracts.Requests.User.RegisterUser;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.User.RegisterUser;

/// <summary>
/// Команда запроса <see cref="RegisterUserRequest"/>
/// </summary>
public class RegisterUserCommand: RegisterUserRequest, IRequest<RegisterUserResponse>
{
}