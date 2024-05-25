using Itis.Playhost.Api.Contracts.Requests.User.ResetPassword;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.User.ResetPassword;

/// <summary>
/// Команда запроса <see cref="ResetPasswordRequest"/>
/// </summary>
public class ResetPasswordCommand: ResetPasswordRequest, IRequest<ResetPasswordResponse>
{
}