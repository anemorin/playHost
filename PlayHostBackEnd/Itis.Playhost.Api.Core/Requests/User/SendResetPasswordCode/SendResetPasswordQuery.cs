using Itis.Playhost.Api.Contracts.Requests.User.SendResetPasswordCode;
using MediatR;

namespace Itis.Playhost.Api.Core.Requests.User.SendResetPasswordCode;

/// <summary>
/// Команда запроса <see cref="SendResetPasswordCodeRequest"/>
/// </summary>
public class SendResetPasswordQuery: SendResetPasswordCodeRequest, IRequest<SendResetPasswordCodeResponse>
{
}